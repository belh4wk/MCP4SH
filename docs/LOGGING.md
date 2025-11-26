# MCP4SH Logging

MCP4SH can emit two types of CSV logs under:

    SimHub/Logs/MCP4SH/

## Debug mode (auto-save logs)

- Toggle: **Debug mode (auto-save logs)**
- Purpose: General troubleshooting of MCP4SH behaviour.
- Contents: high-level view of speed, gear, throttle, brake, clutch, tyre intensities, slip, and MCP4SH envelope values.

Use this when:
- Something feels wrong and you want to capture a short session for the author.
- You are asked to reproduce an issue.

## Extra tyre / slip logging

- Toggle: **Extra tyre / slip logging**
- Purpose: Physics / tyre model comparisons between sims (AC, AMS2, PMR, etc.).
- Contents: per-wheel tyre intensities, per-wheel slip, front/rear averages, speed, rpmNorm, throttle, brake, clutch.

Files are automatically rotated after a large number of lines to avoid unbounded growth.

Use this when:
- You are doing controlled tests to compare how different sims behave.
- You are asked to provide data for tuning the MCP4SH mappings.

Both switches should normally stay OFF during casual driving to avoid unnecessary disk usage.
