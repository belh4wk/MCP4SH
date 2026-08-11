# Using MCP4SH with ShakeIt Motors

MCP4SH exposes public SimHub properties that can be used outside the normal ShakeIt Bass Shakers flow.

That means you can also use MCP4SH output inside **ShakeIt Motors** custom effects, as long as the motor effect can read SimHub properties through `$prop(...)`.

This guide is for users who want to experiment with rumble motors, pedal motors, belt tensioners, fans, servos, or other motor-style feedback driven by MCP4SH.

## Short version

MCP4SH does not need to directly control ShakeIt Motors for this to work.

MCP4SH publishes useful properties. ShakeIt Motors can read those properties. You can then use those values in custom motor effects.

Basic formula pattern:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.PROPERTY.NAME') || 0);
```

Most MCP4SH properties are normalized from `0.0` to `1.0`.

SimHub motor effects often expect a `0` to `100` style value, so the examples below multiply by `100`.

## Good motor candidates

Motors usually work best with clearer event or load cues.

Good starting points:

- ABS / brake lock
- TC activity
- tyre scrub / slip cues
- brake feel
- chassis load
- gearshift
- clutch freewheel
- selected per-wheel cues

Use care with very continuous effects like engine, drivetrain, road feel, or suspension vibration. They can work, but motors can quickly become noisy or constantly active if the effect is not tuned for motor hardware.

## Recommended formulas

### ABS / brake lock

Useful for brake pedal motors, front wheel motors, or wheel lock warning cues.

Front:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.BrakeLock.FrontIntensity') || 0);
```

Rear:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.BrakeLock.RearIntensity') || 0);
```

Per wheel:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.BrakeLock.FLIntensity') || 0);
```

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.BrakeLock.FRIntensity') || 0);
```

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.BrakeLock.RLIntensity') || 0);
```

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.BrakeLock.RRIntensity') || 0);
```

### TC activity

Useful for rear wheel motors, throttle pedal rumble, or traction warning cues.

Front:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.TC.FrontActivity') || 0);
```

Rear:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.TC.RearActivity') || 0);
```

Per wheel:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.TC.FLActivity') || 0);
```

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.TC.FRActivity') || 0);
```

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.TC.RLActivity') || 0);
```

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.TC.RRActivity') || 0);
```

### Tyre Scrub

Useful for wheel motors, seat motors, or directional tyre stress cues.

Front:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.TyreScrub.FrontIntensity') || 0);
```

Rear:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.TyreScrub.RearIntensity') || 0);
```

Per wheel:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.TyreScrub.FLIntensity') || 0);
```

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.TyreScrub.FRIntensity') || 0);
```

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.TyreScrub.RLIntensity') || 0);
```

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.TyreScrub.RRIntensity') || 0);
```

### Road Feel

Useful for subtle wheel or chassis motor texture.

Front:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.RoadFeel.FrontIntensity') || 0);
```

Rear:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.RoadFeel.RearIntensity') || 0);
```

Per wheel:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.RoadFeel.FLIntensity') || 0);
```

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.RoadFeel.FRIntensity') || 0);
```

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.RoadFeel.RLIntensity') || 0);
```

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.RoadFeel.RRIntensity') || 0);
```

### Brake Feel

Useful for brake pedal motors or front/rear braking load cues.

Front:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.BrakeFeel.FrontIntensity') || 0);
```

Rear:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.BrakeFeel.RearIntensity') || 0);
```

Per wheel:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.BrakeFeel.FLIntensity') || 0);
```

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.BrakeFeel.FRIntensity') || 0);
```

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.BrakeFeel.RLIntensity') || 0);
```

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.BrakeFeel.RRIntensity') || 0);
```

### Chassis Load

Useful for belts, tensioners, seat motors, or sustained load cues.

Front:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.ChassisLoad.FrontIntensity') || 0);
```

Rear:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.ChassisLoad.RearIntensity') || 0);
```

Left:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.ChassisLoad.LeftIntensity') || 0);
```

Right:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.ChassisLoad.RightIntensity') || 0);
```

Per wheel:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.ChassisLoad.FLIntensity') || 0);
```

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.ChassisLoad.FRIntensity') || 0);
```

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.ChassisLoad.RLIntensity') || 0);
```

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.ChassisLoad.RRIntensity') || 0);
```

### Engine & Tyres

Useful for throttle-related tyre stress or combined power/traction cues.

Front:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.EngineTyres.FrontIntensity') || 0);
```

Rear:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.EngineTyres.RearIntensity') || 0);
```

Per wheel:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.EngineTyres.FLIntensity') || 0);
```

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.EngineTyres.FRIntensity') || 0);
```

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.EngineTyres.RLIntensity') || 0);
```

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.EngineTyres.RRIntensity') || 0);
```

### Gearshift and clutch cues

These are useful for short motor pulses.

Gearshift:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.Gearshift.Intensity') || 0);
```

Clutch freewheel:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.ClutchFreewheel.Intensity') || 0);
```

### Engine and drivetrain

These can be used, but they are more continuous. Start low.

Engine front/rear:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.Engine.FrontIntensity') || 0);
```

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.Engine.RearIntensity') || 0);
```

Drivetrain front/rear:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.Drivetrain.FrontIntensity') || 0);
```

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.Drivetrain.RearIntensity') || 0);
```

Per wheel engine:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.Engine.FLIntensity') || 0);
```

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.Engine.FRIntensity') || 0);
```

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.Engine.RLIntensity') || 0);
```

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.Engine.RRIntensity') || 0);
```

Per wheel drivetrain:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.Drivetrain.FLIntensity') || 0);
```

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.Drivetrain.FRIntensity') || 0);
```

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.Drivetrain.RLIntensity') || 0);
```

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.Drivetrain.RRIntensity') || 0);
```

## Safer motor scaling

Some motors may be too aggressive at full scale.

Try reducing the multiplier:

```js
return 60 * ($prop('MCP4SHPlugin.MCP4SH.BrakeLock.FrontIntensity') || 0);
```

Or add a threshold so tiny values do not trigger the motor:

```js
var v = $prop('MCP4SHPlugin.MCP4SH.TC.RearActivity') || 0;
return v > 0.08 ? 100 * v : 0;
```

For sharper event feel, square the value:

```js
var v = $prop('MCP4SHPlugin.MCP4SH.BrakeLock.FrontIntensity') || 0;
return 100 * v * v;
```

For more sensitivity at lower values, use square root:

```js
var v = $prop('MCP4SHPlugin.MCP4SH.TyreScrub.FrontIntensity') || 0;
return 100 * Math.sqrt(v);
```

## Suggested starting points

### Brake pedal motor

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.BrakeLock.FrontIntensity') || 0);
```

or:

```js
var lock = $prop('MCP4SHPlugin.MCP4SH.BrakeLock.FrontIntensity') || 0;
var brake = $prop('MCP4SHPlugin.MCP4SH.BrakeFeel.FrontIntensity') || 0;
return Math.max(100 * lock, 45 * brake);
```

### Throttle pedal motor

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.TC.RearActivity') || 0);
```

or:

```js
var tc = $prop('MCP4SHPlugin.MCP4SH.TC.RearActivity') || 0;
var et = $prop('MCP4SHPlugin.MCP4SH.EngineTyres.RearIntensity') || 0;
return Math.max(100 * tc, 60 * et);
```

### Gearshift motor

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.Gearshift.Intensity') || 0);
```

### Seat motor load cue

```js
var rear = $prop('MCP4SHPlugin.MCP4SH.ChassisLoad.RearIntensity') || 0;
var scrub = $prop('MCP4SHPlugin.MCP4SH.TyreScrub.RearIntensity') || 0;
return Math.max(70 * rear, 100 * scrub);
```

## Troubleshooting

### The formula always returns zero

Check that MCP4SH is enabled and SimHub is receiving live game telemetry.

Also check the exact property name. SimHub property names are case-sensitive in practice, so copy/paste carefully.

### The motor is always active

Reduce the multiplier, add a threshold, or use a more event-like property.

Example threshold:

```js
var v = $prop('MCP4SHPlugin.MCP4SH.RoadFeel.FrontIntensity') || 0;
return v > 0.12 ? 70 * v : 0;
```

### The motor is too weak

Increase the multiplier carefully:

```js
return 140 * ($prop('MCP4SHPlugin.MCP4SH.BrakeLock.FrontIntensity') || 0);
```

Only do this if your motor setup can handle it safely.

### The motor feels noisy

Motors are usually better for clear events than continuous texture. Try Brake Lock, TC, Gearshift, or Chassis Load before using Road Feel or Suspension-style signals.

## Future direction

MCP4SH may later add a dedicated ShakeIt Motors Helper inside the plugin or Setup Assistant.

For now, this file gives the practical path:

Use MCP4SH public properties inside ShakeIt Motors custom formulas.
