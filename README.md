# MCP4SH™ — SimHub Haptics Plugin for MCP4H™

MCP4SH™ is a SimHub plugin that implements the MCP4H™ haptics layer  
for sim racing and driving titles.

It turns game telemetry into a structured, layered haptics stack so that
different sims can *feel* broadly the same on your rig.

- Translates telemetry into seat-of-the-pants cues
- Normalises signals across different games
- Drives haptics, LEDs, and dashboards in a consistent way
- Includes a built-in FOV calculator in the MCP4SH settings UI (single / triples / curved) for quick visual calibration

---

## Security & Verification (recommended)

You should be cautious with any third-party binary — especially during preview builds.

This repo provides:
- `SECURITY.md` – security policy, supported versions, and reporting.
- `INSTALLER_SECURITY.md` – what the installer is expected to do + how to verify it.

**Release integrity:** each GitHub Release includes a `*_SHA256SUMS.txt` file.  
Verify the installer hash matches before running it (instructions in `INSTALLER_SECURITY.md`).

---

## Gain tuning order (important)

- Avoid touching SimHub’s per-effect gains at first.
- Start with the gains inside the **MCP4SH plugin UI**.
- Only after that feels right, tune SimHub’s **global/master output** for your rig.

> ⚠️ This repository is for the **SimHub implementation** only.  
> The MCP4H protocol (schemas, docs, and reference examples) lives in a separate repo.

---

## Status

- Stage: **Preview**
- Target build: **v0.9.5_Preview**
- Audience: **Public testing / early adopters**
- Expectation: Things will move, break, and get retuned between builds.

This is *not* a polished release. It is a working, evolving preview so we can:

- Validate the MCP4H haptics model across multiple sims and hardware setups.
- Shake out bugs and edge cases in the flavour engine and effect mappings.
- Gather structured feedback and logs from real-world rigs.

See `CHANGELOG.md` for the latest high-level changes.

## Architectural Context

MCP4SH is an implementation built on the architectural principles defined by the MCP4H protocol.

The core system architecture, telemetry abstraction model, and multimodal design principles are intentionally published as prior art to ensure they remain open and unencumbered.

A public prior-art disclosure is available via Zenodo:

**DOI:** https://doi.org/10.5281/zenodo.18223144

This disclosure covers architectural concepts only; MCP4SH’s specific implementation details and signal-processing behavior remain implementation-specific.

---

## Download & Installation (preview)

There are two typical ways to get the plugin:

### 1. From a GitHub pre-release

1. Go to the **Releases** section of this repo.
2. Download the latest pre-release asset, e.g.:  
   `MCP4SH_Setup_v0.9.5_Preview.exe`
3. **Verify the SHA-256 checksum** (recommended) using `INSTALLER_SECURITY.md`
4. Run the setup and follow the instructions

---

## First steps for testers

Start here:

- `docs/README_FIRST.txt` – **Required reading.**  
  High-level overview, what this preview is, and what it is not.

Then:

- `docs/SETUP_4CH.md` – Reference 4-channel hardware/layout used for tuning.
- `docs/KNOWN_ISSUES.md` – Current limitations, caveats, and WIP areas.
- `docs/LOGGING.md` – How to enable CSV logging for debugging and physics comparisons.

If you only read one thing before driving, make it `README_FIRST.txt`.

---

## Logging & Feedback

MCP4SH can emit CSV logs under:

```text
SimHub/Logs/MCP4SH/
