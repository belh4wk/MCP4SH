# Installer Security Notes ::: MCP4SH

You should be cautious with any closed-source executable. This document explains how to verify an MCP4SH installer and what the installer is expected to do.

## Verify the installer ::: SHA-256

### Windows ::: PowerShell

1. Open PowerShell in the folder containing the installer.
2. Run:

```powershell
Get-FileHash .\MCP4SH_Setup_<version>.exe -Algorithm SHA256
```

3. Compare the result to the published checksum file for that release.

### Windows ::: CMD

```cmd
certutil -hashfile MCP4SH_Setup_<version>.exe SHA256
```

### macOS / Linux

```bash
shasum -a 256 MCP4SH_Setup_<version>.exe
```

or

```bash
sha256sum MCP4SH_Setup_<version>.exe
```

If the hash does not match the published checksum, do **not** run the installer.

## What the installer is expected to do

Depending on your SimHub path and user choices, a normal MCP4SH installer may:

- copy MCP4SH plugin files into the normal SimHub plugin area
- copy a backup of the plugin files to `Program Files (x86)\TytoSensoryLabs\MCP4SH\SimHub Plugin`
- install Setup Assistant to `Program Files (x86)\TytoSensoryLabs\MCP4SH\Tools`
- place or update bundled MCP4SH defaults under `Documents\SimHub\MCP4SH`
- place MCP4SH plugin data under SimHub’s normal plugin data location
- create a standard uninstall entry in Windows
- offer to launch Setup Assistant after installation
- when launched by the verified in-app updater, wait for MCP4SH to request a normal SimHub shutdown and optionally restart SimHub after a successful install
- create normal installer/update diagnostic logs under Windows/Tyto user-data locations when troubleshooting is required

## What the installer should not do

Unless explicitly documented in release notes, it should **not**:

- install drivers
- create background services
- weaken Windows security settings
- send telemetry or personal data to a remote server
- force-kill SimHub as part of the normal update handoff
- persist outside normal SimHub / TytoSensoryLabs / user-data locations without a clear reason

## Safe installation habits

- download only from the official GitHub release page or another source you personally control
- verify SHA-256 checksums before running the installer
- close SimHub normally before a manual install; the built-in updater may request the supported clean shutdown itself after the installer has successfully elevated
- keep SimHub updated
- if you are extremely cautious, install and test under a separate Windows user account first

## If something looks wrong or you're not sure

Stop and capture:

- installer filename
- checksum
- release page used
- screenshots or Windows prompts that looked suspicious

Then report it through the repo’s security contact path described in `SECURITY.md`.

## Built-in updater handoff

The MCP4SH updater verifies the staged installer SHA-256 before launch. After the user accepts Windows elevation, the installer asks the running MCP4SH plugin to request a normal SimHub exit. The installer waits for that supported shutdown; it does not fall back to `taskkill` or another forced process termination.

Cancelling UAC leaves SimHub running and no update is installed. If the handoff fails or times out, installation stops before replacing plugin files and a diagnostic report may be written locally for review.
