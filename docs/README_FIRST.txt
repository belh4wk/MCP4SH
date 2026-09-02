MCP4SH™ — Read this first
==========================

Thank you for trying MCP4SH™.

MCP4SH is the SimHub implementation of MCP4H™
(Multimodal Communications Protocol For Humanity) for sim racing.
It turns telemetry into a layered haptics stack instead of a pile of disconnected vibrations.

Typical domains include:

- chassis mass and road texture
- engine / drivetrain / gearbox resonance
- braking-domain cues
- tyre phase and scrub behavior
- suspension impacts and undulation

Bonus: MCP4SH also includes a built-in FOV calculator in the settings UI.

This build is part of the current supported MCP4SH release line.
It is public-facing and supported, while tuning, hardware coverage and title coverage continue to evolve.

======================================================================
MCP4SH™ ST Haptics — setup notes
======================================================================
This stack is designed to simulate:
- tyre phases (grip, slip, scrub)
- suspension compression and undulation
- drivetrain and rotational resonance
- gearbox harmonics (shift, grind, load)
- braking surface cues (feel, slip, ABS)
- engine mass and harmonic layers

Current release focus:
- clearer public-facing documentation
- guided first-run setup and physical channel mapping
- preserved layered “single chassis” haptics philosophy
- continued real-world validation across rigs and sims
- exact multichannel proof-pulse routing for mapped shaker locations

Effects are designed to overlap intentionally in some bandwidths so the rig behaves like one coherent mass rather than isolated shakers.

IMPORTANT GAIN RULE:
- Do not start by changing SimHub ShakeIt Bass Shakers Effect Profile per-effect gains.
- Start with the gains inside the MCP4SH plugin UI.
- Then tune SimHub global/master output for your rig.
- Only after that should you touch per-effect gains, if needed.

Reference hardware used during development (example BST + TT25 system):
- Front: BST-1 under pedal plate, TT25-16 on brake pedal
- Rear: BST-1 on rear seat frame / structure, TT25-16 in the backrest
- Optional extra: TT25-16 on the handbrake/shifter side for dedicated use cases

Global gain must be tuned per rig.

Commonly tested with: Assetto Corsa variants, AMS2, F1 titles, Project Motor Racing,
DR2.0, PC2, R3E, Forza Horizon titles, LMU, GRID Legends, Wreckfest, and multiple WRC titles.

------------------------------------------------------------------
1. Reference layout philosophy
------------------------------------------------------------------

The supplied effect-routing logic assumes a layered rig:
- Backrest domain:
  - engine note and harmonics
  - drivetrain load
  - selected gearbox-domain events
- Brake domain:
  - brake feel
  - ABS pulses
  - brake slip information
- Chassis domain:
  - tyre scrub
  - road texture
  - suspension impacts and undulation
  - base load coupling from engine and drivetrain

The point is not “more noise.”
The point is clarity through structure.

------------------------------------------------------------------
2. Installing the plugin
------------------------------------------------------------------

1) Install the current MCP4SH release package into your SimHub environment.
2) Start SimHub.
3) Go to Add/remove features and enable **MCP4SH**.
4) Restart SimHub if prompted.

If your release package includes an installer, verify its checksum first.
See:
- `SECURITY.md`
- `INSTALLER_SECURITY.md`

------------------------------------------------------------------
3. Importing profiles and mapping physical outputs
------------------------------------------------------------------

Use Setup Assistant to create routing for the actual physical rig:

1) Open **MCP4SH Setup Assistant**.
2) Select the shaker / haptic locations present on your rig.
3) Select the intended output device and use test pulses to identify the physical channels.
4) Complete the mapping and generate the matching SimHub `.sichannels` output profile.
5) Use SimHub Helper to import/apply the generated output profile and the supplied canonical MCP4SH effects profile.
6) Verify the resulting device/channel assignments match what you physically mapped.

Physical channel maps are generated locally for the user's hardware; MCP4SH does not ship a generic remote `.sichannels` map as authoritative routing.

The supplied v1.1.12 Standard and 4 Corners `.siprofile` files remain the canonical v1.1.13.x effects-profile baseline. Treat them as the supported starting point and use the locally generated physical mapping for your rig.

------------------------------------------------------------------
4. What you should feel
------------------------------------------------------------------

MCP4SH is built around a layered harmonics model:
- Backrest / seat-back style transducers:
  - engine harmonics
  - drivetrain load
  - selected shift and freewheel behavior
- Brake-domain transducers:
  - brake feel under your foot
  - ABS pulses
  - brake-slip events
- Chassis / axle transducers:
  - tyre scrub
  - road texture
  - suspension impacts and undulation
  - broad chassis load and resonance

Some effects intentionally overlap so the rig feels like one chassis instead of unrelated actuators firing in random order.

------------------------------------------------------------------
5. Known caveats
------------------------------------------------------------------

- Hardware matters a lot.
- Some games expose far better telemetry than others.
- SimHub in the foreground can hurt FPS on some systems.
- Certain low-speed or edge-case effects may still feel stronger than ideal depending on rig layout and gains.

That is exactly why the gain order matters.

------------------------------------------------------------------
6. Logging and debugging
------------------------------------------------------------------

MCP4SH can optionally log CSV data into:

    SimHub/Logs/MCP4SH/

There are two main logging modes:

- General debug logging
- Extra tyre / slip logging

Use them when something feels wrong or when comparing how different sims behave.

When sending a report, include:
- game
- car
- track
- short description of the issue
- any gain or routing changes you made

See `docs/LOGGING.md` for more detail.

------------------------------------------------------------------
7. License reminder
------------------------------------------------------------------

By using this build you agree to the terms in:

- `LICENSE_PLUGIN.txt`

For the public plain-English licensing overview, see:

- `docs/LICENSING.md`

In plain English:
- personal use only unless separately agreed
- do not redistribute the package or DLL without permission
- do not rebrand it
- feedback and impressions are fine to share publicly
