# MCP4SH 4-corner SimHub setup

This page is for users who want to route MCP4SH effects to separate FL, FR, RL, and RR wheel script boxes in SimHub.

The main v1.1 profile is still the recommended starting point. Use this page when you want a manual 4-corner profile, or when converting a front/rear profile into proper corner routing.

## Where these formulas go

In SimHub ShakeIt Bass Shakers, open the effect you want to route, then place the matching script in the separate wheel output boxes:

- `FL` = front left
- `FR` = front right
- `RL` = rear left
- `RR` = rear right

Each formula returns `0..100`, which is what SimHub expects in these script fields.

## Suspension vibration

Use these for the continuous suspension texture/oscillation lane.

### FL

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.Suspension.VibrationFL') || 0);
```

### FR

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.Suspension.VibrationFR') || 0);
```

### RL

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.Suspension.VibrationRL') || 0);
```

### RR

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.Suspension.VibrationRR') || 0);
```

## Suspension impacts

Use these for the separate hard-hit / bottoming / impact lane.

### FL

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.Suspension.ImpactFL') || 0);
```

### FR

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.Suspension.ImpactFR') || 0);
```

### RL

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.Suspension.ImpactRL') || 0);
```

### RR

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.Suspension.ImpactRR') || 0);
```

## Tyre scrub

Use these for the tyre scrub / tyre squeal / slide texture lane.

### FL

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.TyreScrub.FLIntensity') || 0);
```

### FR

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.TyreScrub.FRIntensity') || 0);
```

### RL

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.TyreScrub.RLIntensity') || 0);
```

### RR

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.TyreScrub.RRIntensity') || 0);
```

## Road feel

Use these for the road texture / surface feel lane.

### FL

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.RoadFeel.FLIntensity') || 0);
```

### FR

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.RoadFeel.FRIntensity') || 0);
```

### RL

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.RoadFeel.RLIntensity') || 0);
```

### RR

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.RoadFeel.RRIntensity') || 0);
```

## Chassis load

Use these for the sustained chassis tension / load lane.

### FL

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.ChassisLoad.FLIntensity') || 0);
```

### FR

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.ChassisLoad.FRIntensity') || 0);
```

### RL

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.ChassisLoad.RLIntensity') || 0);
```

### RR

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.ChassisLoad.RRIntensity') || 0);
```

## Engine & Tyres

Use these for MCP4SH's combined engine/tyre interaction lane.

### FL

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.EngineTyres.FLIntensity') || 0);
```

### FR

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.EngineTyres.FRIntensity') || 0);
```

### RL

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.EngineTyres.RLIntensity') || 0);
```

### RR

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.EngineTyres.RRIntensity') || 0);
```

## Brake feel

Use these for brake bite / brake texture.

### FL

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.BrakeFeel.FLIntensity') || 0);
```

### FR

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.BrakeFeel.FRIntensity') || 0);
```

### RL

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.BrakeFeel.RLIntensity') || 0);
```

### RR

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.BrakeFeel.RRIntensity') || 0);
```

## ABS / brake lock

Use these for ABS, brake lock, and lock-like braking events.

### FL

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.BrakeLock.FLIntensity') || 0);
```

### FR

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.BrakeLock.FRIntensity') || 0);
```

### RL

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.BrakeLock.RLIntensity') || 0);
```

### RR

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.BrakeLock.RRIntensity') || 0);
```

## TC

Use these for traction-control activity.

### FL

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.TC.FLActivity') || 0);
```

### FR

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.TC.FRActivity') || 0);
```

### RL

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.TC.RLActivity') || 0);
```

### RR

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.TC.RRActivity') || 0);
```

## Engine

Engine is not truly left/right by nature, so the per-wheel outputs mirror the front/rear engine lanes for easier 4-corner routing.

### FL

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.Engine.FLIntensity') || 0);
```

### FR

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.Engine.FRIntensity') || 0);
```

### RL

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.Engine.RLIntensity') || 0);
```

### RR

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.Engine.RRIntensity') || 0);
```

## Drivetrain

Drivetrain is also not truly left/right by nature, so the per-wheel outputs mirror the front/rear drivetrain lanes for easier 4-corner routing.

### FL

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.Drivetrain.FLIntensity') || 0);
```

### FR

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.Drivetrain.FRIntensity') || 0);
```

### RL

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.Drivetrain.RLIntensity') || 0);
```

### RR

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.Drivetrain.RRIntensity') || 0);
```

## Notes

The per-wheel properties are final public routing outputs, not raw telemetry.

Where MCP4SH has real per-corner data, such as suspension and slip-derived tyre behaviour, the corner outputs use that data.

Where an effect is naturally front/rear or whole-car, such as engine and drivetrain, the corner outputs keep the effect easy to route without pretending there is a separate left/right engine.
