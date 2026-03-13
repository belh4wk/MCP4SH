# MCP4SH™ — SimHub Haptics Plugin for MCP4H™

MCP4SH™ is a SimHub plugin that applies the MCP4H™ haptics model to sim racing and driving titles.

It turns raw telemetry into a structured, layered haptics stack so different sims can feel broadly consistent on the same rig.

- Translates telemetry into seat-of-the-pants cues
- Normalises signal intent across different games
- Drives haptics, dashboards, and companion outputs with a shared design language
- Includes a built-in FOV calculator in the MCP4SH settings UI (single / triples / curved)

> MCP4SH is the **SimHub implementation**.  
> MCP4H is the broader architectural and protocol layer behind it.

For help/support, either contact me here or on Discord.

---

## Release status

- Stage: **Soft release**
- Current line: **v1.0.-soft**
- Audience: **Public users / early supporters**
- Expectation: **Usable now, still evolving**

This is not being presented as a “finished forever” endpoint. It is the first public-facing release line intended to be installable, understandable, and worth using while tuning and coverage continue to improve.

That means:

- Core haptics philosophy and structure are established
- Documentation is now release-oriented rather than preview-only
- Some effect tuning and hardware-specific behavior will continue to be refined
- Certain game-side telemetry limits still apply

See `CHANGELOG.md` for the running change history and `RELEASE_NOTES.md` for the current release summary.

---

## Security & verification

You should treat any third-party binary with caution.

This repo includes:

- `SECURITY.md` — supported release policy, reporting guidance, and verification expectations
- `INSTALLER_SECURITY.md` — what the installer is expected to do and how to verify it
- `TRADEMARKS.md` — branding and mark usage guidance

**Release integrity:** every public release should include a SHA-256 checksum file for the installer. Verify the published hash before running any executable.

---

## Gain tuning order

This matters more than most people think.

1. Start with the gains inside the **MCP4SH plugin UI**
2. Then adjust SimHub **global / master output** for the rig
3. Only touch SimHub per-effect gains last, and only if there is a specific reason

If you start by fighting per-effect gains in SimHub, you can mask the intent of the MCP4SH stack very quickly.

---

## What MCP4SH is trying to do

MCP4SH is built around the idea that a rig should feel like **one chassis with layered domains**, not a bag of random vibrations.

Typical cue groups include:

- engine and drivetrain resonance
- tyre phase and scrub behavior
- braking-domain feedback
- suspension impacts and undulation
- road texture and axle timing
- gearbox and shift-domain events

Some bands intentionally overlap so the rig behaves like one connected mechanical system instead of isolated shakers arguing with each other.

---

## Architectural context

MCP4SH is an implementation shaped by the architectural principles defined by MCP4H™.

The broader abstraction model and multimodal design concepts are published separately as prior art so the architectural layer remains visible and timestamped.

Public disclosure:

**DOI:** https://doi.org/10.5281/zenodo.18223144

That disclosure covers the architectural concepts. MCP4SH’s concrete implementation, tuning choices, and signal-processing behavior remain implementation-specific.

---

## Getting started

Start here:

- `docs/GETTING_STARTED.md` — shortest path from download to first drive
- `docs/README_FIRST.txt` — practical orientation, expectations, and setup logic
- `docs/SETUP_4CH.md` — reference rig layout used during tuning
- `docs/KNOWN_ISSUES.md` — current limitations and caveats
- `docs/LOGGING.md` — how to capture useful debug data when something feels off

If you only read one file before driving, read `docs/README_FIRST.txt`.

---

## Logging & feedback

MCP4SH can emit CSV logs under:

```text
SimHub/Logs/MCP4SH/
```

Use logging when:

- a cue feels obviously wrong
- a specific game behaves differently than expected
- you are comparing telemetry behavior between sims
- you want to report a reproducible issue with evidence instead of guesswork

When reporting an issue, include:

- game
- car
- track
- short repro steps
- what you expected vs what you felt
- whether debug logging or extra tyre/slip logging was enabled

---

## Current limitations worth knowing up front

- Hardware matters a lot; the reference tuning is not universal
- Some games expose better telemetry than others
- Manual tuning is still required
- SimHub being brought to the foreground can hurt framerate on some systems
- A few edge-case effects may still be stronger or rougher than intended on certain rigs or at very low speed

None of that makes the plugin unusable. It does mean you should approach first-time setup with a bit of method instead of immediately cranking everything.

---

## Commercial / redistribution position

MCP4SH is **not** public-domain and **not** open-source software just because documentation is public.

See:

- `LICENSE_PLUGIN.txt`
- `LICENSE_SOFT_RELEASE.txt`
- `TRADEMARKS.md`

Do not redistribute, rebrand, bundle, or resell MCP4SH without written permission.

---

## Manual release tasks

This repo patch intentionally leaves these folders alone:

- `installer/`
- `Profile backups/`

Use `RELEASE_CHECKLIST.md` before publishing a release so the binaries, profile names, and checksum artifacts match the release-facing docs.
