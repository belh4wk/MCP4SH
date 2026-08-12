# MCP4SH® v1.1.12 — clearer haptics, 4-corner profile support and safer updates

MCP4SH v1.1.12 builds on the established v1.1 baseline with stronger cross-title tactile readability, more complete setup/localization work, a matched Standard + 4 Corners profile set, and a new user-controlled update delivery path.

## Haptics

- Engine & Tyres now keeps more useful dynamic headroom in telemetry-heavy titles and has a little more overall presence.
- Dense/noisy suspension telemetry is less able to dominate the whole tactile mix, improving high-speed suspension and tyre readability.
- Subtle wheel-lock onset detection is more sensitive to credible individual-wheel collapse while preserving conservative full-lock/ABS behaviour.
- Chassis Load has stronger left/right, front/rear and heave expression, including true four-corner output.
- Clutch engagement, tyre-work readability and Road Feel speed character have received further refinement.

## Profiles and setup

Two reference SimHub profiles are supplied:

- **Standard** — front/rear spatialization where appropriate.
- **4 Corners** — per-corner Tyre Scrub and Suspension lanes, with Chassis Load in its native four-corner form.

Both profiles share the same tuning baseline.

Physical sound-output/channel routing remains separate from the `.siprofile`. Run MCP4SH Setup Assistant to map your actual hardware and generate the matching `.sichannels` files.

## Setup Assistant and localization

- Expanded shared UI localization: English, German, French, Spanish and Simplified Chinese.
- Localized SimHub Helper guides with English fallback.
- Improved mapping/profile-generation guidance, routing visibility and diagnostics.
- Improved translated-layout handling and general UI polish.
- Saved licence keys are masked during normal display while remaining fully editable when deliberately focused.

## Update delivery

v1.1.12 introduces manifest-driven update awareness.

MCP4SH can check for:

- newer plugin releases
- newer `.siprofile` revisions
- supported documentation/content updates

Downloads are staged and SHA-256 verified. MCP4SH does **not** silently run an installer or import/overwrite a SimHub effects profile.

`.sichannels` files are never remotely distributed; they remain generated locally for the user's mapped hardware.

## Updating from an older build

1. Close SimHub.
2. Run `MCP4SH_v1.1.12_Setup.exe`.
3. Launch Setup Assistant after installation.
4. Import either the Standard or 4 Corners `.siprofile` in SimHub.
5. Generate/import the `.sichannels` files that match your physical shaker mapping.

Existing MCP4SH user state and generated mappings are kept unless you deliberately replace them.
