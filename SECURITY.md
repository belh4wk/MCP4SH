# Security Policy (MCP4SH)

This project ships a Windows installer and a SimHub plugin. Treat all third-party binaries with caution. This document explains how to verify releases, what the software does, and how to report security issues.

## Supported Versions
Only the most recent release line is supported.
- Current: latest stable release on GitHub Releases
- Older builds: not supported (do not use)

## Report a Vulnerability
If you believe you found a security issue:
1. **Do not** post exploit details publicly.
2. Send a report to: **[ADD YOUR SECURITY EMAIL HERE]**
3. Include:
   - Affected version
   - Repro steps / PoC (if available)
   - Impact (what can be accessed/modified)
   - Logs/screenshots (if relevant)

I’ll acknowledge within **7 days** and aim to ship a fix or mitigation as quickly as practical.

## Security Model (What this software is)
MCP4SH is a SimHub plugin + installer. The plugin runs inside the SimHub environment.

### What MCP4SH should NOT do
Unless explicitly stated in release notes, MCP4SH does not:
- Send telemetry or personal data to external servers
- Collect analytics or tracking
- Install drivers
- Create persistent background services
- Modify Windows security settings
- Elevate privileges unnecessarily

If you observe any of the above, treat it as a security incident and report it.

## Data Handling
- Primary inputs: SimHub/game telemetry accessible through SimHub’s plugin APIs.
- Primary outputs: haptic effects via SimHub / audio output path.
- Local storage: configuration files and logs under SimHub’s standard folders (e.g. Documents\SimHub\... and/or SimHub\Plugins\... depending on setup).

If a release introduces new local files, it must be documented in release notes.

## Supply Chain & Release Integrity

### Verify downloads (strongly recommended)
Every release should include:
- The installer (`.exe`)
- A checksum file (e.g. `MCP4SH_<version>_SHA256SUMS.txt`)
- (Optional) A signature file or signed binaries (see Code Signing)

Steps to verify:
1. Download the installer from GitHub Releases.
2. Compute the SHA-256 checksum locally.
3. Compare it to the published checksum.

If the checksum does not match: **do not run the installer**.

### Checksums (publisher guidance)
Maintain a consistent format, e.g.:

`SHA256  MCP4SH_Setup_v0.9.5_Preview.exe  <hex hash>`

or the common *nix style:

`<hex hash>  MCP4SH_Setup_v0.9.5_Preview.exe`

## Dependencies
MCP4SH depends on SimHub and whatever SimHub uses internally. If a dependency vulnerability is relevant, fixes may require:
- Updating SimHub
- Updating bundled libraries (if any)
- Shipping a plugin update

## Hardening Recommendations (for users)
- Install SimHub and plugins from trusted sources only.
- Prefer verifying checksums/signatures.
- Keep Windows and SimHub updated.
- If you run unknown plugins, consider using a dedicated Windows user account for sim racing.

## Disclosure Policy
- Confirmed security issues will be acknowledged and tracked.
- Fixes will be released with clear notes.
- High-impact issues may include mitigations before a full fix.

## Notes on AI Assistance
Development may use AI assistance for iteration speed. That does not change the security stance:
- The maintainer is responsible for what ships.
- Releases are verified via checksums/signatures.
- Users should judge based on verifiable artifacts (hashes, signatures, reproducible behavior).
