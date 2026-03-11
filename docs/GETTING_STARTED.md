# MCP4SH™ — Getting Started

This is the shortest sensible path to a first drive.

## 1) Install carefully

- Download the release from the official source you trust
- If the package includes an installer, verify its SHA-256 checksum first
- Install MCP4SH into your SimHub environment
- Start SimHub and enable **MCP4SH** in Add/remove features if needed

Read:

- `SECURITY.md`
- `INSTALLER_SECURITY.md`

## 2) Import the supplied profile and routing

If your release package includes the profile backups and routing presets:

- import the effect profile into **ShakeIt Bass Shakers**
- import the routing preset(s)
- verify channel assignments against your actual hardware

Do not assume the imported profile is perfectly tuned for your rig.

## 3) Set gains in the right order

This is the bit people get wrong.

1. Tune **MCP4SH plugin gains** first
2. Tune **SimHub master/global output** second
3. Touch **SimHub per-effect gains** last, only if needed

## 4) First test session

Use one sim and one car you know well.

Look for:

- clean front vs rear timing
- brake cues that make sense under your foot
- engine / drivetrain presence without drowning everything else
- tyre scrub that feels informative rather than random

## 5) If it feels wrong

Do not immediately nuke every slider.

Instead:

- lower gains a bit
- verify routing
- check `docs/KNOWN_ISSUES.md`
- enable logging for a short test if needed

See `docs/LOGGING.md`.
