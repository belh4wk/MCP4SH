# D285 repo guide drop

Copy the contents of this folder into the repository's existing `docs/` folder.

English stays at the current root paths:

- `docs/SIMHUB_SETUP.md`
- `docs/SHAKEIT_MOTORS.md`
- `docs/SETUP_4CH.md`

Localized guides live under culture folders:

- `docs/de/`
- `docs/fr/`
- `docs/es/`
- `docs/zh-Hans/`

Setup Assistant D285 resolves the active MCP4SH UI culture to those paths, caches successful downloads under `%LOCALAPPDATA%\TytoSensoryLabs\MCP4SH\Docs`, and falls back to bundled localized copies before falling back to English.

Do not translate MCP4SH property IDs, `$prop(...)` expressions, `.siprofile` / `.sichannels` extensions, or file/path contracts.
