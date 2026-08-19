# MCP4SH® v1.1.13: guided frequency calibration, clearer dynamics and cleaner updates

MCP4SH v1.1.13 closes the v1.1 line with a substantial Setup Assistant calibration upgrade, further haptic articulation work, a cleaner portable Core boundary, broader localization, and a safer end-to-end update handoff.

## Haptics and dynamics

- **Load Breakaway** now gains short directional weight-transfer articulation when credible grip-edge evidence is already present. Weight transfer alone does not fire the breakaway effect.
- **Chassis Load** has improved directional isolation and heave/compression/crest expression while keeping sustained body-load feedback separate from the transient breakaway lane.
- Engine & Tyres, Road Feel, Tyre Scrub, ABS/Lock, drivetrain/limiter and suspension-priority behaviour received additional clarity and authority refinements.
- Recent final-output shaping and suspension-priority logic were moved into **MCP4SH.Core** without intended tuning changes, keeping the SimHub plugin focused on host integration and public property mirroring.

## Frequency calibration and generated profiles

Setup Assistant now includes a rebuilt **Frequency Sweeper / calibration instrument**.

The guided flow asks the user to tune by what is physically felt through the shaker, not by audible pitch:

1. Output
2. Heavy / rumble
3. Rumble / buzz
4. Buzz / whine
5. Generate

The instrument includes mapped-device defaults, shared mapping/sweeper strength, whole-Hz tuning, an LCD/dial/rail interface, direct transport controls, marked-frequency comparison, and canonical-aware effect-map generation.

When enough useful feel anchors have been identified, MCP4SH can generate:

- an effect-frequency map derived from the user's hardware response while staying close to MCP4SH's original orchestration; and
- a **new tuned `.siprofile`** based on the supplied canonical profile.

Generated profiles are non-destructive. MCP4SH does not overwrite or silently import the supplied canonical profile.

## Setup Assistant and shared UI

- Setup Assistant is now single-instance for the normal interactive UI.
- The Sweeper prefers the first device already present in the user's mapping.
- Shared shaker pulse/activity visuals are used across plugin and Setup Assistant testing surfaces.
- Drawer/disclosure controls and contextual radial controls use the current shared Tyto Sensory Labs UI language.
- Dutch and Brazilian Portuguese join English, German, French, Spanish and Simplified Chinese in the shared application UI; English remains the fallback where localized guide content is not yet available.

## Update delivery and diagnostics

The updater can now complete a clean, controlled handoff:

1. download and SHA-256 verify the staged installer;
2. launch the installer and wait for successful elevation;
3. request a normal SimHub shutdown through the supported host exit path;
4. let the installer replace files only after SimHub has exited;
5. restart SimHub after a successful install when appropriate.

MCP4SH does **not** force-kill SimHub. Cancelling UAC leaves SimHub running and no update is installed.

Updater and installer failures now produce clearer user-facing messages and can create a privacy-conscious diagnostic report for the user to review before submitting an issue. Reports are not uploaded automatically.

## Premium preview

The ST Premium test window is now **10 minutes**. The existing cooldown and activation safeguards remain unchanged.

## Canonical SimHub profiles

The supplied **v1.1.12 Standard and 4 Corners `.siprofile` files remain the canonical reference profiles for v1.1.13**. They are intentionally not renamed simply to match the plugin version.

The Frequency Sweeper can generate separate tuned derivatives from those canonical files without modifying the originals.

## Updating

### Built-in updater

Use **Setup Assistant → SimHub Helper → Updates**. The updater verifies the installer before it is allowed to run and uses the clean shutdown/restart handoff described above.

### Manual installer

1. Close SimHub normally.
2. Run `MCP4SH_v1.1.13_Setup.exe`.
3. Launch Setup Assistant after installation.
4. Keep/import the supplied Standard or 4 Corners canonical profile as appropriate.
5. Generate/import the `.sichannels` mapping for the actual physical rig.
6. Optionally use Frequency Sweeper to create a separate hardware-tuned `.siprofile` candidate.

Existing MCP4SH user state and generated mappings are retained unless deliberately replaced.
