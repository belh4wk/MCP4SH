# Installer Security Notes (MCP4SH)

You should be cautious with any closed-source executable. This document explains how to verify MCP4SH downloads and what the installer is expected to do.

## Verify the Installer (SHA-256)

### Windows (PowerShell)
1. Open PowerShell in the folder containing the installer.
2. Run:

`Get-FileHash .\MCP4SH_Setup_<version>.exe -Algorithm SHA256`

3. Compare the displayed hash to the one published in the release `SHA256SUMS` file.

### Windows (CMD)
`certutil -hashfile MCP4SH_Setup_<version>.exe SHA256`

### macOS / Linux
`shasum -a 256 MCP4SH_Setup_<version>.exe`

or

`sha256sum MCP4SH_Setup_<version>.exe`

If the hash does not match: **do not run it**.

## What the Installer Does
Expected actions (may vary by SimHub path and user choice):
- Copies MCP4SH plugin files into SimHub’s plugin folder (typically under `SimHub\Plugins\...`)
- Creates/updates MCP4SH configuration defaults under SimHub’s normal user data locations (typically under `Documents\SimHub\...`)
- Adds uninstall entry (standard Windows behavior for installers)

## What the Installer Does NOT Do (unless release notes say otherwise)
- Does not install drivers
- Does not create background services
- Does not modify Windows security settings
- Does not transmit telemetry or personal data to a server
- Does not persist outside SimHub’s plugin/config locations

## Safe Install Practices
- Download only from the official GitHub Releases page (and/or trusted mirrors you control).
- Verify SHA-256 checksums before running.
- Keep SimHub updated.
- If you are extremely cautious, install and run SimHub/plugins on a separate Windows user account.

## If You Suspect Something Is Off
- Do not continue installation.
- Report the issue with the version + checksum + where you downloaded it:
  - Contact: [ADD YOUR SECURITY EMAIL HERE]
