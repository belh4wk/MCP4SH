# MCP4SH SimHub 设置

物理振动器映射已经完成。请按以下顺序完成 SimHub 端的设置。

## 1. 生成 Sound Output 配置

在 **SimHub Helper** 中选择 **生成配置**。

Setup Assistant 会为每个已映射的输出设备创建一个 `.sichannels` 文件，并保存到：

```text
Documents\SimHub\MCP4SH
```

这些文件描述的是**你的物理输出通道**。它们根据你刚刚通过实际触感确认的映射生成。

## 2. 导入 MCP4SH 效果配置

在 SimHub 中：

1. 打开 **ShakeIt Bass Shakers**。
2. 打开 **Effects Profile**。
3. 打开 **Profiles Manager**。
4. 选择 **Import profile**。
5. 从 `Documents\SimHub\MCP4SH` 选择随附的 MCP4SH Standard `.siprofile`。

`.siprofile` 包含 MCP4SH 的效果公式、频率、路由意图和效果级配置。它**不是**你的物理通道映射。

## 3. 导入每个生成的 `.sichannels` 文件

仍然在 **ShakeIt Bass Shakers** 中：

1. 打开 **Sound Output**。
2. 添加或启用你在 Setup Assistant 中映射的同一个输出设备。
3. 选择 **Custom channel map**。
4. 选择 **Import**。
5. 选择与该输出设备匹配的已生成 MCP4SH `.sichannels` 文件。
6. 对每个已映射输出设备重复以上步骤。

不要把 `.sichannels` 文件导入错误的设备。文件名会有意包含映射的输出设备和通道角色信息。

## 4. 驾驶前验证

回到 SimHub 中的 **MCP4SH**，在 rig 视图中右键单击已映射的振动器位置。

每个测试脉冲都应该到达预期的物理振动器。如果不正确，请先修复映射，再调整增益或效果。

你也可以在 SimHub Helper 中使用 **分析配置**，将 `.sichannels` 文件与最近保存的物理映射进行检查。

## 区分两种配置文件

- `.siprofile` = MCP4SH **效果配置**。Tyto Sensory Labs 可以提供此文件的更新版本。
- `.sichannels` = **为你的 rig 生成的物理 Sound Output 路由**。Setup Assistant 根据你的 rig 映射创建这些文件。

MCP4SH 不会静默替换或激活你的 SimHub 配置。

## 共用通道的 rig

如果两个或更多振动器物理连接到同一个功放通道，SimHub 无法独立控制它们。发送到该通道的任何效果都会在所有连接到该通道的振动器上感觉到。

## 如果看起来不对

- 使用 **打开配置文件夹** 确认生成了哪些文件。
- 使用 **分析配置** 检查选中的 `.sichannels` 路由。
- 只有在物理设备/通道分配错误时才重新进行映射。
- 不要通过修改每个效果的增益来补偿错误的通道映射。
