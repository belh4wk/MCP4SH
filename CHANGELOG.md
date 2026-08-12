# MCP4SH Changelog

## v1.1.12

- Improved Engine & Tyres clarity and presence across titles, including better dynamic headroom when telemetry stays persistently hot.
- Improved suspension and tyre readability in dense/high-speed telemetry by preventing noisy impact beds from constantly taking tactile priority.
- Improved subtle wheel-lock onset detection while keeping the established conservative full-lock and ABS behaviour.
- Refined clutch engagement, tyre-work readability, Road Feel speed character, and Chassis Load spatial/heave feedback.
- Added a matched **Standard** and **4 Corners** SimHub profile set. The 4 Corners profile uses FL/FR/RL/RR tyre and suspension lanes while physical output routing remains Setup Assistant generated.
- Expanded the shared MCP4SH interface localization to English, German, French, Spanish, and Simplified Chinese, including localized SimHub Helper guides and more translation-safe layouts.
- Improved Setup Assistant and SimHub Helper onboarding, routing visibility, profile/channel generation diagnostics, and generated-profile guidance.
- Improved license validation resilience and now masks saved license keys in the normal plugin view.
- Added manifest-driven update delivery. MCP4SH can detect newer plugin releases, profile revisions, and supported content on launch; downloads are verified and staged locally, with installer/profile changes remaining user-controlled.
- Remote `.sichannels` delivery is intentionally not supported. Physical channel maps remain generated locally by Setup Assistant for the user's actual hardware.

## v1.1.11

- Improved cross-title suspension impact hierarchy and handling of titles with very active/noisy impact telemetry.
- Refined Brake Feel and ABS/Lock separation while preserving stricter lock proof.
- Improved steering-source support and Engine & Tyres articulation across several titles.
- Hardened license input/cache behaviour and consolidated MCP4SH local state under `%LOCALAPPDATA%\TytoSensoryLabs\MCP4SH`.
- Improved redirected/OneDrive Documents handling for SimHub profile lookup and generation.
- Added Setup Assistant layout presets and improved front-shaker fallback routing for common layouts.
- Refreshed the bundled Standard `.siprofile` and generated `.sichannels` baseline.
- Added the MCP4SH game catalog/TCR groundwork and updated support/navigation links.

## v1.1.10

- Refined and approved the v1.1 haptics baseline across Load Breakaway, clutch engagement/free-rev behaviour, Engine & Tyres, Tyre Scrub, and Suspension Impact.
- Improved suspension kerb, rumble-strip and isolated-impact detail while keeping load/breakaway cues cleanly separated.
- Improved high-speed rumble-strip contrast, tall kerb impact clarity, and isolated runoff/landing response across supported titles.
- Improved rFactor 2 / LMU steering input handling by adding filtered/unfiltered steering candidates and avoiding dead-zero steering candidates masking useful fallbacks.
- Improved high-speed straight-line calm for Engine & Tyres and Tyre Scrub while preserving genuine tyre-work response.
- Restored rear-drive E&T throttle pluck authority while preserving the calmer straight-line behaviour.
- Expanded replay/log diagnostics for easier support and validation of load/breakaway and suspension behaviour.
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
- Kept advanced routing diagnostics out of the normal user flow and made diagnostic exports more compact and licence-safe.
- Cleaned up Setup Assistant/plugin routing and pulse panel visibility behaviour.
- Removed noisy release-build warnings from unused diagnostic/pulse fields.
- No haptics tuning changed.

## v1.1.5

- Continued cleanup around Setup Assistant routing, generated profile analysis, and shared interface behaviour.
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
