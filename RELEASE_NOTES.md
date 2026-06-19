# MCP4SH® v1.1.6 ::: routing readout and pulse visual polish

MCP4SH v1.1.6 is a usability and setup polish release on the v1.1 line.

The haptic baseline is unchanged. If the current feel works for you, this update should mainly make setup, routing checks, and troubleshooting clearer.

## What is new in v1.1.6

### Live SimHub Sound Output routing readout

The plugin can now read SimHub's live ShakeIt Bass Shakers Sound Output routing state for mapped shakers.

That means the shaker hover panel can show what is currently routed to a mapped device/channel from SimHub's active Sound Output state, instead of relying only on generated profiles, exported snapshots, or stale saved settings.

This is read-only. MCP4SH does not write to SimHub Sound Output settings.

### Shared pulse visualization panel

The plugin and Setup Assistant now use a shared pulse visualization/status panel for MCP4SH-owned test pulses.

It shows mapped device/channel context while idle and switches to a subtle heartbeat-style pulse visual when MCP4SH sends a right-click test pulse or Setup Assistant mapping pulse.

This visualizes MCP4SH's own pulse timing. It does not try to read arbitrary SimHub test/playback state.

### Dev-gated diagnostics

The internal ShakeIt routing probe is now hidden behind dev mode and produces a compact, license-safe diagnostic file.

The broad exploratory probe paths used during development were removed from the normal diagnostic path because they could make SimHub sluggish.

### Cleanup

- Improved hover-panel exit behaviour.
- Kept pulse visual behaviour consistent between plugin and Setup Assistant.
- Cleaned up release-build warnings from unused diagnostic/pulse fields.
- Updated build and installer identity to v1.1.6.

## What did not change

- No haptics tuning changed.
- No SimHub settings are written by the live routing readout.
- No public SDK/API was added.
- No paid Configurator/routing editor is included yet.

## Free vs licensed use

The free version includes the core MCP4SH String Theory Haptics experience and the Setup Assistant.

A license unlocks the extra control layer: advanced haptic controls now, and deeper configuration/routing tools as they mature.

In plain English:

**Free gets the core experience working. A license gives you more control over how it feels on your rig.**

## Installer notes

Close SimHub before installing or updating.

The installer:

- installs the plugin into the normal SimHub plugin location
- places a backup copy under `Program Files (x86)\TytoSensoryLabs\MCP4SH\SimHub Plugin`
- installs Setup Assistant under `Program Files (x86)\TytoSensoryLabs\MCP4SH\Tools`
- writes bundled/default SimHub user files to `Documents\SimHub\MCP4SH`
- offers to launch Setup Assistant after install

## Integrity check

A SHA-256 checksum should be attached to the release.

PowerShell:

```powershell
Get-FileHash .\MCP4SH_v1.1.6_Setup.exe -Algorithm SHA256
```

If the checksum does not match, do not run the installer.

## Feedback

Useful reports include:

- game
- car
- track
- rig layout
- sound device/channel setup
- what felt wrong
- what you expected instead
- relevant logs/screenshots if available
