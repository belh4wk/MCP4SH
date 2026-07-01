# MCP4SH® v1.1.10 ::: final v1.1 haptics baseline and release polish

MCP4SH v1.1.10 is the current v1.1 release-candidate/stable baseline. It consolidates the recent haptics tuning, refreshed canonical SimHub profiles, Setup Assistant polish, license-restore hardening, and release/docs cleanup.

## What is new in v1.1.10

### Approved v1.1 haptics baseline

The v1.1.10 line refines the approved haptics baseline across:

- Load Breakaway / grip-snap twang
- clutch engagement, clutch-in shudder, neutral/free-rev behaviour, and bite tail
- Engine & Tyres throttle response and rear-drive pluck authority
- Tyre Scrub and rFactor 2 / LMU straight-line slip-pedestal calming
- Suspension Impact and Suspension Vibration kerb/rumble/sausage/dome-kerb authority

The suspension lane now uses a raw wheel-load edge sidechain to restore kerb tooth violence without mixing in the shaped public Load Breakaway output. Suspension remains suspension-proof led.

### rFactor 2 / LMU input polish

- Added filtered/unfiltered rF2 steering candidates.
- Avoided dead-zero steering candidates masking later useful fallbacks.
- Added condition-based high-speed straight slip-pedestal calming for E&T / Tyre Scrub without removing existing wheel slip candidates.

### Canonical SimHub profile refresh

The bundled SimHub Standard effects profile and Setup Assistant `.sichannels` templates were refreshed for v1.1.10.

The installer copies the bundled profile to:

```text
Documents\SimHub\MCP4SH
```

Import it in SimHub via:

```text
ShakeIt Bass Shakers → Effects profile → Profiles manager → Import profile
```

### Profile update awareness

- The plugin shows a small profile-update notice when a bundled Standard profile is available and not yet acknowledged.
- **Show details...** opens Setup Assistant directly to SimHub Helper → Updates and marks the notice as seen for that bundled profile version.
- Setup Assistant's Updates tab shows profile import guidance and changelog information.
- The Updates tab tries the online `CHANGELOG.md` first and falls back to the bundled local changelog if offline.

### License restore hardening

License restore now ignores implausibly short/partial key text, avoids letting bad stores mask better cached values, and preserves a cached valid license during ambiguous online refresh failures.

### Local state consolidation

Setup Assistant local state now lives under:

```text
%LOCALAPPDATA%\TytoSensoryLabs\MCP4SH\SetupAssistant
```

Existing state under the older `%LOCALAPPDATA%\MCP4SH\SetupAssistant` path is migrated on startup.

## What did not change

- No automatic/silent SimHub profile import is performed. Users stay in control of which SimHub profiles they import or activate.
- Existing SimHub user data and generated profiles are not deleted.
- The Setup Assistant remains part of the free setup flow.

## Installer notes

Close SimHub before installing or updating.

The installer:

- installs the plugin into the normal SimHub plugin location
- places a backup copy under `Program Files (x86)\TytoSensoryLabs\MCP4SH\SimHub Plugin`
- installs Setup Assistant under `Program Files (x86)\TytoSensoryLabs\MCP4SH\Tools`
- writes bundled/default SimHub user files to `Documents\SimHub\MCP4SH`
- offers to launch Setup Assistant after install
- displays a finish-page reminder when a bundled Standard profile is included

## Integrity check

A SHA-256 checksum should be attached to the release.

PowerShell:

```powershell
Get-FileHash .\MCP4SH_v1.1.10_Setup.exe -Algorithm SHA256
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
