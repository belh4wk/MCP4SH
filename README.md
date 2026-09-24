**Less buzz. More car. Easier setup.**

MCP4SH® is a SimHub haptics plugin that turns racing-sim telemetry into clearer tactile feedback for bass shakers, transducers, haptic pads, and similar hardware.

Instead of sending raw telemetry straight to your rig, MCP4SH processes, cleans up, shapes, and balances the signals first.

The goal is simple:

**You should feel more of what the car is doing, and less random buzzing.**

MCP4SH is built around the **String Theory Haptics** approach: engine, tyres, braking, suspension, drivetrain, gearshift, and chassis-style load cues working together as one connected system rather than a pile of unrelated vibrations.

---
## What MCP4SH helps you feel

MCP4SH can provide telemetry-driven haptic feedback for:

- road texture
- tyre scrub
- suspension vibration
- bumps and impacts
- brake feel
- ABS / brake lock
- traction control
- engine and drivetrain activity
- clutch / freewheel behaviour
- gearshifts
- chassis load and weight transfer
- combined engine and tyre tension cues

The goal is not simply **more vibration**.

The goal is clearer feedback: making different parts of the car feel different, so your tactile setup becomes easier to understand while driving.

---
## Current supported release

**MCP4SH v1.1.14.1 is the current supported public baseline.**

v1.1.14.1 is a small mapping-convenience hotfix on top of the v1.1.14 install/update reliability release. It does **not** retune the haptics or replace the canonical SimHub profiles.

v1.1.14.1 adds:

- an explicit **Swap saved seat L/R** action for completed physical maps
- a safe, device-scoped **Swap saved front/rear** action for simple front/rear layouts
- preservation of intentional shared-channel assignments when saved routes are swapped
- exclusion of dedicated seat-side and ambiguous multichannel layouts from the front/rear convenience action
- mapping backup and atomic replacement before saved-route changes
- Setup Assistant audio diagnostics updated for the current mapping-repair path

The underlying v1.1.14 maintenance release also includes:

- safer application-in-use detection before MCP4SH executables and DLLs are replaced
- manual-install checks for both known SimHub process names and MCP4SH Setup Assistant
- the clean staged-update handoff used to close SimHub normally before replacement
- explicit close-application handling when Setup Assistant launches a staged installer
- installer logging and additional diagnostics for blocked or failed updates
- release/version consistency across the stable plugin, Core, UI, Setup Assistant, installer, and update manifest

The established v1.1.x baseline carried forward into 1.1.14.1 already includes:

- exact physical device/channel routing for individual mapped shaker proof pulses
- multiple mapped locations only pulsing together when they intentionally share the same physical output channel
- effectively instant plugin-GUI proof pulses using a persistent local renderer
- improved WASAPI multichannel endpoint handling with duplicate endpoint identity cleanup
- safer fail-closed WinMM fallback behaviour
- profile manifest-only changes no longer being shown as new profile updates
- persistent UI text scaling and light/dark presentation controls
- refined Advanced hierarchy and ST Tensioner Premium presentation
- restored Setup Assistant output-device selection memory
- fixed Advanced Settings sliders with live value updates, persistence and mouse-wheel adjustment
- guided hardware-aware frequency calibration and non-destructive tuned `.siprofile` generation
- weight-transfer-assisted Load Breakaway articulation and improved Chassis Load directional/heave expression
- a cleaner MCP4SH.Core / SimHub-adapter boundary for future portability

The supplied **v1.1.12 Standard and 4 Corners `.siprofile` files remain the canonical v1.1.14.1 reference profiles**. Their filenames are intentionally unchanged because v1.1.14.1 does not alter the haptics/profile baseline.

Existing v1.2 Chassis/Airframe preview assets remain previews. The v1.2 development runtime is not part of the v1.1.14.1 stable release.

Older releases may remain available for archival purposes, but the latest release is the supported baseline.

---
## What makes MCP4SH different

MCP4SH is aimed at drivers who want more than a rig that simply shakes harder.

The focus is on:

- clearer separation between useful cues
- more coherent layering across effects
- better signal-to-noise behaviour
- less time wasted retuning every sim from scratch
- a setup flow that does not expect you to be a SimHub wizard

The guiding idea is simple:

**Haptics should help you understand what the car is doing, not bury you in buzzing.**

---
## Designed to scale

MCP4SH is built around a simple architectural idea:

**Specialise at the edges. Standardise the meaning.**

Different simulators expose different telemetry. Different hardware has different capabilities. MCP4SH does not try to pretend those inputs and outputs are identical.

Instead, the aim is to keep simulator-specific and device-specific work at the edges while preserving a shared interpretation layer in between:

```text
Sim / host telemetry
→ specialised input / normalization
→ semantic interpretation
→ orchestration
→ specialised projection / output
```

That means a title can use the best telemetry it exposes without forcing the rest of the haptic stack to become title-specific.

It also means a new output device should not require every supported simulator to be reinterpreted from scratch.

**Normalize meaning, not information.**

The current public implementation runs through SimHub, but the architecture is deliberately separated so the interpretation and orchestration logic is not intended to remain tied to one host, one renderer, or one class of haptic hardware.

---
## Not a standard SimHub effects profile

MCP4SH should not be treated like a standard SimHub effects profile where each effect is just a raw standalone formula.

The plugin works more like a **telemetry-to-haptics codec**.

Before the public outputs reach SimHub, MCP4SH performs internal processing such as:

- telemetry normalization
- signal cleanup
- gating
- routing
- effect balancing
- source prioritization
- ST tensioning / shaping

Because of that, individual graphs or manually separated formulas may not represent the full intended behaviour of the plugin.

Some MCP4SH effects are designed to work together. Looking at one signal in isolation can be misleading, especially in titles where the raw telemetry is noisy, sparse, unusually hot, or different between cars.

---
## Supported reference setup

The supported reference setup is:

- the current MCP4SH plugin build
- the supplied MCP4SH SimHub effects profile
- the supplied or generated channel map
- the MCP4SH Setup Assistant workflow

Manual formula edits, heavily modified profiles, separated effect experiments, or custom routing can be useful for personal testing, but they are outside the normal support baseline.

In plain English:

**If you change the formulas or routing yourself, you are no longer testing the supplied MCP4SH setup.**

---
## Setup Assistant

MCP4SH includes the **Setup Assistant**, which helps with the practical side of getting a tactile rig working.

The Setup Assistant helps you:

- choose the shakers / haptic zones on your rig
- test-pulse output channels
- map what you physically feel
- generate a matching SimHub sound output profile
- open the generated profile folder
- follow the SimHub Helper import flow
- analyze existing sound output profiles
- repair a saved seat left/right assignment without rerunning the full mapping wizard
- swap simple saved front/rear assignments on eligible layouts

In plain English:

**MCP4SH helps you set the thing up instead of just giving you effects and leaving you to fight audio routing by yourself.**

You do not need a huge rig to use it. Smaller setups can still benefit, and larger rigs can use more detailed routing for pedals, seat, backrest, four corners, or other shaker positions.

---
## Typical hardware setups

MCP4SH works with tactile hardware driven through SimHub, including:

- bass shakers
- tactile transducers
- haptic pads
- USB amps
- multi-channel sound cards
- HDMI / audio-interface output chains
- 2-channel, 4-channel, and larger tactile layouts

Common layouts include:

- single seat shaker
- seat + pedal setup
- front / rear setup
- pedal plate + seat setup
- four-corner setup
- seat, backrest, pedals, and corners
- mixed DIY tactile rigs

The Setup Assistant is intended to help map what you physically feel, because real-world channel wiring can vary a lot from one rig to another.

---
## Main haptic effect groups

MCP4SH includes the following main haptic effect groups:

- Engine
- Drivetrain
- Tyre Scrub
- Road Feel
- Suspension Vibrations
- Suspension Impacts
- Brake Feel
- ABS / Brake Lock
- TC
- Clutch Engagement / Freewheel
- Gearshift
- Chassis Load
- Engine & Tyres

Some effects are simple to understand on their own. Others are designed to work together as part of the broader ST Haptics layer.

For example, Tyre Scrub is not meant to be read as a pure outside-tyre load signal. It reflects tyre scrub / slip activity, so it may not always mirror chassis load direction in a corner.

---
## TCR — Telemetry Clarity Rating

**TCR** means **Telemetry Clarity Rating**.

TCR is a practical expectation label for how clearly a title's telemetry translates into MCP4SH ST Haptics.

It is not a ranking of which sim is **best**.

It is a clarity label for the kind of telemetry signal MCP4SH receives and can work with.

Current labels:

| Tier | Label | What it means |
| --- | --- | --- |
| Titanium | Clean | Clean telemetry with strong signal separation. Core cues translate clearly and predictably. |
| Platinum | Balanced | Well-behaved telemetry with minor texture or noise. Most cues stay easy to read. |
| Gold | Rough but Usable | More active or rough telemetry, but surface changes and important cues remain distinguishable. |
| Silver | Busy / Noisy | Dense or noisy telemetry. Expect a busier baseline and less separation between some effects. |
| Bronze | Sparse | Limited or incomplete telemetry. Some cues may be inferred, simplified, or subtle. |
| Grey | Unknown | Not enough MCP4SH validation yet. Feedback may still work, but the title has not been classified. |

TCR is there to set expectations. Different games, cars, and telemetry sources can behave differently.

---
## Free version

The free version is not a crippled demo.

Free gives you the core MCP4SH String Theory Haptics experience and the Setup Assistant.

That means you can:

- run the main MCP4SH haptic effects in SimHub
- use the Setup Assistant to select the shakers installed on your rig
- test-pulse channels so you know what is physically connected where
- generate a matching SimHub sound output profile
- use the SimHub Helper guide to import and apply that profile
- analyze existing sound output profiles
- see mapped device / channel / effect information inside the plugin
- use the shared pulse visualization while testing mapped shakers

In plain English:

**Free gets you driving.**

---
## Premium / licensed version

**MCP4SH Premium** unlocks the extra control layer.

Free gets the core experience working. Premium gives you more ways to shape it around your own rig.

Premium currently includes the advanced haptic fine-tuning controls and the **ST Tensioner**, which dynamically prioritizes effects to help reduce unnecessary/unwanted buzzing while preserving useful tactile information.

Additional licensed configuration tools may expand over time.

It is for people who want to go beyond:

> This works.

and move toward:

> This feels right for my setup.

A Premium license also directly supports continued MCP4SH development.

The store listing is the source of truth for the current price, entitlement and included licensed features.

**Free gets you driving.  
Premium gives you control.**

---
## Download and installation

1. Go to GitHub Releases.
2. Download the current MCP4SH installer asset.
3. Verify the SHA-256 checksum if desired.
4. Run the installer, or use Setup Assistant → SimHub Helper → Updates.
5. If SimHub or MCP4SH Setup Assistant is still open, the v1.1.14/1.1.14.1 installer/update path performs safer application-in-use handling before replacing MCP4SH files.
6. The built-in updater can request a normal SimHub shutdown after elevation succeeds; it does not force-kill SimHub.
7. Start SimHub if it was not restarted automatically by the updater.
8. Enable MCP4SH if SimHub prompts you.
9. Open the MCP4SH plugin tab.
10. Launch the Setup Assistant.
11. Select your rig layout / shaker zones.
12. Run the test pulses.
13. Generate a sound output profile.
14. Import / apply it in SimHub using the SimHub Helper guidance.
15. Go drive.

Generated sound-output profiles and bundled MCP4SH SimHub profile assets are written to the user's real Documents folder:

```text
Documents\SimHub\MCP4SH
```

MCP4SH does not silently import or activate SimHub profiles for you.

---
## Important install notes

- For a manual install, it is still good practice to close SimHub normally first; the v1.1.14/1.1.14.1 installer path also adds safer application-in-use handling if SimHub or Setup Assistant is still open.
- The built-in updater can request a clean SimHub shutdown and restart after a verified installer is launched; it does not force-kill SimHub.
- Installer/update diagnostics are retained locally when possible under `%LOCALAPPDATA%\TytoSensoryLabs\MCP4SH\Updates`.
- Use the supplied MCP4SH profile / channel map as the supported reference setup.
- Generated profile files are placed in `Documents\SimHub\MCP4SH`.
- If your Documents folder is redirected through OneDrive or another Windows location, MCP4SH attempts to use the real user Documents path.
- Older releases may remain available for archival purposes, but the latest release is the supported baseline.

---
## Website

More information, documentation, FAQ, and purchase links:

<https://tytosensorylabs.com/mcp4sh.html>

---
## Feedback

Useful feedback is specific feedback.

When reporting behaviour, please include:

- game
- car
- track
- MCP4SH version
- SimHub version
- rig / transducer layout
- whether the supplied profile / channel map was used
- whether formulas or routing were modified
- what you expected to feel
- what you actually felt

This is how future updates get better.

General comments like **it feels wrong** are hard to act on. A short, specific report with the setup and context is much more useful.

---
## Development notes

MCP4SH is developed around a normalization-first, semantic interpretation approach.

The aim is not to make every game feel identical. Different titles expose different telemetry, and even different cars inside the same title can vary.

The aim is to make useful information more readable and more consistent where possible, without forcing users to manually rebuild their tactile setup for every sim.

The codebase is increasingly structured around a clearer boundary:

```text
Sim / host adapter
→ adapter-normalized inputs
→ MCP4SH.Core interpretation and stateful haptic logic
→ core outputs
→ host / renderer mapping
```

The current SimHub plugin is the public host implementation today.

The longer-term direction is to keep the reusable interpretation and orchestration logic portable enough for additional adapters, replay/conformance tooling, standalone runtimes, and future hardware integrations without turning every new target into a separate haptic engine.

This is an architectural direction, not yet a public SDK/API promise.

---
## Disclaimer

MCP4SH is an independent SimHub plugin.

Game names, hardware names, and third-party product names are the property of their respective owners.

Use sensible volume and gain levels with tactile hardware. Strong bass shakers and transducers can be powerful enough to damage hardware, loosen rig components, or become uncomfortable if driven too hard.
