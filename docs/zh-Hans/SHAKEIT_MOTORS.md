# 在 ShakeIt Motors 中使用 MCP4SH

MCP4SH 提供公共 SimHub 属性，可在常规 ShakeIt Bass Shakers 流程之外使用。

这意味着只要电机效果可以通过 `$prop(...)` 读取 SimHub 属性，你也可以在 **ShakeIt Motors** 自定义效果中使用 MCP4SH 输出。

本指南适用于希望尝试由 MCP4SH 驱动的震动电机、踏板电机、安全带张紧器、风扇、舵机或其他电机式反馈的用户。

## 简短说明

MCP4SH 不需要直接控制 ShakeIt Motors。

MCP4SH 会发布有用的属性。ShakeIt Motors 可以读取这些属性，然后在自定义电机效果中使用这些值。

基本公式模式：

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.PROPERTY.NAME') || 0);
```

大多数 MCP4SH 属性都归一化为 `0.0` 到 `1.0`。

SimHub 电机效果通常需要 `0` 到 `100` 的数值，因此下面的示例会乘以 `100`。

## 适合电机的信号

电机通常更适合清晰的事件或负载提示。

推荐起点：

- ABS / 刹车锁死
- TC 活动
- Tyre Scrub / 滑移提示
- Brake Feel
- Chassis Load
- 换挡
- 离合空转
- 部分单轮提示

对发动机、传动、Road Feel 或悬挂振动这类连续效果要谨慎。它们可以工作，但如果未针对电机硬件调校，电机很容易变得嘈杂或持续工作。

## 推荐公式

### ABS / 刹车锁死

适用于刹车踏板电机、前轮电机或车轮锁死警告。

前：

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.BrakeLock.FrontIntensity') || 0);
```

后：

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.BrakeLock.RearIntensity') || 0);
```

每个车轮：

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

### TC 活动

适用于后轮电机、油门踏板震动或牵引力警告。

前：

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.TC.FrontActivity') || 0);
```

后：

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.TC.RearActivity') || 0);
```

每个车轮：

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

适用于车轮电机、座椅电机或有方向性的轮胎受力提示。

前：

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.TyreScrub.FrontIntensity') || 0);
```

后：

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.TyreScrub.RearIntensity') || 0);
```

每个车轮：

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

适用于细微的车轮或底盘电机纹理。

前：

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.RoadFeel.FrontIntensity') || 0);
```

后：

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.RoadFeel.RearIntensity') || 0);
```

每个车轮：

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

适用于刹车踏板电机或前后制动负载提示。

前：

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.BrakeFeel.FrontIntensity') || 0);
```

后：

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.BrakeFeel.RearIntensity') || 0);
```

每个车轮：

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

适用于安全带、张紧器、座椅电机或持续负载提示。

前：

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.ChassisLoad.FrontIntensity') || 0);
```

后：

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.ChassisLoad.RearIntensity') || 0);
```

左：

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.ChassisLoad.LeftIntensity') || 0);
```

右：

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.ChassisLoad.RightIntensity') || 0);
```

每个车轮：

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

适用于与油门相关的轮胎受力或动力/牵引力组合提示。

前：

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.EngineTyres.FrontIntensity') || 0);
```

后：

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.EngineTyres.RearIntensity') || 0);
```

每个车轮：

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

### 换挡与离合提示

这些信号适合短促的电机脉冲。

换挡：

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.Gearshift.Intensity') || 0);
```

离合空转：

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.ClutchFreewheel.Intensity') || 0);
```

### 发动机与传动

这些也可以使用，但更连续。请从较低强度开始。

发动机前/后：

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.Engine.FrontIntensity') || 0);
```

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.Engine.RearIntensity') || 0);
```

传动前/后：

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.Drivetrain.FrontIntensity') || 0);
```

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.Drivetrain.RearIntensity') || 0);
```

每轮发动机：

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

每轮传动：

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

## 更安全的电机缩放

某些电机在满幅时可能过于激烈。

尝试降低乘数：

```js
return 60 * ($prop('MCP4SHPlugin.MCP4SH.BrakeLock.FrontIntensity') || 0);
```

或者加入阈值，让很小的数值不会触发电机：

```js
var v = $prop('MCP4SHPlugin.MCP4SH.TC.RearActivity') || 0;
return v > 0.08 ? 100 * v : 0;
```

要获得更清晰的事件感，可对数值平方：

```js
var v = $prop('MCP4SHPlugin.MCP4SH.BrakeLock.FrontIntensity') || 0;
return 100 * v * v;
```

要提高低值敏感度，可使用平方根：

```js
var v = $prop('MCP4SHPlugin.MCP4SH.TyreScrub.FrontIntensity') || 0;
return 100 * Math.sqrt(v);
```

## 建议起点

### 刹车踏板电机

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.BrakeLock.FrontIntensity') || 0);
```

或：

```js
var lock = $prop('MCP4SHPlugin.MCP4SH.BrakeLock.FrontIntensity') || 0;
var brake = $prop('MCP4SHPlugin.MCP4SH.BrakeFeel.FrontIntensity') || 0;
return Math.max(100 * lock, 45 * brake);
```

### 油门踏板电机

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.TC.RearActivity') || 0);
```

或：

```js
var tc = $prop('MCP4SHPlugin.MCP4SH.TC.RearActivity') || 0;
var et = $prop('MCP4SHPlugin.MCP4SH.EngineTyres.RearIntensity') || 0;
return Math.max(100 * tc, 60 * et);
```

### 换挡电机

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.Gearshift.Intensity') || 0);
```

### 座椅电机负载提示

```js
var rear = $prop('MCP4SHPlugin.MCP4SH.ChassisLoad.RearIntensity') || 0;
var scrub = $prop('MCP4SHPlugin.MCP4SH.TyreScrub.RearIntensity') || 0;
return Math.max(70 * rear, 100 * scrub);
```

## 故障排查

### 公式始终返回零

确认 MCP4SH 已启用，并且 SimHub 正在接收游戏实时遥测。

同时检查属性名称是否完全正确。实际使用中 SimHub 属性名称区分大小写，请谨慎复制粘贴。

### 电机始终工作

降低乘数、添加阈值，或使用更偏事件型的属性。

阈值示例：

```js
var v = $prop('MCP4SHPlugin.MCP4SH.RoadFeel.FrontIntensity') || 0;
return v > 0.12 ? 70 * v : 0;
```

### 电机太弱

谨慎提高乘数：

```js
return 140 * ($prop('MCP4SHPlugin.MCP4SH.BrakeLock.FrontIntensity') || 0);
```

仅在你的电机系统能够安全承受时这样做。

### 电机感觉杂乱

电机通常更适合清晰事件，而不是连续纹理。使用 Road Feel 或悬挂类信号前，先尝试 Brake Lock、TC、Gearshift 或 Chassis Load。

## 未来方向

MCP4SH 未来可能会在插件或 Setup Assistant 中加入专用 ShakeIt Motors Helper。

目前，本文件给出实际可用的方法：

在 ShakeIt Motors 自定义公式中使用 MCP4SH 公共属性。
