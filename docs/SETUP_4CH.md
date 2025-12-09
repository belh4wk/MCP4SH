# MCP4SH™ – Recommended 4-Channel Setup (Author's flavour)

This document describes the reference layout used to tune the
MCP4SH v0.4.0-preview1 profile. It matches the routing presets and the
effect design.

------------------------------------------------------------
1. Hardware overview
------------------------------------------------------------

Two stereo amplifiers, four transducers:

**Amp A – TT25-16 pucks**

- Channel A1 → Backrest puck (seat back)
- Channel A2 → Brake pedal puck

**Amp B – BST-1 shakers**

- Channel B1 → Rear BST-1 (rear seat frame / rear structure)
- Channel B2 → Front BST-1 (under pedal plate)

In SimHub you expose these as two custom outputs:

- Output "Backrest / Brake" → Amp A
- Output "Rear axle / Front axle" → Amp B

------------------------------------------------------------
2. Design philosophy (“Author's flavour”)
------------------------------------------------------------

The rig is treated as one chassis made of three domains:

- **Mechanical / resonance layer** – backrest
  - Engine harmonics
  - Drivetrain load
  - Gearbox shifts / freewheel pulses
- **Brake domain** – pedals
  - Brake feel
  - ABS pulses
  - Slip spikes under braking
- **Chassis / mass layer** – BST-1s
  - Tyre scrub
  - Road texture (front / rear split)
  - Suspension impacts and undulation
  - Base engine / drivetrain mass coupling

Some signal bands intentionally overlap to create a coherent
perception of one car, not isolated actuators.

------------------------------------------------------------
3. Effect routing – Amp A (Backrest & Brake)
------------------------------------------------------------

Columns:

- `Backrest` = Amp A1 (seat back TT25-16)
- `Brake`    = Amp A2 (pedal TT25-16)

| Effect              | Row   | Backrest | Brake |
|---------------------|-------|----------|-------|
| ABS                 | Front | OFF      | ON    |
|                     | Rear  | OFF      | ON    |
| Brake and Slip      | Front | OFF      | ON    |
|                     | Rear  | OFF      | ON    |
| Brake Feel          | Front | OFF      | ON    |
|                     | Rear  | OFF      | ON    |
| Clutch Freewheel    | Front | OFF      | ON    |
|                     | Rear  | ON       | OFF   |
| Drivetrain          | Front | ON       | OFF   |
|                     | Rear  | ON       | OFF   |
| Engine              | Front | ON       | OFF   |
|                     | Rear  | ON       | OFF   |
| Engine & Tyres      | Front | ON       | OFF   |
|                     | Rear  | ON       | OFF   |
| Gearbox – Grinds    | Front | OFF      | OFF   |
|                     | Rear  | OFF      | OFF   |
| Gearbox – Shifts    | Front | ON       | ON    |
|                     | Rear  | ON       | OFF   |
| Road Feel – Front   | Front | OFF      | OFF   |
|                     | Rear  | OFF      | OFF   |
| Road Feel – Rear    | Front | OFF      | OFF   |
|                     | Rear  | OFF      | OFF   |
| Suspension Impacts  | Front | ON       | OFF   |
|                     | Rear  | ON       | OFF   |
| Suspension Vibration| Front | OFF      | OFF   |
|                     | Rear  | OFF      | OFF   |
| TC                  | Front | ON       | OFF   |
|                     | Rear  | ON       | OFF   |
| Tyre Scrub          | Front | ON       | OFF   |
|                     | Rear  | ON       | OFF   |

This matches the current working profile tested in Assetto
Corsa and other sims.

------------------------------------------------------------
4. Effect routing – Amp B (Rear & Front BST-1s)
------------------------------------------------------------

Columns:

- `Rear BST`  = Amp B1 (rear frame)
- `Front BST` = Amp B2 (pedal plate)

| Effect              | Row   | Rear BST-1 | Front BST-1 |
|---------------------|-------|------------|-------------|
| ABS                 | Front | OFF        | ON          |
|                     | Rear  | ON         | OFF         |
| Brake and Slip      | Front | OFF        | ON          |
|                     | Rear  | ON         | OFF         |
| Brake Feel          | Front | OFF        | ON          |
|                     | Rear  | ON         | OFF         |
| Clutch Freewheel    | Front | OFF        | ON          |
|                     | Rear  | ON         | OFF         |
| Drivetrain          | Front | OFF        | ON          |
|                     | Rear  | ON         | OFF         |
| Engine              | Front | OFF        | ON          |
|                     | Rear  | ON         | OFF         |
| Engine & Tyres      | Front | OFF        | ON          |
|                     | Rear  | ON         | OFF         |
| Gearbox – Grinds    | Front | OFF        | OFF         |
|                     | Rear  | OFF        | OFF         |
| Gearbox – Shifts    | Front | OFF        | ON          |
|                     | Rear  | ON         | OFF         |
| Road Feel – Front   | Front | OFF        | ON          |
|                     | Rear  | OFF        | OFF         |
| Road Feel – Rear    | Front | OFF        | OFF         |
|                     | Rear  | ON         | OFF         |
| Suspension Impacts  | Front | OFF        | ON          |
|                     | Rear  | ON         | OFF         |
| Suspension Vibration| Front | OFF        | ON          |
|                     | Rear  | ON         | OFF         |
| TC                  | Front | OFF        | ON          |
|                     | Rear  | ON         | OFF         |
| Tyre Scrub          | Front | OFF        | ON          |
|                     | Rear  | ON         | OFF         |

This provides clear front/rear axle timing and lets the chassis
“sing” under load without drowning the TT25-16 detail.

------------------------------------------------------------
5. Adapting to other rigs
------------------------------------------------------------

If you have fewer or more transducers:

- 2-channel rigs:
  - Map Backrest + Rear BST-1 together as a single “seat” channel.
  - Map Brake + Front BST-1 together as a “front / pedals” channel.
  - Reduce gains on non-critical effects to avoid masking.

- 6- or 8-channel rigs:
  - Mirror the same logic to individual corners (FL/FR/RL/RR).
  - Keep the backrest for engine/gearbox.
  - Keep at least one dedicated brake-domain transducer if possible.

Always start with conservative gains and add intensity gradually.
