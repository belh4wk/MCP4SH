# MCP4SH® v1.1 ::: Setup Assistant Release

MCP4SH v1.1 is the new supported public baseline.

The headline change is simple:

**Free gets you driving. The Setup Assistant helps you get there without wrestling SimHub routing for half the evening.**

## What MCP4SH is

MCP4SH is a SimHub haptics plugin built to make feedback feel more coherent, more readable, and less chaotic.

The aim is not just more effects.  
It is better translation.

- clearer grip and scrub cues
- more connected suspension and drivetrain feel
- more readable braking behaviour
- less noise, less overlap for the sake of overlap
- a rig that feels more like one chassis and less like several unrelated buzzers

## What is new in v1.1

### Setup Assistant

The new Setup Assistant is included with the free version.

It lets you:

- choose the shakers physically installed on your rig
- test-pulse output channels
- answer what you actually felt
- generate a matching SimHub sound output profile
- open the generated profile folder
- use the SimHub Helper flow to import and apply the profile
- analyze an existing sound output profile

That matters because a good haptics plugin is useless if people cannot route it correctly.

### Plugin UI refresh

The plugin UI now uses the new rig-view style and exposes the important controls in a cleaner way. The aim is not to hide everything. The aim is to make the useful controls easier to understand.

### Haptics refinement

v1.1 includes the latest String Theory Haptics baseline across:

- Engine
- Drivetrain
- Tyre Scrub
- Road Feel
- Suspension Vibrations
- Suspension Impacts
- Brake Feel
- ABS
- TC
- Clutch Freewheel
- Gearshift
- Chassis Load

The haptics work focused on cross-title behaviour, clearer separation between cues, and avoiding constant “everything is buzzing” output.

### MCP4H alignment

The core/plugin split and compliance docs now make the MCP4H direction clearer. MCP4SH is still a SimHub plugin, but architecturally it is also a practical MCP4H-style haptic translation layer.

## Free vs licensed use

The free version includes the core MCP4SH String Theory Haptics experience and the Setup Assistant.

A license unlocks the extra control layer:

- advanced haptic controls
- deeper tuning options
- future custom routing/configuration tools
- continued support for development

In plain English:

**Free gets the core experience working. A license gives you more control over how it feels on your rig.**

## Installer notes

The installer:

- installs the plugin into the normal SimHub plugin location
- places a backup copy under `Program Files (x86)\TytoSensoryLabs\MCP4SH\SimHub Plugin`
- installs Setup Assistant under `Program Files (x86)\TytoSensoryLabs\MCP4SH\Tools`
- writes bundled/default SimHub user files to `Documents\SimHub\MCP4SH`
- offers to launch Setup Assistant after install

Close SimHub before installing or updating.

## Known realities

- rigs, transducer layouts, amps, and mounting still matter
- some sims expose cleaner telemetry than others
- the SimHub left-menu icon may fall back to SimHub’s default plugin icon in this build
- the Setup Assistant helps with routing, but it cannot fix bad mounting or bad gain staging

## Integrity check

A SHA-256 checksum should be attached to the release.

PowerShell:

```powershell
Get-FileHash .\MCP4SH_v1.1_Setup.exe -Algorithm SHA256
```

If the checksum does not match, do not run the installer.

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

Thanks to everyone who tested, questioned, encouraged, or challenged the project enough to get it here.
