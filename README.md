# MCP4SH™ — SimHub Haptics Plugin for MCP4H™

MCP4SH™ is a SimHub plugin that implements the MCP4H™  
(Multimodal Communications Protocol For Humanity) haptics layer  
for sim racing and driving titles.

- Translates telemetry into seat-of-the-pants cues
- Normalises signals across different games
- Drives haptics, LEDs, and dashboards in a consistent way

> ⚠️ This repository is for the **SimHub implementation** only.  
> The MCP4H protocol (schemas, docs, and reference examples) lives in a separate repo.

## Status

- Stage: Experimental preview
- Audience: Private testers / early adopters
- API stability: Not guaranteed. Effects and mappings may change.

## Installation (SimHub)

1. Build or download the latest `MCP4SH.dll` from the Releases page.
2. Copy it into your SimHub plugins folder:

   ```text
   SimHub/Plugins/
   ```

3. Restart SimHub.
4. In SimHub, open **Settings → Plugins** and enable **MCP4SH**.
5. (Optional) Import the default profile from `effects/MCP4SH_default.siprofile`.

For detailed steps, see `docs/README_FIRST.txt`.

## Logging

MCP4SH can write CSV logs under:

```text
SimHub/Logs/MCP4SH/
```

Two main switches (in the MCP4SH settings panel):

- **Debug mode (auto-save logs):**  
  General debug CSV for troubleshooting.

- **Extra tyre / slip logging:**  
  Focused log for cross-sim comparisons (tyre intensities, slip, throttle/brake/clutch).

See `docs/LOGGING.md` for details and recommended usage.

## License

This plugin is not licensed under the same terms as the MCP4H protocol.

Use is governed by:

- `LICENSE_PLUGIN.txt` – what you can / cannot do with the plugin
- `LICENSE_AGREEMENT_PREVIEW.txt` – extra terms for preview/test builds

In short:

- Personal, non-commercial sim racing use is allowed.
- Public redistribution, resale, or inclusion in paid modpacks is not allowed.

## Relationship to MCP4H™

- **MCP4H™ protocol repo (open):**  
  Specifications, schemas, docs, and reference examples. Code mostly under MIT.

- **MCP4SH™ plugin repo (this repo):**  
  SimHub implementation, flavour engine, and effects. Distributed under a more restrictive license.

MCP4H™ and MCP4SH™ are trademarks of Dirk Van Echelpoel.  
See `TRADEMARKS.md` for details.
