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

Generated files are placed in:

```text
Documents\SimHub\MCP4SH
```

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
