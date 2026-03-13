# MCP4SH™ — SimHub Haptics Plugin for MCP4H™

MCP4SH™ is a SimHub plugin built to make haptics feel more coherent, more readable, and less like a pile of unrelated vibrations.

Instead of throwing effect spam at the rig, MCP4SH layers telemetry into a more connected chassis feel so grip, scrub, suspension, drivetrain, braking, and weight-transfer style cues are easier to read under load.

- Turns telemetry into clearer seat-of-the-pants cues
- Normalises behaviour across different sims
- Exposes a consistent property layer for haptics, dashboards, and related tooling
- Includes a built-in FOV calculator in the MCP4SH settings UI

---

## v1.0 status

**MCP4SH v1.0 is the current supported release.**

This is a real release, but still an iterative one. The goal for v1.0 was to get MCP4SH into a state that is installable, stable, usable, and worth wider real-world testing.

That means:
- the installer is working
- the public repo is the canonical home for notes, hashes, and updates
- the plugin is ready for broader use
- refinement will continue based on real rigs, real sims, and real feedback

This is not a “finished forever” build. It is the first proper public release baseline.

---

## What makes MCP4SH different

MCP4SH is aimed at drivers who want more than “more shaking.”

The focus is on:
- clearer separation between useful cues
- more coherent layering across effects
- better signal-to-noise behaviour
- less time wasted retuning every sim from scratch

The guiding idea is simple: haptics should help you understand what the car is doing, not bury you in buzzing.

---

## Free vs licensed use

MCP4SH is usable without a paid license, but the licensed edition unlocks the adaptive layer that gives the plugin more of its “smart” behaviour.

### Base / unlicensed use
The unlicensed build keeps the core effect stack available for personal sim-racing use.

### Licensed value-add
The paid version is not about making the rig louder. It is about making the output more context-aware.

In the current implementation, the licensed edition unlocks the premium adaptive tools, including:
- **ST Tensioner** for priority-aware ducking and promotion of important cues
- **ST Balancer** for cross-game output rebalancing
- **ST Learner** for perceptual shaping of scrub and engine/tyre behaviour

The free edition can expose a time-limited preview of part of that behaviour, but the licensed version is the intended full-use path. This is reflected directly in the plugin code and license UI.

See `docs/LICENSING.md` for the public-facing licensing overview.

---

## Licensing roadmap

Current / early-adopter plan:
- **Pioneer** — 12.99, up to 2 machines

Planned standardisation:
- **Supporter** — planned at 12.99, 1 machine
- **Pro** — may follow later, likely 19.99, with a higher machine allowance

Store availability is the source of truth for what is actually live at any given moment.

---

## Security & verification

This repo provides:
- `SECURITY.md` — security policy and release verification guidance
- `INSTALLER_SECURITY.md` — what the installer is expected to do and how to verify it

Every public release should include:
- the installer
- a SHA-256 checksum file
- release notes

Verify the installer hash before running it.

---

## Download & installation

1. Go to **GitHub Releases**
2. Download the current installer asset
3. Verify the SHA-256 checksum
4. Run the installer
5. Read `docs/GETTING_STARTED.md` and `docs/README_FIRST.txt`

GitHub remains the canonical home for:
- releases
- checksums / hashes
- documentation
- changelog / release notes

---

## First steps

Start here:
- `docs/GETTING_STARTED.md`
- `docs/README_FIRST.txt`
- `docs/KNOWN_ISSUES.md`
- `docs/LOGGING.md`

Important tuning rule:
- start with **MCP4SH plugin-side gains first**
- only then adjust SimHub/global output to suit your rig

---

## Architectural context

MCP4SH is an implementation built on the architectural principles defined by MCP4H™.

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
