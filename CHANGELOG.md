# MCP4SH Changelog

## v1.1.6

- Added live read-only SimHub ShakeIt Bass Shakers Sound Output routing readout for mapped shakers.
- Added the shared pulse visualization/status panel for MCP4SH-owned test pulses.
- Moved the pulse visualization into shared UI for plugin and Setup Assistant use.
- Dev-gated the internal routing probe and kept diagnostic exports compact and license-safe.
- Cleaned up Setup Assistant/plugin routing and pulse panel visibility behaviour.
- Removed noisy release-build warnings from unused diagnostic/pulse fields.
- No haptics tuning changed.


## v1.1.1 Hotfix

- Added Setup Assistant channel-count override: Auto / 2 / 4 / 6 / 8.
- Fixed multichannel devices being limited to 2 channels when detection is wrong.
- Updated canonical `.sichannels` templates used by generated profiles.
- Fixed FOV view angle/info text clipping.
- Fixed curved triples input visibility.
- Added ShakeIt Motors usage guide for MCP4SH public properties.
- No haptics tuning changed.


## v1.1.0

- Added the MCP4SH Setup Assistant.
- Added guided shaker layout selection and test-pulse mapping.
- Added generated SimHub sound output profiles under `Documents\SimHub\MCP4SH`.
- Added SimHub Helper flow for profile generation, analysis, folder access, and import guidance.
- Refreshed the plugin UI around the rig-view model.
- Added hover/routing information for mapped shakers where generated/analyzed profile data exists.
- Refined the haptics baseline across drivetrain, engine/tyres, tyre scrub, suspension, rough-surface behaviour, and chassis load.
- Added/updated MCP4H alignment docs, including the core/plugin boundary and compliance direction.
- Updated installer layout for the plugin backup copy and Setup Assistant tool install.
- Hardened SimHub feature enable/disable behaviour by deferring the settings UI creation during SimHub refresh.
- Updated release/docs messaging around free Setup Assistant access and licensed advanced controls.

## v1.0.0

- First supported public release line.
- Installer and release collateral brought into public-release shape.
- Licensing flow integrated around Lemon Squeezy license activation / validation.
- Premium adaptive layer exposed through licensed use.
- Continued refinement of layering, prioritisation, and readability across core effect families.
- Website / repo messaging aligned around v1.0 support status.

## Legacy preview notes

Older preview-era builds are retained for historical / archival context only and are no longer the supported release line.
