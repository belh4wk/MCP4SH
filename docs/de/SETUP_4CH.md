# MCP4SH 4-Ecken-SimHub-Einrichtung

Diese Seite ist für Nutzer gedacht, die MCP4SH-Effekte in SimHub auf getrennte Skriptfelder für FL, FR, RL und RR routen möchten.

Das Hauptprofil v1.1 bleibt der empfohlene Ausgangspunkt. Nutze diese Seite für ein manuelles 4-Ecken-Profil oder um ein Front/Rear-Profil in echtes Ecken-Routing umzuwandeln.

## Wohin diese Formeln gehören

Öffne in SimHub ShakeIt Bass Shakers den gewünschten Effekt und setze das passende Skript in die getrennten Radausgabefelder:

- `FL` = vorne links
- `FR` = vorne rechts
- `RL` = hinten links
- `RR` = hinten rechts

Jede Formel liefert `0..100`, genau das erwartet SimHub in diesen Skriptfeldern.

## Federungsvibration

Nutze diese für die kontinuierliche Federungs-Textur/Oszillation.

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

## Federungsimpakte

Nutze diese für die getrennte harte Schlag-/Durchschlag-/Impaktspur.

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

Nutze diese für Tyre Scrub / Reifenquietschen / Gleittextur.

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

Nutze diese für Straßentextur / Oberflächengefühl.

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

Nutze diese für anhaltende Chassisspannung / Last.

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

Nutze diese für MCP4SHs kombinierte Motor-/Reifen-Interaktionsspur.

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

Nutze diese für Bremsbiss / Bremstextur.

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

## ABS / Bremsblockieren

Nutze diese für ABS, Bremsblockieren und blockierähnliche Bremsereignisse.

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

Nutze diese für Aktivität der Traktionskontrolle.

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

## Motor

Ein Motor ist naturgemäß nicht wirklich links/rechts; die Ausgaben pro Rad spiegeln daher die Motor-Spuren vorne/hinten für einfacheres 4-Ecken-Routing.

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

## Antriebsstrang

Auch der Antriebsstrang ist naturgemäß nicht wirklich links/rechts; die Ausgaben pro Rad spiegeln daher die Antriebsstrang-Spuren vorne/hinten.

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

## Hinweise

Die Eigenschaften pro Rad sind finale öffentliche Routing-Ausgaben, keine Rohtelemetrie.

Wo MCP4SH echte Daten pro Ecke hat, etwa Federung und schlupfbasiertes Reifenverhalten, nutzen die Eckausgaben diese Daten.

Wo ein Effekt natürlicherweise vorne/hinten oder fürs ganze Fahrzeug gilt, etwa Motor und Antriebsstrang, halten die Eckausgaben das Routing einfach, ohne einen getrennten linken/rechten Motor vorzutäuschen.
