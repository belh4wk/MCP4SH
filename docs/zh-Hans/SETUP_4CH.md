# MCP4SH 四角 SimHub 设置

本页适用于希望在 SimHub 中把 MCP4SH 效果分别路由到 FL、FR、RL、RR 车轮脚本框的用户。

主 v1.1 配置仍是推荐起点。当你需要手动四角配置，或把前/后配置转换为真正的四角路由时，请使用本页。

## 这些公式放在哪里

在 SimHub ShakeIt Bass Shakers 中打开需要路由的效果，然后把对应脚本放入独立的车轮输出框：

- `FL` = 左前
- `FR` = 右前
- `RL` = 左后
- `RR` = 右后

每个公式返回 `0..100`，这正是 SimHub 在这些脚本字段中需要的范围。

## 悬挂振动

用于连续的悬挂纹理/振荡通道。

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

## 悬挂冲击

用于独立的重击 / 触底 / 冲击通道。

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

## Tyre Scrub

用于 Tyre Scrub / 轮胎尖叫 / 滑动纹理通道。

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

## Road Feel

用于路面纹理 / 表面感觉通道。

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

## Chassis Load

用于持续的底盘张力 / 负载通道。

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

用于 MCP4SH 的发动机/轮胎组合交互通道。

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

## Brake Feel

用于刹车咬合 / 刹车纹理。

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

## ABS / 刹车锁死

用于 ABS、刹车锁死以及类似锁死的制动事件。

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

用于牵引力控制活动。

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

## 发动机

发动机本身并不真正具有左右之分，因此单轮输出会镜像前/后发动机通道，以便进行四角路由。

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

## 传动系统

传动系统本身也不真正具有左右之分，因此单轮输出会镜像前/后传动通道，以便进行四角路由。

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

## 说明

单轮属性是最终的公共路由输出，而不是原始遥测。

当 MCP4SH 拥有真实的单角数据，例如悬挂和由滑移推导的轮胎行为时，四角输出会使用这些数据。

当某个效果天然是前/后或整车性质，例如发动机和传动系统时，四角输出会保持易于路由，而不会假装存在独立的左右发动机。
