using System;
using System.IO;
using System.Globalization;
using System.Windows.Controls;
using GameReaderCommon;
using SimHub.Plugins;

namespace MCP4SH
{
    [PluginDescription("MCP4SH – Normalized telemetry for SimHub effects")]
    [PluginAuthor("Dirk Van Echelpoel")]
    [PluginName("MCP4SH")]
    public class MCP4SHPlugin : IPlugin, IDataPlugin, IWPFSettings
    {
        public PluginManager PluginManager { get; set; }

        private Control _settingsControl;

        public Control GetWPFSettingsControl(PluginManager pluginManager)
        {
            if (_settingsControl == null)
            {
                _settingsControl = new MCP4SHSettingsControl(this);
            }

            return _settingsControl;
        }

        // ===== User-tunable gains (safe scaling only) =====
        public double GlobalGain { get; set; } = 1.0;
        public double RoadFeelGain { get; set; } = 1.0;
        public double SuspensionImpactGain { get; set; } = 1.0;
        public double SuspensionVibrationGain { get; set; } = 1.0;
        public double EngineTyresGain { get; set; } = 1.0;
        public double BrakeFeelGain { get; set; } = 1.0;
        public double BrakeNSlipGain { get; set; } = 1.0;
        public double ABSGain { get; set; } = 1.0;
        public double TCGain { get; set; } = 1.0;
        public double ClutchFreeGain { get; set; } = 1.0;
        public double GearshiftGain { get; set; } = 1.0;

        // ===== Debug / logging =====
        public bool DebugMode { get; set; } = false;

        // Internal logging state
        private StreamWriter _debugWriter;
        private bool _debugHeaderWritten;
        private DateTime _debugSessionStartUtc;

        // ===== Engine / car basic signals =====
        private double _rpmNorm;
        private double _speedNorm;
        private double _throttle;
        private double _brake;
        private double _clutch;

        // ===== Tyre temps / load proxies (0..1) =====
        private double _tyreFL;
        private double _tyreFR;
        private double _tyreRL;
        private double _tyreRR;
        private double _tyreFront;
        private double _tyreRear;
        private double _tyresAll;
        private bool _tyresInitialized;

        // ===== Road / body motion (0..1, for haptics) =====
        private double _surgeNorm;
        private double _swayNorm;
        private double _heaveNorm;
        private bool _roadInitialized;

        // ===== Slip (per wheel raw & per-axle learned) =====
        // Raw, multi-source, smoothed 0..1 per wheel
        private double _slipFL, _slipFR, _slipRL, _slipRR;

        // Learner state for front axle
        private double _slipBaseFront;
        private double _slipMaxFront;
        private double _slipEnvFront;
        private double _slipDriveFront;
        private double _slipLastSpinFront;
        private double _slipJitterFront;

        // Learner state for rear axle
        private double _slipBaseRear;
        private double _slipMaxRear;
        private double _slipEnvRear;
        private double _slipDriveRear;
        private double _slipLastSpinRear;
        private double _slipJitterRear;

        // Exposed learned intensities
        private double _slipFrontIntensity;
        private double _slipRearIntensity;

        // ===== Engine & tyres envelopes (front / rear) =====
        // These are what SimHub will use for the Engine & Tyres effect
        private double _engTyresFrontEnv;
        private double _engTyresRearEnv;
        private double _engTyresFrontExitEnv;
        private double _engTyresRearExitEnv;
        private double _engTyresFrontPrevSlip;
        private double _engTyresRearPrevSlip;
        private double _engTyresFront;
        private double _engTyresRear;

        // ===== Tyre scrub (front / rear) =====
        private double _scrubFrontEnv;
        private double _scrubRearEnv;
        private double _steerLast;
        private double _steerMax = 45.0; // degrees, adaptive
        private double _steerRangeTracker = 0.0; // for auto-detecting normalised steering

        // ===== Road feel (front / rear) =====
        private double _roadFeelFront;
        private double _roadFeelRear;

        // ===== Suspension / contact patch scaffolding =====
        private bool _suspInitialized;
        private double _suspFLPrev, _suspFRPrev, _suspRLPrev, _suspRRPrev;
        private double _suspFLDelta, _suspFRDelta, _suspRLDelta, _suspRRDelta;
        private double _suspFLIntensity, _suspFRIntensity, _suspRLIntensity, _suspRRIntensity;
        private double _suspVibrationFront, _suspVibrationRear;
        private double _suspImpactFront, _suspImpactRear;

        // ===== Surface / grip learners =====
        private double _surfaceGrain;
        private double _surfaceHarshness;
        private double _surfaceImpactBias;
        private double _suspLoadFrontEnv;
        private double _suspLoadRearEnv;
        private double _gripBudgetFront;
        private double _gripBudgetRear;

        // ===== Brake feel / lock (front / rear) =====
        private double _brakeFeelFront;
        private double _brakeFeelRear;
        private double _brakeLockFront;
        private double _brakeLockRear;

        // ===== Brake n Slip (hybrid brake + slip, front / rear) =====
        private double _brakeNSlipFront;
        private double _brakeNSlipRear;

        // ===== Traction activity (front / rear) =====
        private double _tcFrontEnv;
        private double _tcRearEnv;

        // ===== Clutch freewheel / kick =====
        private double _clutchFreeEnv;
        private double _lastRpmNorm;

        // ===== Motion DOFs (signed, -1..1) =====
        private double _motionSurge;
        private double _motionSway;
        private double _motionHeave;

        // ===== Gearshift scaffolding =====
        private int _lastGear = int.MinValue;
        private double _gearShiftEnv;
        private double _gearShiftFwdKick;
        private double _gearShiftBackKick;
        private double _gearShiftGrindEnv;
        private double _gearGrindWindow;

        // ===== Misc =====
        private string _currentGameId = "";

        public string Name => "MCP4SH";

        public void Init(PluginManager pluginManager)
        {
            PluginManager = pluginManager;

            // --- Engine / car ---
            this.AttachDelegate("MCP4SH.Engine.RpmNorm", () => _rpmNorm);
            this.AttachDelegate("MCP4SH.Engine.Throttle", () => _throttle);
            this.AttachDelegate("MCP4SH.Engine.Brake", () => _brake);
            this.AttachDelegate("MCP4SH.Car.SpeedNorm", () => _speedNorm);

            // --- Tyres (temps → intensity) ---
            this.AttachDelegate("MCP4SH.Tyres.FL.Intensity", () => _tyreFL);
            this.AttachDelegate("MCP4SH.Tyres.FR.Intensity", () => _tyreFR);
            this.AttachDelegate("MCP4SH.Tyres.RL.Intensity", () => _tyreRL);
            this.AttachDelegate("MCP4SH.Tyres.RR.Intensity", () => _tyreRR);
            this.AttachDelegate("MCP4SH.Tyres.Front.Intensity", () => _tyreFront);
            this.AttachDelegate("MCP4SH.Tyres.Rear.Intensity", () => _tyreRear);
            this.AttachDelegate("MCP4SH.Tyres.All.Intensity", () => _tyresAll);

            // --- Road / body motion (haptics-friendly, 0..1, abs(G)) ---
            this.AttachDelegate("MCP4SH.Road.SurgeNorm", () => _surgeNorm);
            this.AttachDelegate("MCP4SH.Road.SwayNorm", () => _swayNorm);
            this.AttachDelegate("MCP4SH.Road.HeaveNorm", () => _heaveNorm);

            // --- Motion-friendly DOFs (rigs, signed -1..1) ---
            this.AttachDelegate("MCP4SH.Motion.Surge", () => _motionSurge);
            this.AttachDelegate("MCP4SH.Motion.Sway", () => _motionSway);
            this.AttachDelegate("MCP4SH.Motion.Heave", () => _motionHeave);
            this.AttachDelegate("MCP4SH.Motion.Pitch", () => 0.0);
            this.AttachDelegate("MCP4SH.Motion.Roll", () => 0.0);

            // --- Slip (per wheel raw + per-axle learned) ---
            this.AttachDelegate("MCP4SH.Slip.FL", () => _slipFL);
            this.AttachDelegate("MCP4SH.Slip.FR", () => _slipFR);
            this.AttachDelegate("MCP4SH.Slip.RL", () => _slipRL);
            this.AttachDelegate("MCP4SH.Slip.RR", () => _slipRR);

            this.AttachDelegate("MCP4SH.Slip.Front.Intensity", () => _slipFrontIntensity);
            this.AttachDelegate("MCP4SH.Slip.Rear.Intensity", () => _slipRearIntensity);

            // --- Engine & tyres (front / rear) 0..1 ---
            this.AttachDelegate("MCP4SH.EngineTyres.FrontIntensity",
                   () => Clamp01(_engTyresFront * EngineTyresGain * GlobalGain));
            this.AttachDelegate("MCP4SH.EngineTyres.RearIntensity",
                () => Clamp01(_engTyresRear * EngineTyresGain * GlobalGain));


            // --- Tyre scrub (front / rear) 0..1 ---
            this.AttachDelegate("MCP4SH.TyreScrub.FrontIntensity", () => _scrubFrontEnv);
            this.AttachDelegate("MCP4SH.TyreScrub.RearIntensity", () => _scrubRearEnv);

            // --- Road feel (front / rear) 0..1 ---
            this.AttachDelegate("MCP4SH.RoadFeel.FrontIntensity",
                () => Clamp01(_roadFeelFront * RoadFeelGain * GlobalGain));
            this.AttachDelegate("MCP4SH.RoadFeel.RearIntensity",
                () => Clamp01(_roadFeelRear * RoadFeelGain * GlobalGain));

            // --- Suspension (per corner + front/rear envelopes) ---
            this.AttachDelegate("MCP4SH.Suspension.FL", () => _suspFLIntensity);
            this.AttachDelegate("MCP4SH.Suspension.FR", () => _suspFRIntensity);
            this.AttachDelegate("MCP4SH.Suspension.RL", () => _suspRLIntensity);
            this.AttachDelegate("MCP4SH.Suspension.RR", () => _suspRRIntensity);
            this.AttachDelegate("MCP4SH.Suspension.VibrationFront",
                () => Clamp01(_suspVibrationFront * SuspensionVibrationGain * GlobalGain));
            this.AttachDelegate("MCP4SH.Suspension.VibrationRear",
                () => Clamp01(_suspVibrationRear * SuspensionVibrationGain * GlobalGain));
            this.AttachDelegate("MCP4SH.Suspension.ImpactFront",
                () => Clamp01(_suspImpactFront * SuspensionImpactGain * GlobalGain));
            this.AttachDelegate("MCP4SH.Suspension.ImpactRear",
                () => Clamp01(_suspImpactRear * SuspensionImpactGain * GlobalGain));

            // --- Surface / grip learners ---
            this.AttachDelegate("MCP4SH.Surface.Grain", () => _surfaceGrain);
            this.AttachDelegate("MCP4SH.Surface.Harshness", () => _surfaceHarshness);
            this.AttachDelegate("MCP4SH.Surface.ImpactBias", () => _surfaceImpactBias);
            this.AttachDelegate("MCP4SH.Suspension.Front.LoadEnv", () => _suspLoadFrontEnv);
            this.AttachDelegate("MCP4SH.Suspension.Rear.LoadEnv", () => _suspLoadRearEnv);
            this.AttachDelegate("MCP4SH.GripBudget.Front", () => _gripBudgetFront);
            this.AttachDelegate("MCP4SH.GripBudget.Rear", () => _gripBudgetRear);

            // --- Brake feel / lock (front / rear) 0..1 ---
            this.AttachDelegate("MCP4SH.BrakeFeel.FrontIntensity",
                () => Clamp01(_brakeFeelFront * BrakeFeelGain * GlobalGain));
            this.AttachDelegate("MCP4SH.BrakeFeel.RearIntensity",
                () => Clamp01(_brakeFeelRear * BrakeFeelGain * GlobalGain));
            this.AttachDelegate("MCP4SH.BrakeLock.FrontIntensity",
                () => Clamp01(_brakeLockFront * ABSGain * GlobalGain));
            this.AttachDelegate("MCP4SH.BrakeLock.RearIntensity",
                () => Clamp01(_brakeLockRear * ABSGain * GlobalGain));

            // --- Brake n Slip (hybrid) 0..1 ---
            this.AttachDelegate("MCP4SH.BrakeNSlip.FrontIntensity",
                () => Clamp01(_brakeNSlipFront * BrakeNSlipGain * GlobalGain));
            this.AttachDelegate("MCP4SH.BrakeNSlip.RearIntensity",
                () => Clamp01(_brakeNSlipRear * BrakeNSlipGain * GlobalGain));

            // --- Traction activity (front / rear) 0..1 ---
            this.AttachDelegate("MCP4SH.TC.FrontActivity",
                () => Clamp01(_tcFrontEnv * TCGain * GlobalGain));
            this.AttachDelegate("MCP4SH.TC.RearActivity",
                () => Clamp01(_tcRearEnv * TCGain * GlobalGain));

            // --- Clutch freewheel 0..1 ---
            this.AttachDelegate("MCP4SH.Drivetrain.ClutchFreeIntensity",
                () => Clamp01(_clutchFreeEnv * ClutchFreeGain * GlobalGain));

            // --- Gearshift outputs (scaffolding) ---
            this.AttachDelegate("MCP4SH.GearShift.Intensity",
                () => Clamp01(_gearShiftEnv * GearshiftGain * GlobalGain));
            this.AttachDelegate("MCP4SH.GearShift.GrindIntensity",
                () => Clamp01(_gearShiftGrindEnv * GearshiftGain * GlobalGain));
            this.AttachDelegate("MCP4SH.GearShift.FwdKick",
                () => Clamp01(_gearShiftFwdKick * GearshiftGain * GlobalGain));
            this.AttachDelegate("MCP4SH.GearShift.BackKick",
                () => Clamp01(_gearShiftBackKick * GearshiftGain * GlobalGain));
        }

        public void End(PluginManager pluginManager)
        {
            // Nothing special to clean up
        }

        public void DataUpdate(PluginManager pluginManager, ref GameData data)
        {
            if (!data.GameRunning || data.NewData == null) return;

            var gd = data.NewData;
            var pm = pluginManager;

            // ===== Determine game id (string only, for future use / debugging) =====
            string gameId = ReadString(pm, "DataCorePlugin.CurrentGame");
            if (!string.IsNullOrEmpty(gameId))
            {
                _currentGameId = gameId;
            }
            else
            {
                gameId = _currentGameId;
            }

            // ===== Engine / car basics =====

            double rpm = gd.Rpms;
            double maxRpm = gd.MaxRpm > 0 ? gd.MaxRpm : 9000.0;
            _rpmNorm = Clamp01(rpm / maxRpm);

            double speedKmh = gd.SpeedKmh;
            _speedNorm = Clamp01(speedKmh / 350.0);

            _throttle = Clamp01(gd.Throttle);
            _brake = Clamp01(gd.Brake);

            // ===== Tyre temps → intensities (0..1) =====

            double tFL = gd.TyreTemperatureFrontLeft;
            double tFR = gd.TyreTemperatureFrontRight;
            double tRL = gd.TyreTemperatureRearLeft;
            double tRR = gd.TyreTemperatureRearRight;

            double tyreFL_raw = NormalizeRange(tFL, 50.0, 110.0);
            double tyreFR_raw = NormalizeRange(tFR, 50.0, 110.0);
            double tyreRL_raw = NormalizeRange(tRL, 50.0, 110.0);
            double tyreRR_raw = NormalizeRange(tRR, 50.0, 110.0);

            double tyreFront_raw = 0.5 * (tyreFL_raw + tyreFR_raw);
            double tyreRear_raw = 0.5 * (tyreRL_raw + tyreRR_raw);
            double tyresAll_raw = 0.25 * (tyreFL_raw + tyreFR_raw + tyreRL_raw + tyreRR_raw);

            double tyreAlpha = 0.30;

            if (!_tyresInitialized)
            {
                _tyreFL = tyreFL_raw;
                _tyreFR = tyreFR_raw;
                _tyreRL = tyreRL_raw;
                _tyreRR = tyreRR_raw;
                _tyreFront = tyreFront_raw;
                _tyreRear = tyreRear_raw;
                _tyresAll = tyresAll_raw;
                _tyresInitialized = true;
            }
            else
            {
                _tyreFL = Smooth(_tyreFL, tyreFL_raw, tyreAlpha);
                _tyreFR = Smooth(_tyreFR, tyreFR_raw, tyreAlpha);
                _tyreRL = Smooth(_tyreRL, tyreRL_raw, tyreAlpha);
                _tyreRR = Smooth(_tyreRR, tyreRR_raw, tyreAlpha);

                _tyreFront = Smooth(_tyreFront, tyreFront_raw, tyreAlpha);
                _tyreRear = Smooth(_tyreRear, tyreRear_raw, tyreAlpha);
                _tyresAll = Smooth(_tyresAll, tyresAll_raw, tyreAlpha);
            }

            // ===== Road / body motion =====

            double surgeRaw = ReadDouble(pm, "DataCorePlugin.GameData.Surge");
            double swayRaw = ReadDouble(pm, "DataCorePlugin.GameData.Sway");
            double heaveRaw = ReadDouble(pm, "DataCorePlugin.GameData.Heave");

            double surgeNorm_raw = Clamp01(Math.Abs(surgeRaw) / 3.0);
            double swayNorm_raw = Clamp01(Math.Abs(swayRaw) / 3.0);
            double heaveNorm_raw = Clamp01(Math.Abs(heaveRaw) / 3.0);

            double roadAlpha = 0.30;

            if (!_roadInitialized)
            {
                _surgeNorm = surgeNorm_raw;
                _swayNorm = swayNorm_raw;
                _heaveNorm = heaveNorm_raw;
                _roadInitialized = true;
            }
            else
            {
                _surgeNorm = Smooth(_surgeNorm, surgeNorm_raw, roadAlpha);
                _swayNorm = Smooth(_swayNorm, swayNorm_raw, roadAlpha);
                _heaveNorm = Smooth(_heaveNorm, heaveNorm_raw, roadAlpha);
            }

            double motionSurgeRaw = Math.Max(-1.0, Math.Min(1.0, surgeRaw / 3.0));
            double motionSwayRaw = Math.Max(-1.0, Math.Min(1.0, swayRaw / 3.0));
            double motionHeaveRaw = Math.Max(-1.0, Math.Min(1.0, heaveRaw / 3.0));

            _motionSurge = Smooth(_motionSurge, motionSurgeRaw, 0.45);
            _motionSway = Smooth(_motionSway, motionSwayRaw, 0.45);
            _motionHeave = Smooth(_motionHeave, motionHeaveRaw, 0.45);

            // ===== Suspension travel / contact patch scaffolding =====

            // Primary: suspension travel (works in most sims)
            double suspFLraw = ReadDouble(pm, "DataCorePlugin.GameRawData.Physics.SuspensionTravelFL");
            double suspFRraw = ReadDouble(pm, "DataCorePlugin.GameRawData.Physics.SuspensionTravelFR");
            double suspRLraw = ReadDouble(pm, "DataCorePlugin.GameRawData.Physics.SuspensionTravelRL");
            double suspRRraw = ReadDouble(pm, "DataCorePlugin.GameRawData.Physics.SuspensionTravelRR");

            // Secondary: damper velocity (when the sim exposes it – AC/ACC/AMS2/BeamNG/etc.)
            double dampFLraw = ReadDouble(pm, "DataCorePlugin.GameRawData.Physics.SuspensionVelocityFL");
            double dampFRraw = ReadDouble(pm, "DataCorePlugin.GameRawData.Physics.SuspensionVelocityFR");
            double dampRLraw = ReadDouble(pm, "DataCorePlugin.GameRawData.Physics.SuspensionVelocityRL");
            double dampRRraw = ReadDouble(pm, "DataCorePlugin.GameRawData.Physics.SuspensionVelocityRR");

            if (!_suspInitialized)
            {
                _suspFLPrev = suspFLraw;
                _suspFRPrev = suspFRraw;
                _suspRLPrev = suspRLraw;
                _suspRRPrev = suspRRraw;
                _suspInitialized = true;
            }

            // Travel deltas (primary signal)
            double dFL = suspFLraw - _suspFLPrev;
            double dFR = suspFRraw - _suspFRPrev;
            double dRL = suspRLraw - _suspRLPrev;
            double dRR = suspRRraw - _suspRRPrev;

            _suspFLPrev = suspFLraw;
            _suspFRPrev = suspFRraw;
            _suspRLPrev = suspRLraw;
            _suspRRPrev = suspRRraw;

            // Absolute travel
            double absFL = Math.Abs(dFL);
            double absFR = Math.Abs(dFR);
            double absRL = Math.Abs(dRL);
            double absRR = Math.Abs(dRR);

            // Absolute damper velocities (secondary signal).
            double dampAbsFL = Math.Abs(dampFLraw);
            double dampAbsFR = Math.Abs(dampFRraw);
            double dampAbsRL = Math.Abs(dampRLraw);
            double dampAbsRR = Math.Abs(dampRRraw);

            // Scale factors:
            // - suspDeltaScale:  travel  ~0.00–0.10 m deltas → 0..1
            // - dampScale:       damper  ~0.00–0.25 m/s      → 0..1 (tuned for typical sims)
            const double suspDeltaScale = 8.0;
            const double dampScale = 4.0;

            // Normalised per-wheel travel & damper components
            double flTravelN = Clamp01(absFL * suspDeltaScale);
            double frTravelN = Clamp01(absFR * suspDeltaScale);
            double rlTravelN = Clamp01(absRL * suspDeltaScale);
            double rrTravelN = Clamp01(absRR * suspDeltaScale);

            double flDampN = Clamp01(dampAbsFL * dampScale);
            double frDampN = Clamp01(dampAbsFR * dampScale);
            double rlDampN = Clamp01(dampAbsRL * dampScale);
            double rrDampN = Clamp01(dampAbsRR * dampScale);

            // Adaptive damper weight: if damper channels are basically dead, they fade out.
            double frontDamperPresence = Clamp01(0.5 * (flDampN + frDampN));
            double rearDamperPresence = Clamp01(0.5 * (rlDampN + rrDampN));

            // Up to +70% extra contribution from damper when it is clearly active.
            double frontDamperWeight = Lerp(0.0, 0.7, frontDamperPresence);
            double rearDamperWeight = Lerp(0.0, 0.7, rearDamperPresence);

            // Per-wheel hybrid intensities (travel primary, damper secondary).
            double flHybrid = Clamp01(flTravelN + flDampN * frontDamperWeight);
            double frHybrid = Clamp01(frTravelN + frDampN * frontDamperWeight);
            double rlHybrid = Clamp01(rlTravelN + rlDampN * rearDamperWeight);
            double rrHybrid = Clamp01(rrTravelN + rrDampN * rearDamperWeight);

            // Store deltas (raw travel) for any future debug / usage.
            _­suspFLDelta = absFL;
            _­suspFRDelta = absFR;
            _­suspRLDelta = absRL;
            _­suspRRDelta = absRR;

            // Corner intensities (for per-corner effects / debug)
            _suspFLIntensity = Smooth(_suspFLIntensity, flHybrid, 0.50);
            _suspFRIntensity = Smooth(_suspFRIntensity, frHybrid, 0.50);
            _suspRLIntensity = Smooth(_suspRLIntensity, rlHybrid, 0.50);
            _suspRRIntensity = Smooth(_suspRRIntensity, rrHybrid, 0.50);

            // ===== Suspension vibrations (front / rear) – hybrid, adaptive weighting =====

            // Axle-wise averages for vibrations.
            double frontTravelN = Clamp01(0.5 * (absFL + absFR) * suspDeltaScale);
            double rearTravelN = Clamp01(0.5 * (absRL + absRR) * suspDeltaScale);

            double frontDampN = Clamp01(0.5 * (dampAbsFL + dampAbsFR) * dampScale);
            double rearDampN = Clamp01(0.5 * (dampAbsRL + dampAbsRR) * dampScale);

            // Re-use presence / weights at axle level.
            frontDamperPresence = Clamp01(frontDampN);
            rearDamperPresence = Clamp01(rearDampN);

            frontDamperWeight = Lerp(0.0, 0.7, frontDamperPresence);
            rearDamperWeight = Lerp(0.0, 0.7, rearDamperPresence);

            // Hybrid axle vibrations: travel is always “1.0”, damper adds up to +0.7.
            double vibFrontRaw = Clamp01(frontTravelN + frontDampN * frontDamperWeight);
            double vibRearRaw = Clamp01(rearTravelN + rearDampN * rearDamperWeight);

            // Slight speed bias: at very low speed, mute suspension vibrations.
            double suspSpeedGate = Clamp01((_speedNorm - 0.01) / 0.10);
            vibFrontRaw *= suspSpeedGate;
            vibRearRaw *= suspSpeedGate;

            // Envelope + mild decay.
            _suspVibrationFront = Smooth(_suspVibrationFront, vibFrontRaw, 0.45);
            _suspVibrationRear = Smooth(_suspVibrationRear, vibRearRaw, 0.45);

            _suspVibrationFront *= 0.97;
            _suspVibrationRear *= 0.97;

            if (_suspVibrationFront < 0.001) _suspVibrationFront = 0.0;
            if (_suspVibrationRear < 0.001) _suspVibrationRear = 0.0;


            // ===== Suspension impacts (front / rear) – hybrid spike detection =====

            // Travel-based spike (as before, but explicit normalisation)
            const double impactTravelThreshold = 0.06;
            const double impactTravelRange = 0.18;

            double frontDeltaTravel = 0.5 * (absFL + absFR);
            double rearDeltaTravel = 0.5 * (absRL + absRR);

            double travelImpactFront = 0.0;
            double travelImpactRear = 0.0;

            if (frontDeltaTravel > impactTravelThreshold)
                travelImpactFront = Clamp01((frontDeltaTravel - impactTravelThreshold) / impactTravelRange);

            if (rearDeltaTravel > impactTravelThreshold)
                travelImpactRear = Clamp01((rearDeltaTravel - impactTravelThreshold) / impactTravelRange);

            // Damper-based spike – tuned for “big hits”, not general noise.
            const double impactDampThreshold = 0.20;
            const double impactDampRange = 0.80;

            double frontDeltaDamp = 0.5 * (dampAbsFL + dampAbsFR);
            double rearDeltaDamp = 0.5 * (dampAbsRL + dampAbsRR);

            double dampImpactFront = 0.0;
            double dampImpactRear = 0.0;

            if (frontDeltaDamp > impactDampThreshold)
                dampImpactFront = Clamp01((frontDeltaDamp - impactDampThreshold) / impactDampRange);

            if (rearDeltaDamp > impactDampThreshold)
                dampImpactRear = Clamp01((rearDeltaDamp - impactDampThreshold) / impactDampRange);

            // Hybrid C: "either" travel OR damper can trigger an impact.
            double impactFrontRaw = Math.Max(travelImpactFront, dampImpactFront);
            double impactRearRaw = Math.Max(travelImpactRear, dampImpactRear);

            // Speed gate: no impacts when basically stopped.
            double impactSpeedGate = Clamp01((_speedNorm - 0.01) / 0.06);
            impactFrontRaw *= impactSpeedGate;
            impactRearRaw *= impactSpeedGate;

            // Envelope + strong decay → acts as a built-in cooldown (no machine-gun spam).
            _suspImpactFront = Smooth(_suspImpactFront, impactFrontRaw, 0.65);
            _suspImpactRear = Smooth(_suspImpactRear, impactRearRaw, 0.65);

            _suspImpactFront *= 0.82;
            _suspImpactRear *= 0.82;

            if (_suspImpactFront < 0.001) _suspImpactFront = 0.0;
            if (_suspImpactRear < 0.001) _suspImpactRear = 0.0;


            // ===== Slip per wheel – multi-source, game-agnostic, with learners =====

            // 1) Viper longitudinal slip (0..~1+) – best quality when present
            double vFL = Math.Abs(ReadDouble(pm, "ViperDataPlugin.CalcLngWheelSlip.Computed.LngWheelSlip_FL"));
            double vFR = Math.Abs(ReadDouble(pm, "ViperDataPlugin.CalcLngWheelSlip.Computed.LngWheelSlip_FR"));
            double vRL = Math.Abs(ReadDouble(pm, "ViperDataPlugin.CalcLngWheelSlip.Computed.LngWheelSlip_RL"));
            double vRR = Math.Abs(ReadDouble(pm, "ViperDataPlugin.CalcLngWheelSlip.Computed.LngWheelSlip_RR"));

            // 2) Raw game slip channels (semantics vary by sim)
            double gFL = Math.Abs(ReadDouble(pm, "DataCorePlugin.GameRawData.Physics.WheelSlip01"));
            double gFR = Math.Abs(ReadDouble(pm, "DataCorePlugin.GameRawData.Physics.WheelSlip02"));
            double gRL = Math.Abs(ReadDouble(pm, "DataCorePlugin.GameRawData.Physics.WheelSlip03"));
            double gRR = Math.Abs(ReadDouble(pm, "DataCorePlugin.GameRawData.Physics.WheelSlip04"));

            // 3) Wheel angular speed (rad/s or similar) – generic physics
            double waFL = Math.Abs(ReadDouble(pm, "DataCorePlugin.GameRawData.Physics.WheelAngularSpeed01"));
            double waFR = Math.Abs(ReadDouble(pm, "DataCorePlugin.GameRawData.Physics.WheelAngularSpeed02"));
            double waRL = Math.Abs(ReadDouble(pm, "DataCorePlugin.GameRawData.Physics.WheelAngularSpeed03"));
            double waRR = Math.Abs(ReadDouble(pm, "DataCorePlugin.GameRawData.Physics.WheelAngularSpeed04"));

            double waAvg = (waFL + waFR + waRL + waRR) * 0.25;
            double waAvgSafe = Math.Max(waAvg, 1.0);

            const double angularDeviationScale = 0.6; // 60% faster/slower than avg → slip ~1
            double aFL = Math.Abs(waFL - waAvg) / (waAvgSafe * angularDeviationScale);
            double aFR = Math.Abs(waFR - waAvg) / (waAvgSafe * angularDeviationScale);
            double aRL = Math.Abs(waRL - waAvg) / (waAvgSafe * angularDeviationScale);
            double aRR = Math.Abs(waRR - waAvg) / (waAvgSafe * angularDeviationScale);

            // 4) Wheel linear speed vs car speed (km/h) – where available
            double wsFL = Math.Abs(ReadDouble(pm, "DataCorePlugin.GameRawData.Physics.WheelSpeed01"));
            double wsFR = Math.Abs(ReadDouble(pm, "DataCorePlugin.GameRawData.Physics.WheelSpeed02"));
            double wsRL = Math.Abs(ReadDouble(pm, "DataCorePlugin.GameRawData.Physics.WheelSpeed03"));
            double wsRR = Math.Abs(ReadDouble(pm, "DataCorePlugin.GameRawData.Physics.WheelSpeed04"));

            double speedRawKmh = speedKmh;
            if (speedRawKmh <= 0.0)
            {
                speedRawKmh = ReadDouble(pm, "DataCorePlugin.GameRawData.Physics.SpeedKmh", 0.0);
            }

            const double speedDeviationRange = 40.0; // 40 km/h diff → slip ~1
            double sFL = (wsFL > 0.01 && speedRawKmh > 0.01)
                ? Math.Abs(wsFL - speedRawKmh) / speedDeviationRange
                : 0.0;
            double sFR = (wsFR > 0.01 && speedRawKmh > 0.01)
                ? Math.Abs(wsFR - speedRawKmh) / speedDeviationRange
                : 0.0;
            double sRL = (wsRL > 0.01 && speedRawKmh > 0.01)
                ? Math.Abs(wsRL - speedRawKmh) / speedDeviationRange
                : 0.0;
            double sRR = (wsRR > 0.01 && speedRawKmh > 0.01)
                ? Math.Abs(wsRR - speedRawKmh) / speedDeviationRange
                : 0.0;

            // Normalize/scale direct slip channels; clamp to avoid insane values
            const double viperScale = 1.2;
            const double rawSlipScale = 1.0;

            double vFLn = Math.Min(vFL * viperScale, 1.5);
            double vFRn = Math.Min(vFR * viperScale, 1.5);
            double vRLn = Math.Min(vRL * viperScale, 1.5);
            double vRRn = Math.Min(vRR * viperScale, 1.5);

            double gFLn = Math.Min(gFL * rawSlipScale, 1.5);
            double gFRn = Math.Min(gFR * rawSlipScale, 1.5);
            double gRLn = Math.Min(gRL * rawSlipScale, 1.5);
            double gRRn = Math.Min(gRR * rawSlipScale, 1.5);

            // Combine all sources per wheel: best-of (max) approach
            double slipFL_raw = Max4(aFL, sFL, vFLn, gFLn);
            double slipFR_raw = Max4(aFR, sFR, vFRn, gFRn);
            double slipRL_raw = Max4(aRL, sRL, vRLn, gRLn);
            double slipRR_raw = Max4(aRR, sRR, vRRn, gRRn);

            // Smoothed per-wheel raw slip (for debugging / future per-corner use)
            double slipAlphaWheel = 0.5;
            _slipFL = Smooth(_slipFL, Clamp01(slipFL_raw), slipAlphaWheel);
            _slipFR = Smooth(_slipFR, Clamp01(slipFR_raw), slipAlphaWheel);
            _slipRL = Smooth(_slipRL, Clamp01(slipRL_raw), slipAlphaWheel);
            _slipRR = Smooth(_slipRR, Clamp01(slipRR_raw), slipAlphaWheel);

            // Per-axle spin for learners (average of both wheels)
            double frontSpin = 0.5 * (slipFL_raw + slipFR_raw);
            double rearSpin = 0.5 * (slipRL_raw + slipRR_raw);

            // Axle dominance (for biasing in learner / engine&tyres)
            bool frontDom = false;
            bool rearDom = false;
            if (frontSpin > rearSpin * 1.2) frontDom = true;
            else if (rearSpin > frontSpin * 1.2) rearDom = true;

            // Burnout-ish detection (low speed, throttle, big slip)
            bool isBurnout = false;
            if (speedKmh < 20.0 && _throttle > 0.40 && (frontSpin > 0.35 || rearSpin > 0.35))
            {
                isBurnout = true;
            }

            // ===== Slip learners (front / rear) =====

            UpdateSlipForAxle(
                frontSpin,
                ref _slipBaseFront,
                ref _slipMaxFront,
                ref _slipEnvFront,
                ref _slipDriveFront,
                ref _slipLastSpinFront,
                ref _slipJitterFront,
                frontDom,
                rearDom,
                isBurnout,
                _rpmNorm,
                _throttle
            );

            UpdateSlipForAxle(
                rearSpin,
                ref _slipBaseRear,
                ref _slipMaxRear,
                ref _slipEnvRear,
                ref _slipDriveRear,
                ref _slipLastSpinRear,
                ref _slipJitterRear,
                rearDom,
                frontDom,
                isBurnout,
                _rpmNorm,
                _throttle
            );

            _slipFrontIntensity = _slipDriveFront;
            _slipRearIntensity = _slipDriveRear;


            // ===== Brake feel / ABS-ish lock (front / rear) =====

            // Raw pedal, clamped.
            double brakeN = _brake;   // 0..1 pedal
            if (brakeN < 0.0) brakeN = 0.0;
            if (brakeN > 1.0) brakeN = 1.0;

            // Raw envelopes (before smoothing).
            double brakeFront_raw = 0.0;
            double brakeRear_raw = 0.0;
            double lockFront_raw = 0.0;
            double lockRear_raw = 0.0;
            double brakeNSlipFront_raw = 0.0;
            double brakeNSlipRear_raw = 0.0;

            // Only consider braking when pedal and speed are meaningful.
            bool brakingPhase = (brakeN > 0.02 && speedKmh > 5.0);

            if (brakingPhase)
            {
                // --- Base pedal curve (what you feel as pure "brake feel") ---
                //
                // We keep a deep low-end resolution and reserve the top of the curve
                // for hard braking. This is the curve that finally felt "right" to you.
                //
                // 0.02..1.0 pedal -> 0..1 then shaped.
                double t = (brakeN - 0.02) / 0.98;  // 0..1
                if (t < 0.0) t = 0.0;
                if (t > 1.0) t = 1.0;

                // Exponent > 1 gives the curve you want: gentle low, aggressive high.
                double brakeBase = Math.Pow(t, 1.8);

                // Small trim so we keep a bit of headroom.
                brakeBase = Clamp01(brakeBase * 0.97);

                brakeFront_raw = brakeBase;
                brakeRear_raw = brakeBase;

                // --- Slip contribution (same family as SimHub's wheel lock) ---
                double slipF_brake = Clamp01(_slipFrontIntensity);
                double slipR_brake = Clamp01(_slipRearIntensity);

                // Gate slip by brake and speed so it only matters when you are really braking at speed.
                double slipBrakeGate = Clamp01((brakeN - 0.30) / 0.50);  // 0 below ~30%, 1 by ~80%+
                double slipSpeedGate = Clamp01((speedKmh - 20.0) / 80.0);  // 0 below 20 km/h, 1 by ~100 km/h

                // Shape slip so that mid/high slip matters most.
                double slipShapeF = 0.0;
                double slipShapeR = 0.0;

                if (slipF_brake > 0.20)
                {
                    double s = (slipF_brake - 0.20) / 0.80;  // 0.20..1.0 -> 0..1
                    s = Clamp01(s);
                    slipShapeF = Math.Pow(s, 1.8);
                }

                if (slipR_brake > 0.20)
                {
                    double s = (slipR_brake - 0.20) / 0.80;
                    s = Clamp01(s);
                    slipShapeR = Math.Pow(s, 1.8);
                }

                // How much slip is allowed to boost brake feel.
                const double slipWeight = 0.65;

                double slipBoostF = slipWeight * slipBrakeGate * slipSpeedGate * slipShapeF;
                double slipBoostR = slipWeight * slipBrakeGate * slipSpeedGate * slipShapeR;

                // Final brake-pedal-based envelope (what you currently feel as "Brake feel").
                brakeFront_raw = Clamp01(brakeFront_raw + slipBoostF);
                brakeRear_raw = Clamp01(brakeRear_raw + slipBoostR);

                // --- Hybrid "Brake n Slip" envelope (brakenslip) ---
                //
                // Idea:
                //   - Keep it tied to your pedal (same base curve).
                //   - Let real slip lift it when you're on the edge.
                //
                // Focus slip where:
                //   - you are actually braking (slipBrakeGate)
                //   - at sensible speed (slipSpeedGate)
                //   - with mid/high slip (slipShapeX)
                double slipFocusF = slipBrakeGate * slipSpeedGate * slipShapeF;
                double slipFocusR = slipBrakeGate * slipSpeedGate * slipShapeR;

                // 55% pedal, 45% slip focus.
                // This keeps the hybrid tightly coupled to your foot, but lets real slip talk clearly.
                double hybridFront = Clamp01(0.55 * brakeBase + 0.45 * slipFocusF);
                double hybridRear = Clamp01(0.55 * brakeBase + 0.45 * slipFocusR);

                brakeNSlipFront_raw = hybridFront;
                brakeNSlipRear_raw = hybridRear;

                // --- ABS / lock envelope from slip ONLY (still your separate ABS effect) ---
                const double lockStart = 0.78;   // where ABS/lock begins
                const double lockRange = 0.17;   // 0.78..0.95 -> 0..1

                if (brakeN > 0.40 && speedKmh > 20.0)
                {
                    double frontExcess = slipF_brake - lockStart;
                    double rearExcess = slipR_brake - lockStart;

                    if (frontExcess > 0.0)
                        lockFront_raw = Clamp01(frontExcess / lockRange) * brakeBase;

                    if (rearExcess > 0.0)
                        lockRear_raw = Clamp01(rearExcess / lockRange) * brakeBase;
                }

                lockFront_raw = Clamp01(lockFront_raw * 1.3);
                lockRear_raw = Clamp01(lockRear_raw * 1.3);
            }
            else
            {
                brakeFront_raw = 0.0;
                brakeRear_raw = 0.0;
                lockFront_raw = 0.0;
                lockRear_raw = 0.0;
                brakeNSlipFront_raw = 0.0;
                brakeNSlipRear_raw = 0.0;
            }

            // Hard low-speed guard – no brake feel or ABS when crawling.
            if (speedKmh < 2.0)
            {
                brakeFront_raw = 0.0;
                brakeRear_raw = 0.0;
                lockFront_raw = 0.0;
                lockRear_raw = 0.0;
                brakeNSlipFront_raw = 0.0;
                brakeNSlipRear_raw = 0.0;
            }

            // ---- Rate limit: cap how fast brake feel can ramp UP per update ----
            // This makes the effect feel progressive even if the game or pedals jump.
            const double maxBrakeStepUp = 0.03; // Brake Feel
            const double maxBrakeNSlipStepUp = 0.05; // Hybrid allowed to be a bit snappier

            if (brakeFront_raw > _brakeFeelFront + maxBrakeStepUp)
                brakeFront_raw = _brakeFeelFront + maxBrakeStepUp;

            if (brakeRear_raw > _brakeFeelRear + maxBrakeStepUp)
                brakeRear_raw = _brakeFeelRear + maxBrakeStepUp;

            if (brakeNSlipFront_raw > _brakeNSlipFront + maxBrakeNSlipStepUp)
                brakeNSlipFront_raw = _brakeNSlipFront + maxBrakeNSlipStepUp;

            if (brakeNSlipRear_raw > _brakeNSlipRear + maxBrakeNSlipStepUp)
                brakeNSlipRear_raw = _brakeNSlipRear + maxBrakeNSlipStepUp;

            // ---- Envelopes / damping ----
            _brakeFeelFront = Smooth(_brakeFeelFront, brakeFront_raw, 0.55);
            _brakeFeelRear = Smooth(_brakeFeelRear, brakeRear_raw, 0.55);

            _brakeLockFront = Smooth(_brakeLockFront, lockFront_raw, 0.55);
            _brakeLockRear = Smooth(_brakeLockRear, lockRear_raw, 0.55);

            _brakeNSlipFront = Smooth(_brakeNSlipFront, brakeNSlipFront_raw, 0.55);
            _brakeNSlipRear = Smooth(_brakeNSlipRear, brakeNSlipRear_raw, 0.55);

            if (_brakeFeelFront < 0.001) _brakeFeelFront = 0.0;
            if (_brakeFeelRear < 0.001) _brakeFeelRear = 0.0;
            if (_brakeLockFront < 0.001) _brakeLockFront = 0.0;
            if (_brakeLockRear < 0.001) _brakeLockRear = 0.0;
            if (_brakeNSlipFront < 0.001) _brakeNSlipFront = 0.0;
            if (_brakeNSlipRear < 0.001) _brakeNSlipRear = 0.0;

            if (_brakeFeelFront > 1.0) _brakeFeelFront = 1.0;
            if (_brakeFeelRear > 1.0) _brakeFeelRear = 1.0;
            if (_brakeLockFront > 1.0) _brakeLockFront = 1.0;
            if (_brakeLockRear > 1.0) _brakeLockRear = 1.0;
            if (_brakeNSlipFront > 1.0) _brakeNSlipFront = 1.0;
            if (_brakeNSlipRear > 1.0) _brakeNSlipRear = 1.0;


            // ===== Steering for scrub / road feel helpers =====

            double steer = ReadFirstDouble(pm,
                "DataCorePlugin.GameRawData.Physics.SteerAngle",
                "DataCorePlugin.GameData.SteeringWheelAngle",
                "DataCorePlugin.GameData.SteeringAngle",
                "DataCorePlugin.GameRawData.mSteering"
            );

            double steerVel = steer - _steerLast;
            _steerLast = steer;

            double steerVelAbs = Math.Abs(steerVel);

            // Behaviour-based steering normalisation (no game-specific hacks)
            double steerNorm = ComputeSteerNormDynamic(steer, ref _steerMax, ref _steerRangeTracker);

            // Shared steering motion factor for all steering-driven effects
            double steerMotionFactor = Clamp01(steerVelAbs / 22.0);

            // ===== Traction / TC-ish straight-line activity (front / rear) =====

            double tcFront_raw = 0.0;
            double tcRear_raw = 0.0;

            bool straightLine = (steerNorm < 0.08 && steerVelAbs < 2.0);
            bool accelerating = (_throttle > 0.35 && _brake < 0.05 && _rpmNorm > 0.15 && speedKmh > 10.0);

            if (straightLine && accelerating)
            {
                double tractionSpeed = 0.40 + 0.60 * _speedNorm;
                double throttleShape = 0.50 + 0.50 * _throttle;

                double slipF_long = Clamp01(frontSpin * 1.5); // emphasise moderate slip
                double slipR_long = Clamp01(rearSpin * 1.5);

                tcFront_raw = slipF_long * throttleShape * tractionSpeed;
                tcRear_raw = slipR_long * throttleShape * tractionSpeed;
            }

            _tcFrontEnv = Smooth(_tcFrontEnv, tcFront_raw, 0.55);
            _tcRearEnv = Smooth(_tcRearEnv, tcRear_raw, 0.55);
            _tcFrontEnv *= 0.92;
            _tcRearEnv *= 0.92;

            if (_tcFrontEnv < 0.001) _tcFrontEnv = 0.0;
            if (_tcRearEnv < 0.001) _tcRearEnv = 0.0;
            if (_tcFrontEnv > 1.0) _tcFrontEnv = 1.0;
            if (_tcRearEnv > 1.0) _tcRearEnv = 1.0;


            // ===== Tyre scrub (front/rear) 0..1 =====
            // Behaviour intentionally similar to SimHub's default "Wheels slip":
            // - Driven by tyre slip
            // - Gated by throttle and brake
            // - Stronger at real speed
            // - Quiet on tiny slip, strong on mid/high slip

            {
                // Normalised slip intensities for front and rear.
                double slipF_scrub = Clamp01(_slipFrontIntensity);
                double slipR_scrub = Clamp01(_slipRearIntensity);

                // Throttle gate (roughly "trigger when throttle reaches 10%").
                double throttleGate = 0.0;
                if (_throttle > 0.10)
                    throttleGate = Clamp01((_throttle - 0.10) / 0.20);   // 0.10..0.30 -> 0..1

                // Brake gate (roughly "trigger when brake pedal reaches 10%").
                double brakeGate = 0.0;
                if (_brake > 0.10)
                    brakeGate = Clamp01((_brake - 0.10) / 0.20);          // 0.10..0.30 -> 0..1

                // Use whichever is stronger, but never fully kill scrub when coasting.
                // 0 pedal -> 0.35, full pedal gate -> 1.0
                double pedalGate = Math.Max(throttleGate, brakeGate);
                double driveGate = 0.35 + 0.65 * pedalGate;

                // Speed shaping: ignore near-zero speed, ramp in relatively early.
                // _speedNorm is 0..1; start at ~3% of max, full by ~40%.
                double speedShape = Clamp01((_speedNorm - 0.02) / 0.25);

                // Base slip signal.
                double baseFront = slipF_scrub * driveGate * speedShape;
                double baseRear = slipR_scrub * driveGate * speedShape;

                // Kill tiny noise.
                if (baseFront < 0.03) baseFront = 0.0;
                if (baseRear < 0.03) baseRear = 0.0;

                // Shape like SimHub: quiet at low slip, sharp at higher slip.
                double scrubFront_raw = (baseFront > 0.0) ? Math.Pow(baseFront, 1.35) : 0.0;
                double scrubRear_raw = (baseRear > 0.0) ? Math.Pow(baseRear, 1.35) : 0.0;

                // Slight tyre load weighting so heavily loaded tyres speak a bit more.
                double frontLoad = 0.5 + 0.5 * _tyreFront;
                double rearLoad = 0.5 + 0.5 * _tyreRear;
                scrubFront_raw *= frontLoad;
                scrubRear_raw *= rearLoad;

                // Rate limit upwards so it can't spike instantly.
                const double maxScrubStepUp = 0.06;
                if (scrubFront_raw > _scrubFrontEnv + maxScrubStepUp)
                    scrubFront_raw = _scrubFrontEnv + maxScrubStepUp;
                if (scrubRear_raw > _scrubRearEnv + maxScrubStepUp)
                    scrubRear_raw = _scrubRearEnv + maxScrubStepUp;

                // Smoothing – fairly quick to feel responsive.
                _scrubFrontEnv = Smooth(_scrubFrontEnv, scrubFront_raw, 0.65);
                _scrubRearEnv = Smooth(_scrubRearEnv, scrubRear_raw, 0.65);

                // Gentle decay so it dies away quickly when slip drops.
                _scrubFrontEnv *= 0.99;
                _scrubRearEnv *= 0.99;

                // Clamp.
                if (_scrubFrontEnv < 0.001) _scrubFrontEnv = 0.0;
                if (_scrubRearEnv < 0.001) _scrubRearEnv = 0.0;
                if (_scrubFrontEnv > 1.0) _scrubFrontEnv = 1.0;
                if (_scrubRearEnv > 1.0) _scrubRearEnv = 1.0;
            }


            // ===== Road feel (front/rear) 0..1 =====
            // Contact patch baseline: DOF micro-motions + light suspension + tyre load + tiny slip "grain".

            double dofHeave = Math.Abs(_motionHeave);
            double dofSway = Math.Abs(_motionSway);
            double dofSurge = Math.Abs(_motionSurge);

            // Stronger DOF contribution – still clamped later.
            double baseDof = Clamp01(
                dofHeave * 1.50 +
                dofSway * 1.10 +
                dofSurge * 0.90
            );

            // Suspension envelopes from the new scaffolding
            double suspFrontEnv = _suspVibrationFront;
            double suspRearEnv = _suspVibrationRear;

            // Tiny slip "grain" – just enough to wake it up when tyres are working
            double slipGrainF = Math.Pow(_slipFrontIntensity, 0.38) * 0.22;
            double slipGrainR = Math.Pow(_slipRearIntensity, 0.38) * 0.22;

            // Tyre load shaping (renamed to avoid clashes with scrub block)
            double tyreFrontShapeRF = 0.35 + 0.65 * _tyreFront;
            double tyreRearShapeRF = 0.35 + 0.65 * _tyreRear;
            if (tyreFrontShapeRF > 1.0) tyreFrontShapeRF = 1.0;
            if (tyreRearShapeRF > 1.0) tyreRearShapeRF = 1.0;

            // Speed-aware: little at low speed, a lot at high speed
            double roadSpeedShape = 0.30 + 0.90 * _speedNorm;
            if (roadSpeedShape < 0.0) roadSpeedShape = 0.0;
            if (roadSpeedShape > 1.0) roadSpeedShape = 1.0;

            // Raw mix – stronger weights
            double roadFront_raw =
                baseDof * 0.90 +
                suspFrontEnv * 0.90 +
                slipGrainF;

            double roadRear_raw =
                baseDof * 0.90 +
                suspRearEnv * 0.90 +
                slipGrainR;

            // Apply speed + tyre load shaping
            roadFront_raw *= roadSpeedShape * tyreFrontShapeRF;
            roadRear_raw *= roadSpeedShape * tyreRearShapeRF;

            // Add a clean speed-based floor so coasting at speed still feels like motion.
            double speedBase = 0.75 * _speedNorm;
            roadFront_raw += speedBase;
            roadRear_raw += speedBase;

            // Global gain – should easily reach the top of the SimHub graph at 100% gain
            const double roadGain = 2.4;
            roadFront_raw *= roadGain;
            roadRear_raw *= roadGain;


            // Clamp and shape – <1 exponent expands mid-range
            roadFront_raw = Clamp01(roadFront_raw);
            roadRear_raw = Clamp01(roadRear_raw);

            if (roadFront_raw > 0.0) roadFront_raw = Math.Pow(roadFront_raw, 0.80);
            if (roadRear_raw > 0.0) roadRear_raw = Math.Pow(roadRear_raw, 0.80);

            // Minimum floor so it doesn’t feel dead once you’re actually moving
            if (_speedNorm > 0.06)
            {
                if (roadFront_raw < 0.05) roadFront_raw = 0.05;
                if (roadRear_raw < 0.05) roadRear_raw = 0.05;
            }

            // Final smoothing
            _roadFeelFront = Smooth(_roadFeelFront, roadFront_raw, 0.45);
            _roadFeelRear = Smooth(_roadFeelRear, roadRear_raw, 0.45);

            if (_roadFeelFront < 0.001) _roadFeelFront = 0.0;
            if (_roadFeelRear < 0.001) _roadFeelRear = 0.0;
            if (_roadFeelFront > 1.0) _roadFeelFront = 1.0;
            if (_roadFeelRear > 1.0) _roadFeelRear = 1.0;



            // ===== Engine & tyres – front / rear (corner-phase envelopes) =====

            // Keep thresholds low: we want this alive in real corners, not just extremes.
            bool movingFastEnough = speedKmh > 3.5;
            bool lowBrake = _brake < 0.55;

            bool turningSoft = (steerNorm > 0.01) || (steerVelAbs > 0.02);
            bool turningMed = (steerNorm > 0.03) || (steerVelAbs > 0.04);
            bool turningHard = (steerNorm > 0.06) || (steerVelAbs > 0.08);

            double slipF = _slipFrontIntensity;
            double slipR = _slipRearIntensity;

            // --- steering preload: initial wave when the wheel gets heavy ---
            double steerPreloadBase = steerNorm * (0.40 + 0.60 * _speedNorm);
            double steerVelBoost = Clamp01(steerVelAbs / 30.0) * 0.6;

            double preloadFront = (steerPreloadBase + steerVelBoost) *
                                  (0.35 + 0.65 * _tyreFront);
            double preloadRear = (steerPreloadBase + steerVelBoost * 0.8) *
                                  (0.30 + 0.70 * _tyreRear);

            // --- slip-driven part, biased by throttle but never killed fully on lift ---
            double slipF_shaped = slipF * (0.40 + 0.60 * (_throttle + 0.2));
            double slipR_shaped = slipR * (0.45 + 0.55 * (_throttle + 0.2));

            // --- scrub hint from tyre scrub envelopes (ties 55 Hz into the 60 Hz wave) ---
            double scrubHintF = 0.0;
            double scrubHintR = 0.0;
            if (_scrubFrontEnv > 0.0)
            {
                scrubHintF = Math.Pow(Clamp01(_scrubFrontEnv), 0.70);
            }
            if (_scrubRearEnv > 0.0)
            {
                scrubHintR = Math.Pow(Clamp01(_scrubRearEnv), 0.70);
            }

            // --- torque / load shaping: how hard you are asking the tyres to work ---
            // Throttle dominates, but braking still moves load through the chassis.
            double torqueLoad = Clamp01(_throttle * 0.85 + _brake * 0.35);
            double torqueWaveF = slipF * torqueLoad;
            double torqueWaveR = slipR * torqueLoad;

            // --- exit-settle: when slip is dropping but tyres are still loaded ---
            double deltaSlipF = _engTyresFrontPrevSlip - slipF;
            double deltaSlipR = _engTyresRearPrevSlip - slipR;
            _engTyresFrontPrevSlip = slipF;
            _engTyresRearPrevSlip = slipR;

            double exitFront_raw = 0.0;
            double exitRear_raw = 0.0;

            if (deltaSlipF > 0.0 && turningMed && movingFastEnough)
            {
                exitFront_raw =
                    deltaSlipF *
                    steerNorm *
                    (0.30 + 0.70 * _speedNorm) *
                    (0.20 + 0.80 * _tyreFront);
            }

            if (deltaSlipR > 0.0 && turningMed && movingFastEnough)
            {
                exitRear_raw =
                    deltaSlipR *
                    steerNorm *
                    (0.30 + 0.70 * _speedNorm) *
                    (0.20 + 0.80 * _tyreRear);
            }

            _engTyresFrontExitEnv = Smooth(_engTyresFrontExitEnv, Clamp01(exitFront_raw), 0.55);
            _engTyresFrontExitEnv *= 0.90;

            _engTyresRearExitEnv = Smooth(_engTyresRearExitEnv, Clamp01(exitRear_raw), 0.55);
            _engTyresRearExitEnv *= 0.90;

            // --- axle bias (FWD vs RWD-ish) ---
            double axleBiasF = 1.0;
            double axleBiasR = 1.0;
            if (frontDom) { axleBiasF = 1.35; axleBiasR = 0.80; }
            else if (rearDom) { axleBiasF = 0.75; axleBiasR = 1.40; }

            // Corner phase is now **soft**: any real turning at speed opens it.
            bool cornerPhaseActive =
                ((turningSoft && movingFastEnough && lowBrake) || isBurnout);

            // --- FRONT axle engine & tyres envelope ---
            {
                double targetFront = 0.0;

                if (cornerPhaseActive)
                {
                    // Base wave: steering preload + slip under your control.
                    targetFront += preloadFront * 0.55;
                    targetFront += slipF_shaped * axleBiasF * 1.05;

                    // Exit-settle: tyres still loaded while slip drops (release phase).
                    targetFront += _engTyresFrontExitEnv * 0.75;

                    // Scrub contribution: strong surface fight pulls the chassis wave up.
                    targetFront += scrubHintF * 0.40;

                    // Torque wave: how hard you are asking the front tyres to work.
                    targetFront += torqueWaveF * 0.35;

                    if (isBurnout && frontDom)
                    {
                        targetFront *= 1.20;
                    }
                }

                targetFront = Clamp01(targetFront);
                double shapedFront = Math.Pow(targetFront, 0.90);

                double attackF = 0.55;
                double decayF = 0.68;

                if (shapedFront > _engTyresFrontEnv)
                {
                    _engTyresFrontEnv = _engTyresFrontEnv * (1.0 - attackF) + shapedFront * attackF;
                }
                else
                {
                    _engTyresFrontEnv *= decayF;
                }

                if (_engTyresFrontEnv < 0.001) _engTyresFrontEnv = 0.0;
                if (_engTyresFrontEnv > 1.0) _engTyresFrontEnv = 1.0;

                _engTyresFront = _engTyresFrontEnv;
            }

            // --- REAR axle engine & tyres envelope ---
            {
                double targetRear = 0.0;

                if (cornerPhaseActive)
                {
                    // Base wave: steering preload + slip under power at the rear.
                    targetRear += preloadRear * 0.55;
                    targetRear += slipR_shaped * axleBiasR * 1.15;

                    // Exit-settle: rear tyres re-gripping after a slide.
                    targetRear += _engTyresRearExitEnv * 0.85;

                    // Scrub contribution: rear friction fight ties into the chassis wave.
                    targetRear += scrubHintR * 0.50;

                    // Torque wave: how hard you are pushing the rear tyres.
                    targetRear += torqueWaveR * 0.45;

                    if (isBurnout && rearDom)
                    {
                        targetRear *= 1.30;
                    }
                }

                // TC influence: when TC is busy, the wave tightens slightly instead of exploding.
                if (_tcRearEnv > 0.05 && cornerPhaseActive)
                {
                    double tcBlend = Clamp01(_tcRearEnv * 1.2);
                    targetRear *= (0.90 + 0.10 * (1.0 - tcBlend));
                }

                targetRear = Clamp01(targetRear);
                double shapedRear = Math.Pow(targetRear, 0.90);

                double attackR = 0.60;
                double decayR = 0.68;

                if (shapedRear > _engTyresRearEnv)
                {
                    _engTyresRearEnv = _engTyresRearEnv * (1.0 - attackR) + shapedRear * attackR;
                }
                else
                {
                    _engTyresRearEnv *= decayR;
                }

                if (_engTyresRearEnv < 0.001) _engTyresRearEnv = 0.0;
                if (_engTyresRearEnv > 1.0) _engTyresRearEnv = 1.0;

                _engTyresRear = _engTyresRearEnv;
            }

            // ===== Surface / grip learners (non-invasive, exposed for future use) =====
            {
                double grainRaw = Clamp01(
                    Math.Abs(_motionHeave) * 0.60 +
                    Math.Abs(_motionSway) * 0.30 +
                    Math.Abs(_motionSurge) * 0.20 +
                    _suspVibrationFront * 0.40 +
                    _suspVibrationRear * 0.40
                );
                _surfaceGrain = Smooth(_surfaceGrain, grainRaw, 0.20);

                double harshRaw = Clamp01(
                    _suspImpactFront * 0.50 +
                    _suspImpactRear * 0.50 +
                    grainRaw * 0.20
                );
                _surfaceHarshness = Smooth(_surfaceHarshness, harshRaw, 0.20);

                double impactBiasRaw = Clamp01(
                    (_suspImpactFront + _suspImpactRear) * 0.50
                );
                _surfaceImpactBias = Smooth(_surfaceImpactBias, impactBiasRaw, 0.25);

                double frontLoadRaw = Clamp01(_tyreFront * 0.70 + Math.Abs(_heaveNorm) * 0.30);
                double rearLoadRaw = Clamp01(_tyreRear * 0.70 + Math.Abs(_heaveNorm) * 0.30);
                _suspLoadFrontEnv = Smooth(_suspLoadFrontEnv, frontLoadRaw, 0.25);
                _suspLoadRearEnv = Smooth(_suspLoadRearEnv, rearLoadRaw, 0.25);

                double speedScale = 0.40 + 0.60 * _speedNorm;
                double gbFrontRaw = Clamp01(1.0 - _slipFrontIntensity * speedScale);
                double gbRearRaw = Clamp01(1.0 - _slipRearIntensity * speedScale);
                _gripBudgetFront = Smooth(_gripBudgetFront, gbFrontRaw, 0.25);
                _gripBudgetRear = Smooth(_gripBudgetRear, gbRearRaw, 0.25);
            }

            // ===== Clutch freewheel / kick intensity 0..1 =====

            double clutch = Clamp01(ReadFirstDouble(pm,
                "DataCorePlugin.GameData.Clutch",
                "DataCorePlugin.GameRawData.Physics.Clutch",
                "DataCorePlugin.GameData.ClutchPosition"
            ));

            _clutch = clutch; // keep last clutch value for gearshift logic

            double rpmDelta = _rpmNorm - _lastRpmNorm;
            _lastRpmNorm = _rpmNorm;

            // How "violent" the free-rev is (0..1) based on rpmDelta
            double deltaFactor = Clamp01((rpmDelta - 0.01) * 40.0); // 0.01 -> threshold, 40 = gain

            double clutchTarget = 0.0;

            bool isFreeRev =
                clutch > 0.75 &&
                _throttle > 0.15 &&
                rpmDelta > 0.01 &&
                _rpmNorm > 0.15;

            if (isFreeRev)
            {
                // Scale by rpm and how hard the rev is jumping
                clutchTarget = Clamp01(_rpmNorm * 1.2 * deltaFactor);
            }

            // Asymmetric smoothing: fast rise, slower fall
            double smoothFactor;
            if (clutchTarget > _clutchFreeEnv)
            {
                // Rising towards a new spike: be snappy
                smoothFactor = 0.8;
            }
            else
            {
                // Relaxing back down: softer
                smoothFactor = 0.25;
            }

            _clutchFreeEnv = Smooth(_clutchFreeEnv, clutchTarget, smoothFactor);

            // Extra decay only when we're not actively in a free-rev state
            if (!isFreeRev)
            {
                _clutchFreeEnv *= 0.90; // slightly faster decay than your 0.95
            }

            // ===== Gearshift scaffolding =====

            int gear = 0;
            try
            {
                if (!int.TryParse(gd.Gear, out gear))
                {
                    gear = 0;
                }
            }
            catch
            {
                gear = 0;
            }

            if (_lastGear == int.MinValue)
            {
                _lastGear = gear;
            }

            bool gearChanged = (gear != _lastGear);

            double gearEnv = _gearShiftEnv;
            double fwdKick = _gearShiftFwdKick;
            double backKick = _gearShiftBackKick;
            double grind = _gearShiftGrindEnv;

            // Engine has to be at least vaguely alive
            bool engineAwake = (_rpmNorm > 0.05);

            // Snapshot clutch at this point (0..1)
            double clutchNow = Clamp01(clutch);

            // Treat extremes as "properly used clutch"
            bool clutchFullyIn = (clutchNow >= 0.90);
            bool clutchFullyOut = (clutchNow <= 0.10);

            // Distance from extremes: 0 at 0/1, 0.5 at 0.5
            double clutchMidNow = Math.Min(clutchNow, 1.0 - clutchNow);

            // === 1) KICKS – simple, strong ===

            if (gearChanged && engineAwake)
            {
                bool upshift = gear > _lastGear;

                // Base impact: RPM + throttle
                double baseHitRaw = (_rpmNorm * 3.0) * (0.55 + 0.45 * _throttle);
                double baseHit = Clamp01(baseHitRaw);

                // Downshifts usually feel harsher
                if (!upshift)
                {
                    baseHit *= 1.10;
                    if (baseHit > 1.0) baseHit = 1.0;
                }

                // Map to forward/backward kick
                if (upshift)
                {
                    if (baseHit > backKick) backKick = baseHit;
                }
                else
                {
                    if (baseHit > fwdKick) fwdKick = baseHit;
                }

                // Shared envelope (if you ever want a combined "gearshift" effect)
                if (baseHit * 0.7 > gearEnv) gearEnv = baseHit * 0.7;

                // === 2) SIMPLE MIS-SHIFT CLASSIFICATION (v2) ===
                //
                // Goal: be MUCH more willing to call something "bad" so we can tune down later.

                bool engineLoaded = (_rpmNorm > 0.12);
                bool someThrottle = (_throttle > 0.08);

                // Treat anything not near 0 or 1 as "sloppy clutch"
                bool sloppyClutch = (clutchMidNow > 0.10);

                // Basic bad shift definition:
                //  - in any real gear
                //  - engine turning
                //  - either:
                //      * shifting under throttle with sloppy clutch
                //      * or shifting with NO clutch at all and noticeable throttle
                bool badShift =
                    (gear != 0) &&
                    engineLoaded &&
                    (
                        (someThrottle && sloppyClutch) ||     // lazy clutch under load
                        (someThrottle && clutchFullyOut)      // flat-shift abuse
                    );

                if (badShift)
                {
                    _gearGrindWindow = 1.0;

                    // Aggressive spike: make sure we SEE/FEEL it in tests.
                    double abuseFactor =
                        0.40 +                    // base floor
                        1.2 * clutchMidNow +      // mid-clutch lifts it a lot
                        1.0 * _throttle;          // throttle lifts it

                    if (abuseFactor > 1.8) abuseFactor = 1.8;

                    double grindSpikeRaw =
                        (_rpmNorm * 2.6) *
                        (0.40 + 0.60 * _throttle) *
                        abuseFactor;

                    double grindSpike = Clamp01(grindSpikeRaw);
                    if (grindSpike > grind) grind = grindSpike;
                }
            }

            // === 3) SUSTAINED GRIND WHILE YOU KEEP ABUSING IT ===
            //
            // Once a mis-shift opened the window, this keeps the buzz alive as long as:
            //  - you're still in gear
            //  - engine is turning
            //  - you're either on throttle, OR coasting with feet off all pedals
            // Window naturally decays if you stop abusing it.

            if (_gearGrindWindow > 0.01)
            {
                // Decay the window (gives you roughly ~1–2s of potential grind)
                _gearGrindWindow *= 0.985;
                if (_gearGrindWindow < 0.01) _gearGrindWindow = 0.0;

                bool coastingNoPedals =
                    (_throttle < 0.02) &&
                    (_brake < 0.02) &&
                    clutchFullyOut;         // your "no feet on any pedals" case

                bool onThrottle =
                    (_throttle > 0.10);

                bool stillAbusing =
                    (gear != 0) &&
                    (_rpmNorm > 0.12) &&
                    (onThrottle || coastingNoPedals);

                if (stillAbusing && _gearGrindWindow > 0.0)
                {
                    // Continuous grind level: RPM + throttle, scaled fairly high.
                    double sustainedRaw =
                        (_rpmNorm * 2.6) *
                        (0.35 + 0.65 * _throttle);

                    double sustained = Clamp01(sustainedRaw);

                    // Mid-clutch makes it nastier, but we do NOT require mid-clutch to grind.
                    double midBoost = 1.0 + 1.1 * clutchMidNow; // 1.0..~1.55
                    if (midBoost > 1.55) midBoost = 1.55;

                    sustained *= midBoost;

                    // Blend to sustained so it doesn’t flicker
                    grind = (grind * 0.35) + (sustained * 0.65);
                }
                else
                {
                    // You lifted, braked, pressed the clutch properly, or engine dropped
                    grind *= 0.90;
                    if (grind < 0.001) grind = 0.0;
                }
            }

            // === 4) DECAY & BOOKKEEPING (kicks + env) ===

            fwdKick *= 0.85;
            backKick *= 0.85;
            gearEnv *= 0.80;

            if (fwdKick < 0.001) fwdKick = 0.0;
            if (backKick < 0.001) backKick = 0.0;
            if (gearEnv < 0.001) gearEnv = 0.0;

            // Store back into fields
            _gearShiftFwdKick = Clamp01(fwdKick);
            _gearShiftBackKick = Clamp01(backKick);
            _gearShiftEnv = Clamp01(gearEnv);
            _gearShiftGrindEnv = Clamp01(grind);

            _lastGear = gear;

            // ===== Debug logging (optional, controlled by DebugMode) =====
            WriteDebugLogLine(speedKmh, gear, gameId); ;

        }

        /// <summary>
        /// Writes one CSV line per physics tick when DebugMode is enabled.
        /// Files are created under: [SimHubRoot]\Logs\MCP4SH\
        /// </summary>
        private void WriteDebugLogLine(double speedKmh, int gear, string gameId)
        {
            // If debug is OFF, make sure any open writer is closed.
            if (!DebugMode)
            {
                if (_debugWriter != null)
                {
                    try
                    {
                        _debugWriter.Flush();
                        _debugWriter.Dispose();
                    }
                    catch
                    {
                        // best-effort; ignore logging errors
                    }
                    _debugWriter = null;
                    _debugHeaderWritten = false;
                }

                return;
            }

            // Debug is ON: ensure writer exists.
            if (_debugWriter == null)
            {
                try
                {
                    // Base SimHub folder (SimHub.exe directory)
                    var baseDir = AppDomain.CurrentDomain.BaseDirectory;
                    var logsRoot = Path.Combine(baseDir, "Logs", "MCP4SH");

                    if (!Directory.Exists(logsRoot))
                    {
                        Directory.CreateDirectory(logsRoot);
                    }

                    var safeGameId = string.IsNullOrWhiteSpace(gameId) ? "UnknownGame" : gameId;
                    foreach (var c in Path.GetInvalidFileNameChars())
                    {
                        safeGameId = safeGameId.Replace(c, '_');
                    }

                    var fileName = $"MCP4SH_{safeGameId}_{DateTime.UtcNow:yyyyMMdd_HHmmss}.csv";
                    var fullPath = Path.Combine(logsRoot, fileName);

                    _debugWriter = new StreamWriter(fullPath, false, System.Text.Encoding.UTF8)
                    {
                        AutoFlush = true
                    };

                    _debugHeaderWritten = false;
                    _debugSessionStartUtc = DateTime.UtcNow;
                }
                catch
                {
                    // If file can't be opened, silently disable logging this session.
                    _debugWriter = null;
                    return;
                }
            }

            if (_debugWriter == null) return;

            var inv = CultureInfo.InvariantCulture;

            // Time since debug session start (seconds)
            var t = (DateTime.UtcNow - _debugSessionStartUtc).TotalSeconds;


            // Build CSV header on first line
            if (!_debugHeaderWritten)
            {
                var header = string.Join(",",
                    "TimeSec",
                    "GameId",
                    "SpeedKmh",
                    "Gear",
                    "RpmNorm",
                    "Throttle",
                    "Brake",
                    "Clutch",
                    "SlipFL",
                    "SlipFR",
                    "SlipRL",
                    "SlipRR",
                    "SlipFront",
                    "SlipRear",
                    "BrakeFeelFront",
                    "BrakeFeelRear",
                    "BrakeNSlipFront",
                    "BrakeNSlipRear",
                    "BrakeLockFront",
                    "BrakeLockRear",
                    "TCFrontEnv",
                    "TCRearEnv",
                    "RoadFeelFront",
                    "RoadFeelRear",
                    "SuspImpactFront",
                    "SuspImpactRear",
                    "EngTyresFrontEnv",
                    "EngTyresRearEnv",
                    "GearShiftEnv",
                    "GearShiftGrindEnv",
                    "GearShiftFwdKick",
                    "GearShiftBackKick"
                );

                _debugWriter.WriteLine(header);
                _debugHeaderWritten = true;
            }

            // Derived / internal values we already maintain in the plugin:
            double slipFront = 0.5 * (_slipFL + _slipFR);
            double slipRear = 0.5 * (_slipRL + _slipRR);

            var line = string.Join(",",
                t.ToString("F3", inv),
                (gameId ?? string.Empty),

                speedKmh.ToString("F2", inv),
                gear.ToString(inv),

                _rpmNorm.ToString("F4", inv),
                _throttle.ToString("F3", inv),
                _brake.ToString("F3", inv),
                _clutch.ToString("F3", inv),

                _slipFL.ToString("F4", inv),
                _slipFR.ToString("F4", inv),
                _slipRL.ToString("F4", inv),
                _slipRR.ToString("F4", inv),

                slipFront.ToString("F4", inv),
                slipRear.ToString("F4", inv),

                _brakeFeelFront.ToString("F4", inv),
                _brakeFeelRear.ToString("F4", inv),

                _brakeNSlipFront.ToString("F4", inv),
                _brakeNSlipRear.ToString("F4", inv),

                _brakeLockFront.ToString("F4", inv),
                _brakeLockRear.ToString("F4", inv),

                _tcFrontEnv.ToString("F4", inv),
                _tcRearEnv.ToString("F4", inv),

                _roadFeelFront.ToString("F4", inv),
                _roadFeelRear.ToString("F4", inv),

                _suspImpactFront.ToString("F4", inv),
                _suspImpactRear.ToString("F4", inv),

                _engTyresFrontEnv.ToString("F4", inv),
                _engTyresRearEnv.ToString("F4", inv),

                _gearShiftEnv.ToString("F4", inv),
                _gearShiftGrindEnv.ToString("F4", inv),
                _gearShiftFwdKick.ToString("F4", inv),
                _gearShiftBackKick.ToString("F4", inv)
            );

            try
            {
                _debugWriter.WriteLine(line);
            }
            catch
            {
                // Ignore write failures; don't crash the plugin.
            }
        }

        // ===== IWPFSettings implementation =====

        //public Control GetWPFSettingsControl(PluginManager pluginManager)
        //{
        //    if (_settingsControl == null)
        //    {
        //        _settingsControl = new MCP4SHSettingsControl(this);
        //    }

        //    return _settingsControl;
        //}

        // ===== Helper methods =====

        private static double Clamp01(double v)
        {
            if (double.IsNaN(v) || double.IsInfinity(v)) return 0.0;
            if (v < 0.0) return 0.0;
            if (v > 1.0) return 1.0;
            return v;
        }

        private static double NormalizeRange(double value, double min, double max)
        {
            if (double.IsNaN(value) || double.IsInfinity(value)) return 0.0;
            if (max <= min) return 0.0;

            double t = (value - min) / (max - min);
            return Clamp01(t);
        }

        private static double Smooth(double previous, double target, double alpha)
        {
            if (alpha <= 0.0) return previous;
            if (alpha >= 1.0) return target;
            return previous + (target - previous) * alpha;
        }

        private static double ReadDouble(PluginManager pm, string name, double fallback = 0.0)
        {
            try
            {
                var obj = pm.GetPropertyValue(name);
                if (obj is IConvertible) return Convert.ToDouble(obj);
            }
            catch
            {
                // ignore
            }

            return fallback;
        }

        private static double ReadFirstDouble(PluginManager pm, params string[] names)
        {
            foreach (var n in names)
            {
                try
                {
                    var obj = pm.GetPropertyValue(n);
                    if (obj is IConvertible)
                    {
                        return Convert.ToDouble(obj);
                    }
                }
                catch
                {
                    // ignore
                }
            }
            return 0.0;
        }

        private static string ReadString(PluginManager pm, string name, string fallback = "")
        {
            try
            {
                var obj = pm.GetPropertyValue(name);
                if (obj == null) return fallback;
                return obj.ToString();
            }
            catch
            {
                return fallback;
            }
        }

        private static double Max4(double a, double b, double c, double d)
        {
            double m = a;
            if (b > m) m = b;
            if (c > m) m = c;
            if (d > m) m = d;
            return m;
        }

        private static double Lerp(double a, double b, double t)
        {
            if (t <= 0.0) return a;
            if (t >= 1.0) return b;
            return a + (b - a) * t;
        }

        /// <summary>
        /// Behaviour-based steering normalisation.
        /// - If steering stays in a tiny range (looks normalised) → use directly.
        /// - Otherwise → dynamic degree-based lock with self-calibrating max.
        /// Works for AC, AMS2, and anything else without game-specific hacks.
        /// </summary>
        private static double ComputeSteerNormDynamic(double steer, ref double steerMax, ref double steerRangeTracker)
        {
            double steerAbs = Math.Abs(steer);

            // Track rolling "typical" amplitude
            steerRangeTracker = steerRangeTracker * 0.995 + steerAbs * 0.005;

            // If this looks like [-1..+1] style steering, treat as already normalised-ish
            bool looksNormalised = steerRangeTracker < 2.0;

            if (looksNormalised)
            {
                double n = steerAbs;
                if (n > 1.0) n = 1.0;
                return n;
            }

            // Otherwise: dynamic lock-based normalisation (degrees etc.)
            if (steerAbs > steerMax)
            {
                steerMax = steerAbs * 1.05;
            }
            else
            {
                steerMax *= 0.999;
                if (steerMax < 15.0) steerMax = 15.0;
            }

            if (steerMax < 1.0)
                return 0.0;

            return Clamp01(steerAbs / steerMax);
        }

        /// <summary>
        /// Adaptive slip learner for one axle.
        /// Keeps behaviour consistent across clean and noisy telemetry.
        /// Learning is continuous while the sim is running (per session, per axle).
        /// </summary>
        private static void UpdateSlipForAxle(
            double spin,
            ref double baseSlip,
            ref double maxSlip,
            ref double env,
            ref double drive,
            ref double lastSpin,
            ref double jitter,
            bool thisAxleDominant,
            bool otherAxleDominant,
            bool isBurnout,
            double rpmNorm,
            double throttle
        )
        {
            if (spin < 0.0) spin = 0.0;

            // --- Jitter tracking (how noisy is this signal?) ---
            double diff = Math.Abs(spin - lastSpin);
            lastSpin = spin;

            jitter = jitter * 0.85 + diff * 0.15;

            double denom = baseSlip > 1e-4 ? baseSlip : 0.1;
            double jitterNorm = Clamp01(jitter / (denom * 1.5));
            double stability = 1.0 - jitterNorm; // 0 = noisy, 1 = stable

            // --- Baseline and max learning ---

            if (baseSlip <= 0.0 && spin > 0.0)
            {
                baseSlip = spin * 0.7;
                maxSlip = spin * 1.4;
            }

            if (rpmNorm > 0.08 && throttle < 0.40 && spin > 0.0)
            {
                double baseBlend = 0.06;
                baseSlip = baseSlip * (1.0 - baseBlend) + spin * baseBlend;
            }

            if (throttle > 0.20 && spin > baseSlip * 1.10)
            {
                double candidate = spin * 1.20;
                double maxBlend = 0.30;
                maxSlip = maxSlip * (1.0 - maxBlend) + candidate * maxBlend;
            }

            if (maxSlip < baseSlip * 1.4) maxSlip = baseSlip * 1.4;

            // --- Effective baseline tweak for stable signals ---
            double baseScale = Lerp(1.0, 0.75, stability);
            double effectiveBase = baseSlip * baseScale;

            // --- Adaptive thresholds based on jitter ---
            double minFactor = Lerp(0.30, 0.04, stability);
            double capFactor = Lerp(0.98, 0.80, stability);

            double slipMin = effectiveBase + (maxSlip - effectiveBase) * minFactor;
            double slipCap = effectiveBase + (maxSlip - effectiveBase) * capFactor;
            if (slipCap < slipMin + 1e-4) slipCap = slipMin + 1e-4;

            double sx = (spin - slipMin) / (slipCap - slipMin);
            if (sx < 0.0) sx = 0.0;
            if (sx > 1.0) sx = 1.0;

            double instSlip = sx * sx * (3.0 - 2.0 * sx);

            // --- Adaptive envelope smoothing based on jitter ---
            double instWeight = Lerp(0.35, 0.80, stability);
            double prevWeight = 1.0 - instWeight;
            double envDecay = Lerp(0.99, 0.88, stability);

            env = env * prevWeight + instSlip * instWeight;
            env *= envDecay;

            double slipEnv = Math.Pow(env, 1.25);

            double slipGain = 1.0 + (1.0 - stability) * 0.35;
            slipEnv *= slipGain;
            if (slipEnv > 1.0) slipEnv = 1.0;

            double axleBias = 1.0;
            if (thisAxleDominant) axleBias = 1.6;
            else if (otherAxleDominant) axleBias = 0.7;

            double target = slipEnv * axleBias;
            if (isBurnout)
            {
                target *= 1.45;
            }

            target *= 1.25;

            double driveDecay = Lerp(0.75, 0.32, stability);

            if (target > drive)
            {
                double attackBlend = Lerp(0.35, 0.75, stability);
                drive = drive * (1.0 - attackBlend) + target * attackBlend;
            }
            else
            {
                drive *= driveDecay;
            }

            double result = Math.Pow(drive, 0.95);
            if (result < 0.0) result = 0.0;
            if (result > 1.0) result = 1.0;

            drive = result;
        }
    }
}
