# Configuration SimHub MCP4SH 4 coins

Cette page s’adresse aux utilisateurs qui souhaitent router les effets MCP4SH vers des champs de script distincts FL, FR, RL et RR dans SimHub.

Le profil principal v1.1 reste le point de départ recommandé. Utilisez cette page pour un profil manuel 4 coins ou pour convertir un profil avant/arrière en véritable routage par coin.

## Où placer ces formules

Dans SimHub ShakeIt Bass Shakers, ouvrez l’effet à router puis placez le script correspondant dans les champs de sortie séparés par roue :

- `FL` = avant gauche
- `FR` = avant droite
- `RL` = arrière gauche
- `RR` = arrière droite

Chaque formule renvoie `0..100`, le format attendu par SimHub dans ces champs de script.

## Vibration de suspension

Utilisez-les pour la couche continue de texture/oscillation de suspension.

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

## Impacts de suspension

Utilisez-les pour la couche distincte de choc fort / talonnage / impact.

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

Utilisez-les pour la couche Tyre Scrub / crissement / texture de glisse.

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

Utilisez-les pour la couche de texture de route / sensation de surface.

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

Utilisez-les pour la couche soutenue de tension / charge du châssis.

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

Utilisez-les pour la couche combinée d’interaction moteur/pneus de MCP4SH.

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

Utilisez-les pour le mordant / la texture de freinage.

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

## ABS / blocage des freins

Utilisez-les pour l’ABS, le blocage des freins et les événements de freinage proches du blocage.

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

Utilisez-les pour l’activité du contrôle de traction.

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

## Moteur

Le moteur n’est pas réellement gauche/droite par nature ; les sorties par roue reflètent donc les couches moteur avant/arrière pour faciliter le routage 4 coins.

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

## Transmission

La transmission n’est pas non plus réellement gauche/droite ; les sorties par roue reflètent donc les couches transmission avant/arrière pour faciliter le routage 4 coins.

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

Les propriétés par roue sont des sorties publiques finales de routage, pas de la télémétrie brute.

Lorsque MCP4SH dispose de vraies données par coin, comme la suspension et le comportement des pneus dérivé du glissement, les sorties par coin utilisent ces données.

Lorsqu’un effet est naturellement avant/arrière ou global, comme le moteur et la transmission, les sorties par coin facilitent le routage sans prétendre qu’il existe un moteur gauche/droite distinct.
