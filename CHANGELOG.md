# MCP4SH Changelog

## v1.1.10

- Refined and approved the v1.1 haptics baseline across Load Breakaway, clutch engagement/free-rev behaviour, Engine & Tyres, Tyre Scrub, and Suspension Impact.
- Added a raw wheel-load sidechain for suspension kerb/rumble/sausage/dome kerb tooth authority without using the shaped public Load Breakaway output.
- Improved high-speed rumble strip tooth contrast, slow tall sausage/dome kerb punch, and Spa-style isolated kerb/runoff hit violence while keeping the suspension lane suspension-proof led.
- Improved rFactor 2 / LMU steering input handling by adding filtered/unfiltered steering candidates and avoiding dead-zero steering candidates masking useful fallbacks.
- Added rFactor 2 style high-speed straight slip-pedestal calming for E&T / Tyre Scrub without removing existing wheel slip candidates.
- Restored rear-drive E&T throttle pluck authority while preserving the calmer straight-line behaviour.
- Added Load Breakaway and suspension kerb/edge diagnostic columns to replay/log output for easier validation.
- Refreshed the bundled canonical SimHub Standard effects profile and canonical Setup Assistant `.sichannels` templates.
- Added plugin and Setup Assistant guidance for updated bundled SimHub Standard profile imports, including a plugin banner that opens Setup Assistant directly to the Updates tab.
- Changed the Setup Assistant Updates tab to use the online `CHANGELOG.md` first, with the bundled local changelog as fallback.
- Hardened license restore behaviour so partial/junk key text is ignored, cached valid licenses survive ambiguous refresh failures, and the license field commits more safely.
- Consolidated Setup Assistant local state under `%LOCALAPPDATA%\TytoSensoryLabs\MCP4SH\SetupAssistant` with migration from the older `%LOCALAPPDATA%\MCP4SH\SetupAssistant` path.
- Added an installer finish-page note that points users to the bundled profile in `Documents\SimHub\MCP4SH` and explains the SimHub import path.

## v1.1.9

- Added and refined the Load Breakaway / twang lane as a separate transient grip-snap effect.
- Tuned front steering-induced breakaway authority and rear throttle/load breakaway behaviour while keeping detection conservative.
- Reworked clutch-in / neutral free-rev behaviour so clutch-in events produce a short shudder, throttle-held free-rev settles instead of sustaining a shudder, and bite-point behaviour remains intact.
- Added dynamic clutch bite-tail shortening for fast throttle release while preserving slower release drag.
- Softened E&T bed ramping on fast straight / micro-steer high-slip conditions while preserving transient pluck punch.
- Added replay logging for Load Breakaway outputs.

## v1.1.8

- Polished Setup Assistant and plugin hover/floating hint behaviour.
- Fixed the plugin floating shaker info panel reopening immediately after right-click test pulses.
- Kept Pulvis/default shaker info behaviour visible as intended.
- Prepared release/version alignment and installer handoff for the v1.1.8 line.

## v1.1.7

- Continued Setup Assistant and SimHub Helper polish following the v1.1 release.
- Improved profile generation/import guidance and generated profile consistency.
- Kept the website/plugin page version-agnostic while release assets carried the version identity.

## v1.1.6

- Added live read-only SimHub ShakeIt Bass Shakers Sound Output routing readout for mapped shakers.
- Added the shared pulse visualization/status panel for MCP4SH-owned test pulses.
- Moved the pulse visualization into shared UI for plugin and Setup Assistant use.
- Dev-gated the internal routing probe and kept diagnostic exports compact and license-safe.
- Cleaned up Setup Assistant/plugin routing and pulse panel visibility behaviour.
- Removed noisy release-build warnings from unused diagnostic/pulse fields.
- No haptics tuning changed.

## v1.1.5

- Continued internal cleanup around Setup Assistant routing, generated profile analysis, and shared UI handoff.
- Improved robustness of mapped shaker hover panels and SimHub Helper profile-analysis tabs.
- Kept haptics behaviour stable while setup/readout tooling matured.

## v1.1.4

- Added Audio Diagnostics and Motors Guide improvements.
- Moved ShakeIt Motors and 4-corner docs into the SimHub Helper modal.
- Replaced copy-only audio diagnostics with exportable diagnostic text files.
- Added raw GitHub markdown loading for helper/docs tabs.
- Improved right-rail profile generation/analyse workflow and mapping refresh behaviour.

## v1.1.3

- Improved WASAPI device visibility and multichannel output handling for Setup Assistant test pulses.
- Updated installer packaging and device dropdown/tooltips for clearer output-device selection.
- Continued work on 6/8-channel cards where Windows/driver reporting can differ from SimHub output behaviour.

## v1.1.2

- Added device dropdown details, channel-count hints, and sorting guidance.
- Added WASAPI pulse backend work alongside the existing fallback path.
- Added early fixes for devices incorrectly limited to Ch1/Ch2 during Setup Assistant mapping.

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
