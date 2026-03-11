# MCP4SH Logging

MCP4SH can emit CSV logs under:

```text
SimHub/Logs/MCP4SH/
```

## Debug mode (auto-save logs)

- Toggle: **Debug mode (auto-save logs)**
- Purpose: general troubleshooting of MCP4SH behavior
- Contents: high-level view of speed, gear, throttle, brake, clutch, tyre intensities, slip, and MCP4SH envelope values

Use this when:

- something feels clearly wrong
- a cue appears at the wrong time
- you want a short reproducible capture for diagnosis

## Extra tyre / slip logging

- Toggle: **Extra tyre / slip logging**
- Purpose: deeper tyre-model and slip behavior comparisons between sims
- Contents: per-wheel tyre intensities, per-wheel slip, front/rear averages, speed, rpmNorm, throttle, brake, clutch

Use this when:

- you are comparing AC vs AMS2 vs PMR or similar
- you are trying to understand whether the game or the mapping is the problem
- you are asked for detailed data for tuning work

## Practical guidance

- Leave both logging modes off during normal casual driving
- Turn them on only for short, deliberate test sessions
- When reporting an issue, include game, car, track, what felt wrong, and whether you changed gains or routing first

Files are rotated automatically after they grow beyond a reasonable size so they do not expand forever.
