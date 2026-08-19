# MCP4SH® Setup Assistant

Setup Assistant is the easiest way to get MCP4SH routed correctly.

It is included with the free version.

## What it does

Setup Assistant helps you answer three practical questions:

1. Which shakers are actually installed on your rig?
2. Which sound device and channel reaches each shaker?
3. Which SimHub sound output profile should you use?

That is the boring part of haptics setup, but it is also the part that breaks everything when it is wrong.

## Basic flow

1. Open Setup Assistant from the installer finish screen, Start Menu, or the MCP4SH plugin UI.
2. Select the shakers installed on your rig.
3. Pick your output device.
4. Start mapping.
5. When a channel pulses, click the shaker you felt.
6. Generate the sound output profile.
7. Use SimHub Helper to import/apply the generated `.sichannels` file.
8. Optionally open Frequency Sweeper to calibrate a mapped output and generate a separate tuned `.siprofile` candidate.

Generated files are placed in:

```text
Documents\SimHub\MCP4SH
```


## Frequency Sweeper

Frequency Sweeper is a guided tactile calibration tool for a mapped physical output. It uses the same mapping strength and prefers the first device already present in the user's mapping.

The normal flow is:

1. Output
2. Heavy / rumble
3. Rumble / buzz
4. Buzz / whine
5. Generate

Judge the **physical sensation through the shaker**, not the audible pitch. Mark useful tactile landmarks for each feel range; MCP4SH then builds an effect-frequency map that stays as close as practical to the canonical MCP4SH orchestration while adapting to the hardware that was actually tested.

Generated `.siprofile` files are new files. The canonical supplied profile is never overwritten or silently imported.

## What free users get

Free users can use the core setup flow:

- layout selection
- test pulses
- generated sound output profiles
- SimHub Helper
- profile analysis
- plugin-side mapping/routing display
- live read-only SimHub Sound Output routing readout where available
- shared pulse visualization for MCP4SH-owned test pulses

## What licensed users get

The license is for deeper control, not basic access.

Licensed/advanced work is aimed at:

- more detailed tuning controls
- custom routing/configuration tools
- saved layout/profile variants
- deeper “make it mine” workflows

Free gets you working.  
A license gives you more control.

## Important note

Setup Assistant helps with routing. It does not fix bad mounting, loose rig parts, clipping amps, or bad gain structure.

If you can hear the shaker more than you feel it, check the physical install first.


## Updates and bundled profile notices

Setup Assistant shows plugin/content update status under **SimHub Helper → Updates**. For plugin updates it can stage and SHA-256 verify the installer, launch it, then request a clean SimHub shutdown only after elevation succeeds. SimHub is never force-killed by this handoff.

The profile itself is copied locally by the installer and is normally available at:

```text
Documents\SimHub\MCP4SH
```

MCP4SH does not silently import or activate the profile inside SimHub. Import it manually from SimHub:

```text
ShakeIt Bass Shakers → Effects profile → Profiles manager → Import profile
```

The Updates tab tries to load the latest online `CHANGELOG.md` first and falls back to the bundled local changelog when offline. Update/install failures surface a user-facing message and can generate a local diagnostic report for the user to review before optionally reporting the issue; reports are not uploaded automatically.

Setup Assistant local state is stored under:

```text
%LOCALAPPDATA%\TytoSensoryLabs\MCP4SH\SetupAssistant
```

Older state from `%LOCALAPPDATA%\MCP4SH\SetupAssistant` is migrated automatically when found.

## Process behaviour

The normal interactive Setup Assistant UI is single-instance. Starting it again brings the existing window forward instead of opening a second full UI. Intentional headless pulse/helper operations remain available where required by MCP4SH.
