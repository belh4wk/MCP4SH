# MCP4SH™ v1.0 — Soft Release

MCP4SH™ v1.0 is the first proper public release baseline of the plugin.

After a long cycle of iteration, tuning, cleanup, and “one more tweak” syndrome, this build is now in a state that is installable, usable, and ready for broader real-world use.

## What MCP4SH is

MCP4SH is a SimHub plugin built to make haptics feel more coherent, more readable, and less chaotic.

The aim is not just more effects.
It is better translation.

- cleaner grip and scrub cues
- more connected suspension and drivetrain feel
- more readable braking behaviour
- less noise, less overlap for the sake of overlap
- a rig that feels more like one chassis and less like several unrelated buzzers

## What v1.0 means

This is a **soft release**.

That means:
- the installer is working
- the repo is in public-release shape
- the plugin is ready to be used outside the dev loop
- refinement will continue based on real feedback

It does **not** mean the project is frozen.

MCP4SH will keep evolving as more people use it across different rigs, sims, and transducer layouts.

## Highlights

- first supported public v1.0 release line
- refined effect layering and priority handling
- current String-Theory haptics approach in usable release form
- built-in licensing flow for optional premium adaptive tools
- groundwork for continued 1.x refinement

## Free vs licensed use

The base plugin remains usable for personal sim-racing use.

The paid version adds the adaptive layer that gives MCP4SH more of its context-aware behaviour, including the premium balancing / learning / tensioning systems.

In plain English: the paid version is not “more shaking.”
It is the part that helps the plugin decide what matters more, what should back off, and what should come through more clearly.

Current roadmap:
- Pioneer — 12.99, up to 2 machines
- Planned Supporter — 12.99, 1 machine
- Possible Pro tier later — likely 19.99, with a higher machine allowance

Store availability is the source of truth for what is live.

## Expectations

MCP4SH is highly dependent on:
- sim title
- telemetry quality
- rig layout
- transducer placement
- amplifier chain
- gain structure
- personal preference

So do not expect identical results on every setup out of the box.

The goal is to give you a stronger, more portable baseline with less retuning, not to pretend every rig is the same.

## Known realities

- GT7 support is not yet where I want it to be
- some sims expose weaker or noisier telemetry than others
- certain effects will keep being refined based on real-world reports
- older preview-era docs / profiles may still exist for archival reasons, but v1.0 is the supported line

## Integrity check

A SHA-256 checksum is attached to the release.

Verify the installer before running it.

PowerShell:
`Get-FileHash .\MCP4SH_v1.0_Setup.exe -Algorithm SHA256`

## Feedback

If something feels brilliant, broken, too strong, too subtle, or just plain odd, say so.

Best reports include:
- game
- car
- track
- rig layout
- what felt wrong
- what you expected instead
- relevant logs/screenshots if available

## Thanks

Thanks to everyone who tested, questioned, encouraged, or challenged the project enough to help get it to a real release point.

v1.0 is not the end point.
It is the point where MCP4SH properly starts in public.
