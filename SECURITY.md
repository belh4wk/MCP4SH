# Security Policy (MCP4SH)

MCP4SH ships as a Windows installer and a SimHub plugin. Treat any third-party binary with caution.

This document explains what is supported, what the software is expected to do, how to verify releases, and how to report something suspicious.

## Supported versions

Only the latest public release is supported.

- Currently supported: latest GitHub release for MCP4SH
- Older preview builds: unsupported
- Locally modified builds: unsupported unless you know exactly what changed

## Reporting a vulnerability

Do **not** post exploit details publicly.

Preferred path:

1. Use GitHub private vulnerability reporting if it is enabled for the repo
2. If that is not available, contact the maintainer directly through the official repo / release contact path you received the build from

Include:

- affected version
- repro steps or proof of concept if available
- impact
- logs or screenshots if relevant
- checksum of the file you tested if the issue may involve package integrity

## What MCP4SH should not do

Unless explicitly documented in release notes, MCP4SH should **not**:

- send telemetry or personal data to external servers
- collect analytics or tracking data
- install drivers
- create persistent background services
- modify Windows security settings
- elevate privileges unnecessarily

If you observe any of the above, treat it as a security issue.

## Data handling

Primary inputs:

- game / SimHub telemetry already available to the SimHub plugin environment

Primary outputs:

- haptic output through SimHub / audio paths
- local configuration and optional local logs

Local storage is expected under standard SimHub locations, such as `Documents\SimHub\...` and plugin-related folders used by SimHub.

If a release introduces new files or locations, that change should be documented in release notes.

## Release integrity

Every public release should include:

- the installer executable
- a SHA-256 checksum file
- release notes matching the published build

### Verifying a download

1. Download the installer from the official GitHub release
2. Compute the SHA-256 checksum locally
3. Compare it to the published checksum file
4. If the checksum does not match, do **not** run the installer

Example checksum format:

```text
<hex hash>  MCP4SH_<version>_Setup.exe
```

## Dependencies

MCP4SH depends on SimHub and the plugin environment it provides.

If a relevant dependency issue exists, mitigation may require:

- updating SimHub
- updating the plugin package
- changing installation or runtime guidance

## Practical hardening advice for users

- download only from official release channels you trust
- verify checksums before running executables
- keep SimHub and Windows updated
- avoid mixing unknown plugin builds into the same SimHub environment
- if you are particularly cautious, use a dedicated Windows user profile for sim-racing tools

## Disclosure policy

- confirmed issues should be acknowledged and tracked
- fixes or mitigations should be documented clearly
- higher-impact issues should be addressed before broad promotion of a release

## AI-assisted development note

AI assistance was used during development for iteration and documentation drafting work.

That changes nothing about release responsibility:
- the maintainer is responsible for what ships
- users should trust verifiable artifacts, not marketing claims
- checksums, clear release notes, and observable behavior matter more than promises
