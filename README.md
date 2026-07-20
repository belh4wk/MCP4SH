# MCP4SH® — String Theory Haptics for SimHub

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

**MCP4SH v1.1.11 is the current supported public baseline.**

v1.1.11 focuses on a cleaner and more stable ST Haptics baseline, safer release handling, and clearer setup expectations.

Highlights include:

- cleaner suspension impact and noisy-source handling
- improved handling of titles with very active suspension / impact telemetry
- better Brake Feel vs ABS / Lock separation
- clearer Engine & Tyres articulation without changing drivetrain balance
- steering-source improvements for several titles
- updated canonical SimHub profile and channel assets
- initial layout preset groundwork
- safer license input handling
- unified local state under `TytoSensoryLabs\MCP4SH`
- OneDrive / redirected Documents support
- TCR — Telemetry Clarity Rating — for title clarity expectations

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

## Licensed version

A license unlocks the extra control layer.

Free gets the core experience working. The license gives you more ways to shape it around your own rig.

Licensed features include advanced haptic controls and, over time, more powerful configuration tools for custom routing, layout variants, and deeper tuning.

It is for people who want to go beyond:

> This works.

and move toward:

> This feels right for my setup.

A license also directly supports continued MCP4SH development.

The store listing is the source of truth for what is currently included.

**Free gets you driving.  
A license gives you control.**

---

## Download and installation

1. Go to GitHub Releases.
2. Download the current MCP4SH installer asset.
3. Verify the SHA-256 checksum if desired.
4. Close SimHub before installing or updating.
5. Run the installer.
6. Start SimHub.
7. Enable MCP4SH if SimHub prompts you.
8. Open the MCP4SH plugin tab.
9. Launch the Setup Assistant.
10. Select your rig layout / shaker zones.
11. Run the test pulses.
12. Generate a sound output profile.
13. Import / apply it in SimHub using the SimHub Helper guidance.
14. Go drive.

Generated sound-output profiles and bundled MCP4SH SimHub profile assets are written to the user's real Documents folder:

```text
Documents\SimHub\MCP4SH
```

MCP4SH does not silently import or activate SimHub profiles for you.

---

## Important install notes

- Close SimHub before installing or updating.
- Restart SimHub after installation.
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

MCP4SH is developed around a normalization-first approach.

The aim is not to make every game feel identical. Different titles expose different telemetry, and even different cars inside the same title can vary.

The aim is to make the useful information more readable and more consistent where possible, without forcing users to manually rebuild their tactile setup for every sim.

---

## Disclaimer

MCP4SH is an independent SimHub plugin.

Game names, hardware names, and third-party product names are the property of their respective owners.

Use sensible volume and gain levels with tactile hardware. Strong bass shakers and transducers can be powerful enough to damage hardware, loosen rig components, or become uncomfortable if driven too hard.
