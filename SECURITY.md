# Security Policy (MCP4SH)

This project ships a Windows installer and a SimHub plugin. Treat all third-party binaries with caution. This document explains how to verify releases, what the software does, and how to report security issues.

## Supported Versions
Only the most recent release line is supported.
- Current: latest stable release on GitHub Releases
- Older builds: not supported (do not use)

## Report a Vulnerability
If you believe you found a security issue:
1. **Do not** post exploit details publicly.
2. Send a report via the main support / contact route listed on GitHub or the website.
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
- Primary inputs: SimHub / game telemetry exposed through SimHub’s plugin APIs
- Primary outputs: haptics via SimHub / audio output path
- Local storage: configuration files, license cache state, and logs in standard SimHub / local app data locations

If a release introduces new local files, it should be documented in release notes.

## Supply Chain & Release Integrity

### Verify downloads (strongly recommended)
Every release should include:
- the installer (`.exe`)
- a checksum file (for example `MCP4SH_Setup_v1.0_sha256.txt`)
- release notes

Steps to verify:
1. Download the installer from GitHub Releases.
2. Compute the SHA-256 checksum locally.
3. Compare it to the published checksum.

If the checksum does not match: **do not run the installer**.

### Checksums (publisher guidance)
Maintain a consistent format, for example:

`<hex hash>  MCP4SH_v1.0_Setup.exe`

## Dependencies
MCP4SH depends on SimHub and the libraries it uses internally. If a dependency vulnerability matters, fixes may require:
- updating SimHub
- updating bundled libraries (if any)
- shipping a plugin update

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
- the maintainer is responsible for what ships
- releases are verified via checksums/signatures
- users should judge based on verifiable artifacts
