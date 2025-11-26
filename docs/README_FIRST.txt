MCP4SH™ – Experimental Preview Build
=====================================

© 2025 Dirk Van Echelpoel. All rights reserved.

1. Thank you & scope
--------------------

Thanks for your interest in testing this SimHub plugin.

This is an experimental preview, not a final product.
No promises, no magic — just honest, work-in-progress tech.

Please read everything before installing.

2. Safety Notice
----------------

This plugin modifies haptic behaviour and can increase intensity depending on your hardware and settings.

Use at your own risk.
The author is not responsible for:
- hardware damage,
- discomfort or injury,
- issues caused by extreme gain values,
- incorrect installation or configuration.

Start low, test gradually, and don’t run this on equipment you’re not comfortable pushing.

3. Privacy & Logging
--------------------

When enabled, logs may include:
- game name,
- track and car,
- throttle / brake / clutch input levels,
- MCP4SH tyre/surface signals.

Do not enable logging on shared or competition machines without explicit permission.

Logs are for:
- development,
- physics comparisons,
- debugging.

Do NOT upload logs publicly if they contain identifiable personal data
(name, user IDs, league metadata, etc.).
Send logs privately to the author only.

Log files are stored in:

    SimHub/Logs/MCP4SH/

4. Installation
---------------

1. Copy MCP4SH.dll into:

       SimHub/Plugins/

2. Restart SimHub.
3. Open Settings → MCP4SH in SimHub.
4. Import the included profile/effects (if provided).
5. Verify the plugin shows as loaded.

5. Logging Options
------------------

Inside SimHub → Settings → MCP4SH:

[ ] Debug mode (auto-save logs)
    General development log.
    Only enable when you’re asked to capture an issue.

[ ] Extra tyre / slip logging
    Records per-wheel slip, tyre intensities, throttle/brake/clutch, and MCP4SH-normalized values.
    Used for cross-sim comparisons (AC/AMS2/PMR/etc.).
    Files auto-rotate to avoid huge sizes.

Keep both options OFF unless needed.

6. Usage Rules for Testers
--------------------------

By using this preview build, you agree to:

- Do not redistribute the DLL outside this test group.
- Do not modify or repackage the plugin.
- Do not sell or bundle this plugin in paid modpacks.
- Public posts about the experience are fine — but do not share the DLL or internal logs publicly.

If you don’t agree, don’t use the plugin.

7. Ownership & Trademark Notice
-------------------------------

MCP4SH™ – SimHub implementation of the
MCP4H™ (Multimodal Communications Protocol For Humanity) haptics layer.

© 2025 Dirk Van Echelpoel.
All rights reserved.

MCP4H™ and MCP4SH™ are trademarks of Dirk Van Echelpoel.
Use of these names does not grant ownership or resale rights.

8. Contact
----------

Bugs, logs, feedback → reach out privately.
