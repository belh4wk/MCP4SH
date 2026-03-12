# Installer Security Notes (MCP4SH)

You should be cautious with any closed-source executable. This document explains how to verify an MCP4SH installer and what the installer is expected to do.

## Verify the installer (SHA-256)

### Windows (PowerShell)

1. Open PowerShell in the folder containing the installer
2. Run:

```powershell
Get-FileHash .\MCP4SH_Setup_<version>.exe -Algorithm SHA256
```

3. Compare the result to the published checksum file for that release

### Windows (CMD)

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

- copy MCP4SH plugin files into the SimHub plugin area
- place or update MCP4SH defaults in normal SimHub user-data locations
- create a standard uninstall entry in Windows

## What the installer should not do

Unless explicitly documented in release notes, it should **not**:

- install drivers
- create background services
- weaken Windows security settings
- send telemetry or personal data to a remote server
- persist outside normal SimHub / user-data locations without a clear reason

## Safe installation habits

- download only from the official GitHub release page or another source you personally control
- verify SHA-256 checksums before running the installer
- keep SimHub updated
- if you are extremely cautious, install and test under a separate Windows user account first

## If something looks wrong or you're not sure

Stop & Capture:

- installer filename
- checksum
- release page used
- screenshots or Windows prompts that looked suspicious

Then report it through the repo’s security contact path described in `SECURITY.md`.
