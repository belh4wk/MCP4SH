# MCP4H Compliance Map v0

**Project:** MCP4SH  
**Protocol family:** MCP4H™ — Multimodal Communications Protocol For Humanity  
**Document status:** v0 working map  
**Purpose:** describe how MCP4SH currently maps to MCP4H concepts, where it already behaves as a reference implementation, and what remains to formalize.

---

## 1. Scope

This document maps the current MCP4SH architecture to MCP4H concepts. It is not a final certification document and does not claim complete protocol compliance yet.

MCP4SH currently acts as:

```text
sim/game telemetry
→ SimHub adapter/plugin
→ MCP4SH.Core semantic haptics processing
→ SimHub-exposed haptic output properties
→ user hardware/profile rendering
```

The key architectural claim is that MCP4SH is no longer merely a SimHub effect/profile bundle. The plugin is now primarily the host adapter, while `MCP4SH.Core` owns the signal interpretation, semantic shaping, arbitration, and replayable haptic behavior.

---

## 2. MCP4SH role in MCP4H terms

MCP4SH maps to MCP4H as a domain-specific reference implementation for sim-racing haptics.

| MCP4H concept | MCP4SH implementation |
|---|---|
| Signal source | Game/sim telemetry via SimHub |
| Adapter | MCP4SH plugin / SimHub property reads |
| Semantic processing core | `MCP4SH.Core` |
| Cue interpretation | RoadFeel, TyreScrub, Suspension, Brake/ABS/Lock, Powertrain, ST layers |
| Modality | Haptic / tactile output through SimHub ShakeIt Bass Shakers |
| Output surface | SimHub properties consumed by user profiles |
| Replay/proof layer | `MCP4SH.Conformance` replay/trace harness |
| Direct comparison path | Processing Mode: Direct Telemetry |
| Normalized interpretation path | Processing Mode: MCP4SH Codec |

MCP4SH is therefore best described as:

```text
an MCP4H-style haptic translation layer that turns inconsistent sim telemetry into clearer, normalized, priority-aware tactile cues.
```

---

## 3. Current boundary contract

The current design boundary is:

### Plugin owns

- SimHub lifecycle
- SimHub property reads
- UI and settings controls
- profile/per-game persistence
- logging toggles and replay log writing
- licensing / paid feature gating
- public SimHub delegate/property names
- final handoff into SimHub profiles

### Core owns

- effect lane processing
- telemetry normalization where appropriate
- semantic cue shaping
- stateful effect envelopes
- wheel-speed-aware TyreScrub character
- RoadFeel speed response
- Suspension vibration/impact logic
- Brake/ABS/lock logic
- Powertrain / Engine & Tyres / drivetrain logic
- ST Tensioner / arbiter behavior
- ST Adaptive / Balancer / Learner behavior

### Conformance tool owns

- replay CSV loading
- mapping replay frames into core DTOs
- frame-by-frame core execution
- trace CSV output for regression/proof work

---

## 4. Processing modes

MCP4SH currently exposes two processing modes.

### MCP4SH Codec

The default normalized path. This mode may use:

- normalized telemetry
- reconstructed/fallback signals where appropriate
- semantic interpretation
- smoothing/envelope shaping
- ST Tensioner priority/ducking behavior
- ST Adaptive/Balancer/Learner gain behavior
- core-managed cross-sim consistency logic

This is the MCP4H-aligned interpretation path.

### Direct Telemetry

The comparison path. This mode intentionally uses only direct game/SimHub values where available.

Direct Telemetry mode should not use:

- MCP4SH reconstruction
- fallback telemetry synthesis
- inferred semantic cues
- ST Tensioner shaping
- ST Balancer/Learner adaptive shaping

If a game does not expose a usable direct value, the corresponding output may go quiet or dead. This is intentional and useful: it demonstrates the gap between direct telemetry and codec-shaped interpretation.

---

## 5. Semantic lane mapping

| MCP4SH lane | MCP4H-style meaning | Current status |
|---|---|---|
| RoadFeel | Rolling speed + surface texture cue | Implemented in core; uses base/full speed response |
| TyreScrub | Contact-patch distress, scrub, grab, hop, smear | Implemented in core; wheel-speed-aware character refinement |
| Suspension Vibration | Suspension/body oscillation and movement texture | Implemented in core; recent oscillation refinement |
| Suspension Impact | Sharp chassis/suspension impact event | Implemented in core |
| BrakeFeel | Brake pressure / bite / deceleration cue | Implemented, needs semantic refinement |
| BrakeLock / ABS | Control-limit cue for lock/ABS intervention | Implemented, timing refinement planned |
| Engine & Tyres | Loaded torque/contact interaction cue | Implemented with context gate; light audit planned |
| Drivetrain | Mechanical load/tension cue | Implemented in core |
| ClutchFree | Clutch/freewheel/disconnection cue | Implemented in core |
| GearShift | Shift event cue | Implemented; gear grind/deeper refinement pending |
| ST Tensioner | Arbiter / anti-mush / priority shaping layer | Implemented in core |
| ST Adaptive | Adaptive gain/balancing/learner support | Implemented in core |
| Direct Telemetry | Non-reconstructed comparison path | Implemented in plugin-facing output selection |

---

## 6. Planned semantic lanes not yet fully implemented

These are planned MCP4H-aligned cue lanes, but not yet complete implementation targets.

| Planned lane | Intended meaning | Current priority |
|---|---|---|
| ClutchEngagement / DrivelineBite | Bitepoint, flutter, shake, torque reconnect after manual shift/clutch release | v1.1 high priority |
| RearTractionTransition | Rear lightening, rotation build, breakaway, recovery | Stretch |
| Flatspot | Periodic wheel-speed-linked damaged tyre cue | Stretch |
| SustainedLoad / BodyLoad | Longitudinal/lateral/vertical load pressure, g-force-like body cue | Stretch |
| Diff / driveline nuance | Diff bind/release and driveline tension nuance | Later / clarify with ClutchEngagement |
| GearGrind | Distinct wrong/failed shift cue | Stretch |
| Motion-aware output | Motion-specific interpretation of load/suspension/traction cues | Later |

---

## 7. Input mapping

MCP4SH currently receives or derives the following input categories.

| Input category | Examples | Notes |
|---|---|---|
| Vehicle state | speed, gear, RPM, throttle, brake, clutch, handbrake, steering | Plugin reads from SimHub/game properties |
| Wheel state | per-wheel speed, per-wheel slip, tyre intensity | Wheel-speed data is important for TyreScrub character |
| Tyre state | front/rear slip intensity, tyre load/texture proxies | Some values are direct, some are codec-normalized |
| Brake state | brake input, lock tendency, ABS/lock output | Refinement planned for timing/separation |
| Suspension state | raw travel/damper where available, fallback where needed | Processed in `SuspensionEngine` |
| Motion/platform state | surge, sway, heave and related proxies | Motion-specific refinement later |
| Road/surface state | surface grain/harshness where available | Used as available, with fallback behavior in codec mode |
| ST/adaptive state | premium state, ST settings, activity samples | Core handles ST/adaptive math; plugin owns UI/licensing |

---

## 8. Output intent mapping

Current MCP4SH outputs are exposed as SimHub properties, not formal MCP4H output-intent envelopes yet. Conceptually they map as follows.

| Current output family | Future MCP4H-style output intent |
|---|---|
| `RoadFeel.Front/Rear` | `haptic.texture.road.front/rear` |
| `TyreScrub.Front/Rear` | `haptic.texture.scrub.front/rear` |
| `Suspension.Vibration*` | `haptic.body.suspension.oscillation` |
| `Suspension.Impact*` | `haptic.event.suspension.impact` |
| `BrakeFeel.Front/Rear` | `haptic.control.brake.pressure` |
| `BrakeLock.Front/Rear` | `haptic.control.brake.limit` |
| `EngineTyres.Front/Rear` | `haptic.texture.loaded-contact` |
| `Drivetrain.Front/Rear` | `haptic.mechanical.drivetrain.load` |
| `GearShift*` | `haptic.event.shift` |
| `ClutchFree` | `haptic.mechanical.clutch.freewheel` |
| ST Tensioner outputs | `arbiter.priority`, `arbiter.ducking`, `arbiter.hero-gain` |

Future compliance work should introduce a formal output-intent DTO that can sit beneath SimHub delegates and future standalone outputs.

---

## 9. Confidence and availability

MCP4SH already has the practical distinction between direct availability and reconstructed codec behavior, but this is not yet formalized as metadata.

Current behavior:

- Direct Telemetry mode exposes only directly available game/SimHub values.
- MCP4SH Codec mode may reconstruct, normalize, smooth, or infer useful haptic signals.
- Missing direct data may cause Direct mode outputs to go quiet.
- Missing direct data may still produce Codec outputs where reconstruction/fallback logic is appropriate.

Future MCP4H-aligned metadata should include:

```text
availability: direct | reconstructed | inferred | unavailable
confidence: 0.0–1.0
source: game property / fallback / derived / adaptive
validity window: frame/timestamp scope
```

This is especially important for standalone, partner-facing demos, and cross-sim explainability.

---

## 10. Replay / conformance mapping

`MCP4SH.Conformance` currently provides a v0 replay/trace harness.

Current flow:

```text
MCP4SH_Replay_*.csv
→ ReplayLoader
→ ReplayMapper
→ MCP4SH.Core engines
→ TraceWriter
→ trace_*.csv
```

Current purpose:

- prove that `MCP4SH.Core` can be driven outside SimHub
- generate output traces for regression investigation
- compare observed plugin outputs with replayed core outputs
- prepare for standalone and adapter validation

Current status:

- trace generation works
- replay logs process successfully
- output traces are useful for inspection
- not yet a strict pass/fail golden conformance runner

Future steps:

- define golden trace segments
- add tolerance-based checks
- add pass/fail summaries
- cover AC, AMS2, and at least one telemetry-poor title/profile
- support mode-specific conformance expectations: Direct vs Codec

---

## 11. Known v0 gaps

The following are intentional or accepted gaps at this stage.

1. Current outputs are SimHub properties, not formal MCP4H envelopes.
2. Output-intent DTOs are not yet implemented.
3. Availability/confidence metadata is not yet attached to outputs.
4. Native per-corner TyreScrub output is not yet implemented.
5. Brake-state semantics are not yet fully separated into bite/threshold/lock/ABS.
6. ClutchEngagement / DrivelineBite is planned but not implemented.
7. The conformance harness is trace-based, not pass/fail.
8. Direct-vs-Codec comparison is implemented, but not yet represented as formal protocol metadata.
9. Motion output semantics are not yet mature.
10. Full MCP4H compliance is directional, not final.

---

## 12. v1.1-aligned next compliance work

The next implementation and documentation steps should be:

1. Finish active suspension vibration validation/tuning.
2. Add ClutchEngagement / DrivelineBite as a core-owned semantic lane.
3. Refine Brake-state timing and semantics in `AbsLockEngine`.
4. Keep E&T audit light unless standstill/leakage issues return.
5. Extend replay/conformance with golden traces after more runtime behavior stabilizes.
6. Formalize the output-intent DTO shape.
7. Add availability/confidence metadata to core outputs.
8. Update this compliance map when each semantic lane is implemented.

---

## 13. Compliance status summary

| Area | Status |
|---|---|
| Core/plugin boundary | Mostly complete |
| Runtime semantic core | Implemented for major current lanes |
| Direct vs Codec distinction | Implemented |
| Replay/conformance v0 | Implemented, trace-based |
| Formal core contract | Drafted separately |
| Formal MCP4H output envelopes | Not yet implemented |
| Availability/confidence metadata | Not yet implemented |
| Standalone-ready adapter model | Directionally prepared, not implemented |
| Full MCP4H compliance | In progress / partial |

---

## 14. Working definition of MCP4SH compliance direction

MCP4SH is MCP4H-aligned when:

1. telemetry is separated from interpretation;
2. interpretation is core-owned and replayable;
3. output cues carry clear semantic meaning;
4. missing data handling is explicit;
5. reconstructed cues are distinguishable from direct cues;
6. adapters can render the same core output through different host environments;
7. conformance traces can prove that behavior remains stable across changes.

MCP4SH already satisfies parts 1, 2, 3, and 7 in early form. Parts 4, 5, and 6 are partially implemented and should be formalized next.
