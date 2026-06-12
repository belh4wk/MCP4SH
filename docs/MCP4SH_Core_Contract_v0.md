# MCP4SH Core Contract v0

**Status:** Draft v0  
**Scope:** MCP4SH v1.1 core/plugin boundary after the core split  
**Primary goal:** keep MCP4SH.Core portable, testable, and usable by multiple adapters, including the SimHub plugin, replay/conformance tools, and a future standalone runtime.

---

## 1. Contract summary

MCP4SH is split into two responsibilities:

```text
Host adapter / plugin
  reads telemetry, owns UI/settings/persistence/licensing, exposes outputs

MCP4SH.Core
  owns haptic interpretation, semantic shaping, stateful effect logic, arbitration/adaptive math
```

The SimHub plugin is now one adapter for the core. It should not own effect logic except where strictly necessary to read SimHub data, prepare input DTOs, or mirror output values back into SimHub delegates.

The target flow is:

```text
Sim / host telemetry
→ adapter-normalized input DTOs
→ MCP4SH.Core engines
→ core output DTOs / envelopes
→ adapter output mapping
→ SimHub haptic effects / future standalone renderer
```

---

## 2. Non-negotiable boundary rules

### 2.1 Core must not depend on SimHub

`MCP4SH.Core` must not reference or require:

- SimHub APIs
- WPF / XAML / UI controls
- plugin lifecycle callbacks
- SimHub property strings
- SimHub delegates
- SimHub sound output concepts
- licensing / product edition logic
- file system logging as part of effect generation

### 2.2 Plugin owns host-specific work

The plugin owns:

- SimHub telemetry reads
- raw property names and fallback lookup strategy
- user-facing settings and UI
- profile/per-game persistence
- license/demo/paid feature decisions
- SimHub delegate/property exports
- logging toggles and CSV file writing
- Direct Telemetry comparison output selection
- copying core outputs into existing public MCP4SH properties

### 2.3 Core owns interpretation and feel logic

The core owns:

- signal normalization once adapter-normalized values are provided
- stateful smoothing/envelopes
- brake/ABS/lock logic
- tyre scrub character logic
- Engine & Tyres / tyre-stack logic
- powertrain/drivetrain logic
- suspension vibration/impact logic
- RoadFeel speed/surface response
- ST Tensioner/arbiter math
- ST Balancer/Learner adaptive math
- deterministic output envelopes

---

## 3. Modes of operation

### 3.1 MCP4SH Codec mode

Codec mode is the normal MCP4SH behavior.

Allowed in Codec mode:

- normalized telemetry
- reconstructed/fallback telemetry where the adapter provides it
- learned/adaptive signal ranges
- smoothing/envelopes
- semantic shaping
- priority/hero logic
- ST Tensioner
- ST Balancer/Learner
- speed-aware RoadFeel response
- wheel-speed-aware TyreScrub character

### 3.2 Direct Telemetry mode

Direct Telemetry mode exists for comparison and should remain honest.

Allowed in Direct mode:

- direct game/SimHub values only
- basic unit normalization, for example speed ratio or RPM ratio
- null/NaN safety handling
- final clamping to valid output range

Not allowed in Direct mode:

- fallback reconstruction
- synthetic slip from DOFs/input
- wheel-speed-derived or inferred slip where the sim did not provide a direct source
- ST Tensioner shaping
- ST Balancer/Learner shaping
- codec-derived composite effects
- “make it useful anyway” reconstruction

If a game does not expose a direct usable signal, Direct mode may output `0` for that lane. This is intentional.

---

## 4. Core input DTOs

The current core uses several purpose-specific input DTOs instead of a single monolithic frame. This is acceptable for v0 and keeps each engine clear.

### 4.1 `TelemetryFrame`

Used by the main tyre-stack / codec path.

Current responsibilities include:

- speed and wheel-speed equivalents
- driver inputs
- engine RPM/max RPM
- learned axle slip intensity
- per-wheel slip
- steering
- spin signals
- tyre load proxies
- TyreScrub tuning inputs
- Engine & Tyres tuning inputs

Contract notes:

- `SpeedKmh` is km/h.
- `WheelSpeed* Kmh` are optional wheel rotational/linear speed equivalents; when unavailable, core must degrade gracefully.
- driver inputs are normalized `0..1` unless explicitly stated.
- steering sign and magnitude should be consistent within a host adapter.
- missing optional values must not produce NaN/Inf.

### 4.2 `SuspensionInputs`

Used by `SuspensionEngine`.

Current responsibilities include:

- delta time
- speed / speed norm
- throttle/brake/TC proxy context
- motion DOFs
- tyre front/rear proxies
- raw suspension travel and damper channels
- wheel load fallback/proxy inputs

Contract notes:

- plugin/adapter may provide fallback or proxy values, but the core owns how suspension vibration/impact outputs are shaped from the DTO.
- sign conventions for suspension travel can vary by sim; therefore internal language should prefer “oscillation” unless sign has been validated.

### 4.3 `RoadFeelInputs`

Used by `RoadFeelEngine`.

Current responsibilities include:

- speed and speed normalization
- motion DOFs
- suspension vibration support
- slip / tyre proxy context
- surface grain/harshness
- RoadFeel base/full tone speed settings

Contract notes:

- RoadFeel communicates rolling speed and surface texture.
- speed response is controlled by base/full tone speeds.
- RoadFeel should not become TyreScrub or traction-loss logic.

### 4.4 `PowertrainInputs`

Used by `PowertrainEngine`.

Current responsibilities include:

- speed/speed norm
- RPM norm
- throttle/brake/clutch
- gear
- wheel load proxies
- suspension event envelopes for drivetrain context

Contract notes:

- plugin/adapter owns gear parsing.
- core owns clutch-freewheel, over-rev, rev limiter, shift, and drivetrain envelope logic.

### 4.5 `StTensionerInputs`

Used by `StTensionerEngine`.

Current responsibilities include:

- premium/active state as a boolean gate from the plugin
- master intensity / lane settings
- current effect activity values
- hero candidate values

Contract notes:

- licensing remains outside the core; the core receives simple boolean/settings inputs.
- core owns the tensioner/arbiter math once inputs are provided.

### 4.6 `StAdaptiveInputs`

Used by `StAdaptiveEngine`.

Current responsibilities include:

- premium/active state
- ST Balancer and ST Learner enabled flags
- capture baseline command state
- current lane activities
- user-configured adaptive gains

Contract notes:

- plugin owns the button/UI and persisted settings.
- core owns runtime adaptive state and gain calculation.

---

## 5. Core output DTOs

### 5.1 `CodecFrame`

Main codec output for:

- brake feel
- ABS/lock
- TC-ish activity
- TyreScrub
- Engine & Tyres
- steering helpers
- grip budgets

All main effect envelopes should be normalized unless explicitly documented otherwise.

### 5.2 `SuspensionOutputs`

Suspension output includes:

- per-corner suspension intensity
- front/rear vibration
- front/rear impact
- per-corner vibration split
- per-corner impact split
- load envelopes and event envelopes

Contract notes:

- impact and vibration are distinct lanes.
- current v1.1 vibration includes a core-owned oscillation component; impact should remain thuddy/transient.

### 5.3 `RoadFeelOutputs`

RoadFeel output includes:

- front/rear RoadFeel
- speed phase
- movement gate

Contract notes:

- speed phase is useful for debugging and conformance.
- RoadFeel output may reflect both speed and surface/texture context.

### 5.4 `PowertrainOutputs`

Powertrain output includes:

- engine front/rear intensity
- clutch-free/over-rev/rev-limiter
- gearshift envelopes
- drivetrain front/rear

Contract notes:

- future ClutchEngagement/DrivelineBite should live here or in a closely related core engine.

### 5.5 `StTensionerOutputs`

ST Tensioner output includes:

- duck factor
- texture/osc gain
- lane hero gains
- debug/trace values where relevant

### 5.6 `StAdaptiveOutputs`

ST Adaptive output includes:

- per-family balancer gains
- ST Learner gains
- activity values
- baseline status output

---

## 6. Value invariants

Unless explicitly documented otherwise:

- Effect output envelopes should be finite numbers.
- No output should be NaN or Infinity.
- Most public effect envelopes should be clamped to `0..1` before export.
- Internal gain values may exceed `1.0` only where the owning engine documents them as multipliers.
- Missing input should degrade safely, usually to `0` or to a documented fallback path.
- Same inputs + same state should produce deterministic outputs.
- Stateful engines should expose/reset their state through owned state structs.

Known current caveat:

- Some observed plugin exports may include post-core scaling, ST gains, or profile/output-stage behavior. The conformance harness should compare stage-equivalent values where possible.

---

## 7. Logging and conformance contract

### 7.1 Replay CSV

The plugin can emit a replay/conformance CSV with raw-ish inputs and observed outputs:

```text
MCP4SH_Replay_<GameId>_<timestamp>.csv
```

This file is intended as the input to the conformance tool.

### 7.2 Conformance trace CSV

The conformance tool produces:

```text
trace_<scenario>.csv
```

The trace contains replayed core outputs plus observed plugin outputs where available.

### 7.3 v0 conformance status

Current v0 conformance is a trace generator, not a pass/fail golden-test runner.

Current expected use:

- generate replay CSV from SimHub
- run conformance tool
- inspect trace outputs
- use traces to spot regressions and stage mismatches

Future use:

- golden snapshots
- pass/fail thresholds
- scenario labels
- per-engine assertions
- automated CI checks

---

## 8. Known conformance gaps from first AC trace

A first real trace was successfully generated and processed:

```text
Frames: 59471
GameId: AssettoCorsa
```

The replay/conformance pipeline is operational. Several lanes line up closely between replayed core and observed plugin outputs, especially:

- Suspension Vibration
- Suspension Impact
- TyreScrub
- GearShift envelope
- BrakeFeel mostly, with small timing differences

Known v0 gaps / follow-up items:

1. **TC replay gap**  
   Core TC trace columns are currently zero while observed TC columns show activity. This points to a harness mapping/stage gap or a missing input path, not necessarily a runtime bug.

2. **Engine & Tyres stage mismatch**  
   Core E&T and observed E&T differ materially in the trace. This likely reflects stage differences, post-core scaling, ST/adaptive gains, or replay input mismatch. It should be documented before treating E&T as pass/fail.

3. **Brake lock timing differences**  
   BrakeLock core/observed values are close overall but show short timing differences. This aligns with the planned brake-state timing refinement.

These gaps do not block using the harness; they define what v0 needs to improve before becoming a strict automated conformance checker.

---

## 9. Adapter responsibilities

Any host adapter, including the SimHub plugin or future standalone adapters, must:

- read host/game telemetry
- normalize obvious units into DTO-friendly values
- provide zero/defaults for unavailable optional inputs
- avoid passing NaN/Inf into the core
- own persistence/UI/licensing concerns
- call core engines in a consistent order
- reset state when game/session context changes
- map core outputs to the host’s output mechanisms

For SimHub specifically:

- plugin owns `AttachDelegate` names and backward-compatible property exports.
- plugin owns profile compatibility.
- plugin owns Direct Telemetry output mapping.
- plugin should not reintroduce core effect logic.

---

## 10. Current engine ownership map

| Effect / system | Current owner | Notes |
|---|---|---|
| Suspension vibration/impact | `SuspensionEngine` | core-owned; includes oscillation refinement |
| BrakeFeel / ABS / lock | `AbsLockEngine` through codec path | planned timing refinement |
| TyreScrub | `TyreStackEngine` | wheel-speed character refinement implemented |
| Engine & Tyres | `TyreStackEngine` | context gate implemented; audit pending |
| RoadFeel | `RoadFeelEngine` | speed-response refinement implemented |
| Powertrain/drivetrain/shift | `PowertrainEngine` | ClutchEngagement/DrivelineBite planned |
| ST Tensioner / arbiter | `StTensionerEngine` | core-owned |
| ST Balancer / Learner | `StAdaptiveEngine` | core-owned |
| Direct Telemetry comparison | plugin output layer | intentionally strict, no reconstruction |
| Replay/conformance | `MCP4SH.Conformance` | separate tool, references core only |

---

## 11. Planned next contract extensions

### 11.1 ClutchEngagement / DrivelineBite

Likely core location:

```text
PowertrainEngine
```

Purpose:

- clutch bitepoint / drivetrain reconnect flutter after manual shifts
- torque mismatch shake
- immersive manual-shift feedback

### 11.2 Brake-state refinement

Likely core location:

```text
AbsLockEngine
```

Purpose:

- remove false early ABS/lock chatter
- bring real lock onset forward when hard braking/decelerating
- keep existing shut-up/decay behavior

### 11.3 Future semantic lanes

Planned later:

- RearTractionTransition
- Flatspot
- SustainedLoad / BodyLoad
- Gear grind / deeper shift refinement
- Motion-aware refinement

---

## 12. Versioning note

This v0 contract documents the current post-split architecture. It is not yet a public SDK/API promise.

Public SDK/API design remains future work and should happen only after:

```text
core split complete
→ refinements stabilized
→ conformance harness matured
→ core contract validated
→ MCP4H compliance map drafted
```
