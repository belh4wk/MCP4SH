# Known issues — v1.0.0-soft

MCP4SH is usable, but it is not magic and it is not hardware-agnostic.

## Current limitations

- The reference tuning is built around a specific multi-transducer rig. Other layouts may need meaningful gain changes before the stack feels correct.
- Some sims expose cleaner telemetry than others. Where the source data is noisy, delayed, sparse, or binary, certain effects can feel weaker, rougher, or less nuanced than intended.
- Auto-calibration is not implemented. Setup remains manual.
- SimHub being brought to the foreground can reduce framerate on some systems.
- Low-speed or on-throttle edge cases may still produce stronger-than-ideal shudder or texture on some rigs depending on gain structure and game telemetry.
- Plugin internals, tuning defaults, and exposed settings may still change between releases.
- Gearbox-domain behavior remains more sensitive to sim-specific telemetry quality than some of the other domains.

## Practical advice

- Do not judge the stack after 30 seconds on aggressive gains.
- Set plugin gains first, then master output, then per-effect gains only if you have a reason.
- Test one sim you know well before trying to make the same settings work everywhere.
- If something feels obviously broken, capture logs instead of guessing.
