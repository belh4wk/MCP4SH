# MCP4SH® v1.1.14.1: mapping convenience and update reliability hotfix

MCP4SH v1.1.14.1 is a small stable hotfix on top of v1.1.14. It keeps the established haptics/profile baseline unchanged and focuses on making completed physical mappings easier to correct without forcing users back through the whole mapping wizard.

## v1.1.14.1 mapping tools

- Added **Swap saved seat L/R** for completed physical maps containing both `SeatBottom.Side.Left` and `SeatBottom.Side.Right`.
- Added **Swap saved front/rear** for eligible simple front/rear layouts.
- Front/rear swapping is device-scoped rather than a global Ch1/Ch2 inversion.
- Intentional shared-channel assignments are preserved when a qualifying front/rear pair is swapped.
- Dedicated seat-side and ambiguous/multichannel layouts are excluded from the front/rear convenience action rather than guessed.
- The saved physical map is backed up before replacement and the updated map is written atomically.
- Setup Assistant Audio Diagnostics identify the current P019 mapping-repair path.

These actions are optional repair/convenience tools. MCP4SH does not automatically reinterpret or reverse a user's existing audio channel order.

## v1.1.14 install/update reliability carried forward

v1.1.14 hardened the stable install/update path and remains the foundation of this hotfix:

- safer application-in-use detection before MCP4SH executables and DLLs are replaced
- manual-install checks for both known SimHub process names and MCP4SH Setup Assistant
- clean staged-update handoff that asks SimHub to close normally rather than force-killing the host
- explicit close-application handling when Setup Assistant launches a staged installer
- installer logging and additional diagnostics for blocked or failed updates
- pre-update Setup Assistant state backup/restore protection so existing mapping/routing remains authoritative across upgrades
- stable release/version identity aligned across plugin, Core, UI, Setup Assistant, installer and update manifest

## What did not change

- No haptic/effect tuning changes are intended in v1.1.14.1.
- No telemetry-semantic changes are included.
- No licensing/entitlement changes are included.
- The supplied v1.1.12 Standard and 4 Corners `.siprofile` files remain the canonical v1.1.14.1 reference profiles.
- Existing v1.2 Chassis/Airframe assets remain previews. The v1.2 development runtime is not part of this stable release.

## Updating

### Built-in updater

Use **Setup Assistant → SimHub Helper → Updates**. The updater verifies the installer before it is allowed to run and uses the clean shutdown/restart handoff described above.

### Manual installer

1. Close SimHub normally when practical.
2. Run `MCP4SH_v1.1.14.1_Setup.exe`.
3. Launch Setup Assistant after installation.
4. Keep/import the supplied Standard or 4 Corners canonical profile as appropriate.
5. Keep or regenerate the `.sichannels` mapping for the actual physical rig as needed.
6. Use the saved L/R or front/rear swap tools only when a completed physical map needs that correction.

Existing MCP4SH user state and generated mappings are retained unless deliberately replaced or edited by the user.
