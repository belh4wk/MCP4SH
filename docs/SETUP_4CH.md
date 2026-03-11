# MCP4SH™ — Recommended 4-Channel Setup (author reference layout)

This document describes the reference layout used to tune the MCP4SH stack. It is a strong starting point, not a universal law.

------------------------------------------------------------
1. Hardware overview
------------------------------------------------------------

Two stereo amplifiers, four transducers:

**Amp A — TT25-16 style pucks**

- Channel A1 → Backrest puck (seat back)
- Channel A2 → Brake pedal puck

**Amp B — BST-1 style shakers**

- Channel B1 → Rear chassis / rear seat frame shaker
- Channel B2 → Front chassis / pedal plate shaker

In SimHub you expose these as two custom outputs:

- Output `Backrest / Brake`
- Output `Rear axle / Front axle`

------------------------------------------------------------
2. Design philosophy
------------------------------------------------------------

The rig is treated as one chassis with three broad domains:

- **Mechanical / resonance layer** — backrest
  - engine harmonics
  - drivetrain load
  - selected gearbox-domain information
- **Brake domain** — pedals
  - brake feel
  - ABS pulses
  - slip spikes under braking
- **Chassis / mass layer** — BST-1s
  - tyre scrub
  - road texture (front / rear split)
  - suspension impacts and undulation
  - base engine / drivetrain mass coupling

Some signal bands intentionally overlap to create a coherent perception of one car, not isolated actuators.

------------------------------------------------------------
3. Effect routing — Amp A (Backrest & Brake)
------------------------------------------------------------

Columns:

- `Backrest` = Amp A1 (seat-back TT25-16)
- `Brake`    = Amp A2 (pedal TT25-16)

| Effect               | Row   | Backrest | Brake |
|----------------------|-------|----------|-------|
| ABS                  | Front | OFF      | ON    |
|                      | Rear  | OFF      | ON    |
| Brake and Slip       | Front | OFF      | ON    |
|                      | Rear  | OFF      | ON    |
| Brake Feel           | Front | OFF      | ON    |
|                      | Rear  | OFF      | ON    |
| Clutch Freewheel     | Front | OFF      | ON    |
|                      | Rear  | ON       | OFF   |
| Drivetrain           | Front | ON       | OFF   |
|                      | Rear  | ON       | OFF   |
| Engine               | Front | ON       | OFF   |
|                      | Rear  | ON       | OFF   |
| Engine & Tyres       | Front | ON       | OFF   |
|                      | Rear  | ON       | OFF   |
| Gearbox — Grinds     | Front | OFF      | OFF   |
|                      | Rear  | OFF      | OFF   |
| Gearbox — Shifts     | Front | ON       | ON    |
|                      | Rear  | ON       | OFF   |
| Road Feel — Front    | Front | OFF      | OFF   |
|                      | Rear  | OFF      | OFF   |
| Road Feel — Rear     | Front | OFF      | OFF   |
|                      | Rear  | OFF      | OFF   |
| Suspension Impacts   | Front | ON       | OFF   |
|                      | Rear  | ON       | OFF   |
| Suspension Vibration | Front | OFF      | OFF   |
|                      | Rear  | OFF      | OFF   |
| TC                   | Front | ON       | OFF   |
|                      | Rear  | ON       | OFF   |
| Tyre Scrub           | Front | ON       | OFF   |
|                      | Rear  | ON       | OFF   |

------------------------------------------------------------
4. Effect routing — Amp B (Rear & Front BST-1s)
------------------------------------------------------------

Columns:

- `Rear BST`  = Amp B1 (rear structure)
- `Front BST` = Amp B2 (pedal plate)

| Effect               | Row   | Rear BST-1 | Front BST-1 |
|----------------------|-------|------------|-------------|
| ABS                  | Front | OFF        | ON          |
|                      | Rear  | ON         | OFF         |
| Brake and Slip       | Front | OFF        | ON          |
|                      | Rear  | ON         | OFF         |
| Brake Feel           | Front | OFF        | ON          |
|                      | Rear  | ON         | OFF         |
| Clutch Freewheel     | Front | OFF        | ON          |
|                      | Rear  | ON         | OFF         |
| Drivetrain           | Front | OFF        | ON          |
|                      | Rear  | ON         | OFF         |
| Engine               | Front | OFF        | ON          |
|                      | Rear  | ON         | OFF         |
| Engine & Tyres       | Front | OFF        | ON          |
|                      | Rear  | ON         | OFF         |
| Gearbox — Grinds     | Front | OFF        | OFF         |
|                      | Rear  | OFF        | OFF         |
| Gearbox — Shifts     | Front | OFF        | ON          |
|                      | Rear  | ON         | OFF         |
| Road Feel — Front    | Front | OFF        | ON          |
|                      | Rear  | OFF        | OFF         |
| Road Feel — Rear     | Front | OFF        | OFF         |
|                      | Rear  | ON         | OFF         |
| Suspension Impacts   | Front | OFF        | ON          |
|                      | Rear  | ON         | OFF         |
| Suspension Vibration | Front | OFF        | ON          |
|                      | Rear  | ON         | OFF         |
| TC                   | Front | OFF        | ON          |
|                      | Rear  | ON         | OFF         |
| Tyre Scrub           | Front | OFF        | ON          |
|                      | Rear  | ON         | OFF         |

This arrangement preserves front/rear timing while letting the chassis behave like one connected system.

------------------------------------------------------------
5. Adapting to other rigs
------------------------------------------------------------

If you have fewer or more transducers:

- **2-channel rigs**
  - combine backrest + rear into a broader “seat / chassis” channel
  - combine brake + front into a broader “front / pedal” channel
  - reduce gains aggressively to avoid masking

- **6- or 8-channel rigs**
  - mirror the same logic into more specific corners or zones
  - keep at least one dedicated brake-domain transducer if possible
  - do not destroy the domain logic just because you have more channels

Always start conservative. Add intensity only after you understand what each domain is doing.
