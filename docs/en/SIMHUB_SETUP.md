# MCP4SH SimHub setup

Your physical shaker mapping is complete. Finish the SimHub side in this order.

## 1. Generate the Sound Output profile

In **SimHub Helper**, choose **Generate profile**.

Setup Assistant creates one `.sichannels` file for each mapped output device and writes it to:

```text
Documents\SimHub\MCP4SH
```

These files describe **your physical output channels**. They are generated from the mapping you just confirmed by feel.

## 2. Import the MCP4SH effects profile

In SimHub:

1. Open **ShakeIt Bass Shakers**.
2. Open **Effects Profile**.
3. Open **Profiles Manager**.
4. Choose **Import profile**.
5. Select the supplied MCP4SH Standard `.siprofile` from `Documents\SimHub\MCP4SH`.

The `.siprofile` contains the MCP4SH effect formulas, frequencies, routing intent, and effect-level configuration. It is **not** your physical channel map.

## 3. Import each generated `.sichannels` file

Still in **ShakeIt Bass Shakers**:

1. Open **Sound Output**.
2. Add or enable the same output device that you mapped in Setup Assistant.
3. Select **Custom channel map**.
4. Choose **Import**.
5. Select the generated MCP4SH `.sichannels` file that matches that output device.
6. Repeat for every mapped output device.

Do not import a `.sichannels` file into the wrong device. The filename is deliberately based on the mapped output device and channel roles.

## 4. Verify before driving

Return to **MCP4SH** in SimHub and right-click the mapped shaker positions in the rig view.

Each test pulse should reach the physical shaker you expect. If it does not, fix the mapping before tuning gains or effects.

You can also use **Analyze profile** in SimHub Helper to inspect a `.sichannels` file against the latest saved physical map.

## Keep the two profile types separate

- `.siprofile` = the MCP4SH **effects profile**. Tyto Sensory Labs can provide updated versions of this file.
- `.sichannels` = **your generated physical Sound Output routing**. Setup Assistant creates these from your rig mapping.

MCP4SH does not silently replace or activate your SimHub profiles.

## Shared-channel rigs

If two or more shakers are physically wired to the same amplifier channel, SimHub cannot address them independently. Any effect sent to that channel will be felt on every shaker connected to it.

## If something looks wrong

- Use **Open profile folder** to confirm which files were generated.
- Use **Analyze profile** to inspect the selected `.sichannels` routing.
- Re-run mapping only if the physical device/channel assignment is wrong.
- Do not start changing per-effect gains to compensate for an incorrect channel map.
