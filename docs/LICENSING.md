# MCP4SH® licensing overview

This page is the public-facing plain-English overview.

The store listing is the source of truth for what is actually live at any given moment.

## What the free version includes

MCP4SH can be used without a paid license for personal sim-racing use.

The free version includes:

- the core MCP4SH String Theory Haptics experience
- the main haptic effects in SimHub
- Setup Assistant
- shaker layout selection
- test-pulse mapping
- generated SimHub sound output profiles
- SimHub Helper guidance
- basic profile analysis

The free version is meant to get people driving, not trap the useful setup flow behind a paywall.

## What Premium adds

**MCP4SH Premium** unlocks the extra control layer.

Free gets the core experience working.
Premium gives you more ways to shape it around your own rig.

Current Premium value includes:

- advanced haptic fine-tuning controls
- the **ST Tensioner**, which dynamically prioritizes effects to help reduce unnecessary/unwanted buzzing while preserving useful tactile information
- deeper tuning options
- continued MCP4SH codec and effects development
- room for additional licensed configuration tools as MCP4SH evolves

In plain English:

**Free gets you driving. Premium gives you control.**

## Licensing tiers

### Current

- **Premium** — €12.99 standard price, perpetual personal license for 1 machine

Temporary promotions or discounts may be offered from time to time. The store listing remains the source of truth for the price and entitlement currently being sold.

### Legacy / grandfathered

- **Pioneer** — early-supporter offer, no longer sold to new customers. Existing Pioneer licenses retain their original grandfathered entitlement, including the original machine allowance.
- **Founder** — legacy/early entitlement where applicable; existing issued licenses retain their original entitlement.

### Possible future

- **Pro** may follow later with a higher machine allowance and/or additional licensed capabilities.

Exact availability, pricing and entitlement depend on what is live in the store.

## Important usage boundaries

Paid access does **not** permit:

- redistribution
- rehosting
- rebranding
- resale
- bundling the plugin into other paid packs or services without permission

For the actual usage restrictions, see:

- `LICENSE_PLUGIN.txt`

## One-line framing

**Free gives you the core MCP4SH String Theory Haptics experience. Premium gives you the control to shape it around your rig.**

## License restore and cache behaviour

MCP4SH stores license/cache data locally so a valid license can be restored when SimHub starts. The current licensing flow ignores implausibly short/partial key text and avoids dropping an already-valid cached license because of an ambiguous online refresh failure.

If you report a license issue, do not send the raw license key. Useful details are:
- whether the license field is empty, partial, or still contains the full key
- the exact status text shown
- whether restarting SimHub restores the license
- whether clicking Validate restores it
- whether SimHub is sometimes run as administrator and sometimes not
