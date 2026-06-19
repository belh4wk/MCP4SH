# MCP4SH® ::: String Theory Haptics for SimHub

MCP4SH® is a SimHub haptics plugin built to make tactile feedback easier to read, easier to set up, and more useful while driving.

Instead of throwing raw telemetry straight at your shakers, MCP4SH turns car behaviour into clearer haptic cues:
engine, drivetrain, tyre scrub, road feel, suspension, braking, ABS, TC, clutch, gearshift, and chassis load.

The goal is simple:

**less guessing, more driving.**

---

## v1.1 status

**MCP4SH v1.1 is the current supported release line. Current public build target: v1.1.6.**

v1.1 is the first release where MCP4SH is not just about the haptic codec. It also includes the new **Setup Assistant**, which is meant to make the whole SimHub shaker setup less painful.

This is still an iterative project, but v1.1 is the new public baseline:

- stronger cross-sim haptic behaviour
- updated plugin UI
- Setup Assistant for shaker layout and sound-output mapping
- generated SimHub sound output profiles
- live read-only SimHub Sound Output routing readout for mapped shakers
- shared pulse visualization for MCP4SH-owned test pulses
- installer support for the plugin and Setup Assistant
- clearer MCP4H-aligned architecture and documentation

---

## What makes MCP4SH different

MCP4SH is aimed at drivers who want more than “more shaking.”

The focus is on:

- clearer separation between useful cues
- more coherent layering across effects
- better signal-to-noise behaviour
- less time wasted retuning every sim from scratch
- a setup flow that does not expect you to be a SimHub wizard

The guiding idea is simple: haptics should help you understand what the car is doing, not bury you in buzzing.

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
- see mapped device/channel/effect information inside the plugin
- see live read-only SimHub Sound Output routing where available
- use the shared pulse visualization while testing mapped shakers

In plain English:

**MCP4SH helps you get your rig working without needing to know every SimHub routing detail up front.**

---

## Licensed version

A license unlocks the extra control layer.

Free gets the core experience working.  
The license gives you more ways to shape it around your own rig.

Licensed features include advanced haptic controls and, over time, the more powerful configuration tools for custom routing, layout variants, and deeper tuning.

It is for people who want to go beyond “this works” and move toward “this feels right for my setup.”

It also directly supports continued MCP4SH development.

Current early-adopter option:

- **Pioneer** ::: 12.99, up to 2 machines

Planned standardisation:

- **Supporter** ::: planned at 12.99, 1 machine
- **Pro** ::: may follow later, likely 19.99, with a higher machine allowance

The store listing is the source of truth for what is actually live.

See `docs/LICENSING.md` for the public-facing licensing overview.

---

## Download and installation

1. Go to **GitHub Releases**.
2. Download the current installer asset.
3. Verify the SHA-256 checksum.
4. Close SimHub before installing.
5. Run the installer.
6. Start SimHub and enable MCP4SH if needed.
7. Launch the Setup Assistant and map your physical shaker layout.

The installer keeps the normal SimHub plugin install path and also places the Setup Assistant under:

```text
Program Files (x86)\TytoSensoryLabs\MCP4SH\Tools
```

Generated sound-output profiles are written to the user's real Documents folder:

```text
Documents\SimHub\MCP4SH
```

---

## First steps

Start here:

- `docs/GETTING_STARTED.md`
- `docs/SETUP_ASSISTANT.md`
- `docs/README_FIRST.txt`
- `docs/KNOWN_ISSUES.md`
- `docs/LOGGING.md`

Important tuning rule:

1. use the Setup Assistant to confirm routing first
2. tune **MCP4SH plugin-side gains** second
3. tune **SimHub master/global output** third
4. only touch SimHub per-effect gains if you know why

---

## Security and verification

This repo provides:

- `SECURITY.md` ::: security policy and release verification guidance
- `INSTALLER_SECURITY.md` ::: what the installer is expected to do and how to verify it

Every public release should include:

- the installer
- a SHA-256 checksum file
- release notes

Verify the installer hash before running it.

---

## MCP4H context

MCP4SH is a practical implementation built on MCP4H® principles.

In MCP4H terms, MCP4SH takes fast, noisy sim telemetry and turns it into clearer human-facing haptic cues. It is not just an effect pack. It is a working test bed for normalized, priority-aware machine-to-human feedback.

A public prior-art disclosure is available via Zenodo:

**DOI:** https://doi.org/10.5281/zenodo.18223144

This disclosure covers architectural concepts only. MCP4SH’s specific implementation details and signal-processing behaviour remain implementation-specific.

---

## Feedback

Useful feedback is specific feedback.

Include:

- game
- car
- track
- rig / transducer layout
- what you expected to feel
- what you actually felt
- any logs if relevant

That is how the next updates get better.
