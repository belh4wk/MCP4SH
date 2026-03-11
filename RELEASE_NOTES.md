# MCP4SH™ — Release Notes

For installation and first-drive guidance, see:

- `docs/GETTING_STARTED.md`
- `docs/README_FIRST.txt`

---

## v1.0 — 2026-03-11

### What this release is

This is the first public release for MCP4SH.

The goal is simple: make the plugin public-facing, understandable, and usable without pretending every edge case is already solved. The architecture is established, the release-facing documentation is cleaned up, and the plugin is ready for broader real-world use and iteration.

### Highlights

- Release-facing documentation moved from preview wording to soft-release wording
- Security and installer-verification guidance cleaned up and made publishable
- First-run guidance clarified: tune plugin-side gains first, then master output, then per-effect gains only if needed
- Known limitations documented for public users
- Logging guidance kept in place for real-world troubleshooting and cross-sim comparisons
- Architectural context retained so MCP4SH remains clearly linked to the MCP4H prior-art layer

### Intended use

- Personal sim-racing use
- Early supporter / early adopter usage
- Broader hardware and sim validation in the wild
- Structured feedback gathering without pretending tuning is “done”

### Notable operational caveats

- Tuning is still hardware-sensitive
- Some games expose incomplete or noisy telemetry
- SimHub in the foreground may reduce framerate on some systems
- A few edge-case haptic behaviours may still need refinement on specific rigs and configurations