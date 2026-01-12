# MCP4SH™ — SimHub Haptics Plugin for MCP4H™

MCP4SH™ is a SimHub plugin that implements the MCP4H™  
(Multimodal Communications Protocol For Humanity) haptics layer  
for sim racing and driving titles.

It turns game telemetry into a structured, layered haptics stack so that
different sims can *feel* broadly the same on your rig.

- Translates telemetry into seat-of-the-pants cues
- Normalises signals across different games
- Drives haptics, LEDs, and dashboards in a consistent way
- Includes a built-in FOV calculator in the MCP4SH settings UI (single / triples / curved) for quick visual calibration

> ⚠️ This repository is for the **SimHub implementation** only.  
> The MCP4H protocol (schemas, docs, and reference examples) lives in a separate repo.

---

## Status

- Stage: **Preview**
- Target build: **v0.9.0-preview1**
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

### 1. From a GitHub pre-release (recommended for testers)

1. Go to the **Releases** section of this repo.
2. Download the latest pre-release asset, e.g.:  
   `MCP4SH™-preview-v0.9.0.exe`
3. run the setup and follow the instructions


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
```

There are two main switches (see `docs/LOGGING.md` for details):

- **Debug mode (auto-save logs)** – for capturing "something feels wrong" sessions.
- **Extra tyre / slip logging** – for controlled physics / slip comparisons across sims.

### How to be most useful as a pilot tester

When reporting an issue or giving detailed feedback, please include:

- Game + car + track
- Brief description of your hardware (transducers, amps, rig)
- What you expected to feel vs what you actually felt
- A short debug CSV log (with the relevant switches enabled)

Please avoid sharing logs that contain sensitive league information without prior agreement.

---

## Current tuning assumptions

The reference tuning and routing are built around:

- 2x TT25-16 pucks (backrest + brake)
- 2x BST-1 style transducers (chassis / road feel)
- 2 stereo amps (one for pucks, one for BST-1s)

This corresponds to the layout described in:

- `docs/SETUP_4CH.md`

Other hardware (2-channel, 6–8 channel, different transducers) will work but may require
substantial gain and routing adjustments. The docs include guidance for scaling up or down.

---

## Licensing at a Glance

This repository contains **plugin binaries/configs** and **supporting docs**.

- The **MCP4SH plugin** (DLL, effect definitions, and flavour engine) is distributed under  
  `LICENSE_PLUGIN.txt` (limited-use license).
- Preview access is further governed by `LICENSE_AGREEMENT_PREVIEW.txt`.

In practice:

- Personal, non-commercial sim racing use is allowed.
- Public redistribution, resale, or inclusion in paid modpacks is **not** allowed.
- Do not rebrand, rename, or claim ownership of MCP4SH™, MCP4H™, or their underlying concepts.

See `LICENSE_PLUGIN.txt`, `LICENSE_AGREEMENT_PREVIEW.txt`, and `TRADEMARKS.md` for full details.

---

## Relationship to MCP4H™

MCP4SH exists to **implement and exercise the MCP4H protocol** in a real sim racing context.

- **MCP4H™ protocol repo (open):**  
  Specifications, schemas, docs, and reference examples.  
  Repo: https://github.com/belh4wk/MCP4H-protocol  
  Latest protocol release (v0.1.2) DOI: https://doi.org/10.5281/zenodo.17727584

- **MCP4SH™ plugin repo (this repo):**  
  SimHub implementation, flavour engine, and haptic effect mappings.  
  Distributed under a more restrictive license appropriate for a preview / pilot-test plugin.

MCP4H™ and MCP4SH™ are trademarks of Dirk Van Echelpoel.  
See `TRADEMARKS.md` for details.

---
