MCP4SH™ – Read this first (preview testers)
===========================================

Thank you for helping test the MCP4SH™ SimHub plugin.

MCP4SH is the SimHub implementation of MCP4H™
(Multimodal Communications Protocol For Humanity) for sim racing.
It turns telemetry into a layered haptics stack:

- Chassis mass and road texture (BST-1s)
- Engine / drivetrain / gearbox resonance (backrest TT25-16)
- Brake-domain cues (pedal puck – ABS, slip, brake feel)

This build is a **preview**, non-commercial, and may change between
versions.

------------------------------------------------------------------
1. Reference hardware layout (Author's flavour)
------------------------------------------------------------------

The supplied profile and routing are tuned for a 4-transducer rig:

- Backrest puck (TT25-16) on the seat back
- Brake pedal puck (TT25-16) on or near the pedal assembly
- Rear BST-1 on the rear seat frame / main chassis
- Front BST-1 under the pedal plate

Amps:

- Amp A (TT25-16s)
  - Channel A1 → Backrest
  - Channel A2 → Brake pedal
- Amp B (BST-1s)
  - Channel B1 → Rear BST
  - Channel B2 → Front BST

You can adapt this to other layouts, but expect to tweak gains.

------------------------------------------------------------------
2. Installing the plugin
------------------------------------------------------------------

1) Copy MCP4SH.dll into your SimHub plugins folder, e.g.:

   SimHub/MCP4SH.dll

2) Start SimHub.
3) Go to Add/remove features and enable **MCP4SH**.
4) Restart SimHub if prompted.

------------------------------------------------------------------
3. Importing the effects profile
------------------------------------------------------------------

1) Open **ShakeIt Bass Shakers** in SimHub.
2) In the profiles list, choose **Import**.
3) Select the supplied profile:

   Documents/SimHub/Any Game - MCP4SH™ Effects Profile v0.3-preview.siprofile

4) Set it to apply to **Any game**, or to specific sims you want to
   test (AC, AMS2, PMR, etc.).

Notes:

- The profile does **not** include routing. Routing is stored in
  separate `.sichannels` files.
- Global gain is **not** fixed; start low and adjust for your rig.

------------------------------------------------------------------
4. Loading the routing presets
------------------------------------------------------------------

Two routing presets are provided (for reference only, modify as needed for your setup):

- Backrest / Brake pedal mapping (Amp A)
- Rear axle / Front axle mapping (Amp B)

1) Open **Sound Output** in SimHub.
2) Use the Export / Import button → **Import**.
3) Load each of:

   SimHub/Routing/Effect_FR_CH1_left_backrest_CH2_rght_brakepedal.sichannels
   SimHub/Routing/Effect_FR_CH1_left_rearaxle_CH2_rght_frontaxle.sichannels

4) Check that the device/channel assignments match your hardware:
   - Backrest → TT25-16 on seat back
   - Brake    → TT25-16 on pedal
   - Rear axle → Rear BST-1
   - Front axle → Front BST-1

------------------------------------------------------------------
5. What you should feel
------------------------------------------------------------------

MCP4SH is built around a layered “harmonics” model:

- Backrest TT25-16:
  - Engine note and harmonics
  - Drivetrain load
  - Gear shifts and clutch freewheel
- Brake pedal TT25-16:
  - Brake feel under your foot
  - ABS pulses
  - Brake slip events
- Rear & Front BST-1s:
  - Tyre scrub
  - Road texture (front/rear split)
  - Suspension impacts and undulation
  - Base load from engine & drivetrain

Some effects intentionally overlap so the rig feels like a
*single chassis* instead of isolated shakers.

------------------------------------------------------------------
6. Logging and debugging
------------------------------------------------------------------

MCP4SH can optionally log CSV data into:

    SimHub/Logs/MCP4SH/

There are two main toggles in the plugin settings:

- General debug logging
- Extra tyre / slip logging

Use these when something feels off. When sending logs back, include:

- Game, car, track
- Short description of what felt wrong
- Any changes you made to gains or routing

See docs/LOGGING.md for more detail.

------------------------------------------------------------------
7. License reminder
------------------------------------------------------------------

By using this preview build you agree to the terms in:

- LICENSE_PLUGIN.txt
- LICENSE_AGREEMENT_PREVIEW.txt

In short:

- Personal, non-commercial sim usage only.
- Do not resell, rent, or bundle the DLL in paid mod packs.
- Do not publicly redistribute the DLL without permission.
- You may share impressions and feedback publicly, but not internal
  logs with personal/league information unless agreed.
