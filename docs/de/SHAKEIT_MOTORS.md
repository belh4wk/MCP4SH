# MCP4SH mit ShakeIt Motors verwenden

MCP4SH stellt öffentliche SimHub-Eigenschaften bereit, die auch außerhalb des normalen ShakeIt-Bass-Shakers-Ablaufs verwendet werden können.

Damit kannst du MCP4SH-Ausgaben auch in benutzerdefinierten **ShakeIt Motors**-Effekten verwenden, sofern der Motoreffekt SimHub-Eigenschaften über `$prop(...)` lesen kann.

Diese Anleitung ist für Nutzer gedacht, die mit Rumble-Motoren, Pedalmotoren, Gurtspannern, Lüftern, Servos oder anderem motorbasierten Feedback experimentieren möchten, das von MCP4SH angesteuert wird.

## Kurzfassung

MCP4SH muss ShakeIt Motors dafür nicht direkt steuern.

MCP4SH veröffentlicht nützliche Eigenschaften. ShakeIt Motors kann sie lesen und die Werte in benutzerdefinierten Motoreffekten verwenden.

Grundmuster der Formel:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.PROPERTY.NAME') || 0);
```

Die meisten MCP4SH-Eigenschaften sind von `0.0` bis `1.0` normalisiert.

SimHub-Motoreffekte erwarten häufig einen Wert von `0` bis `100`, daher multiplizieren die Beispiele unten mit `100`.

## Gute Kandidaten für Motoren

Motoren funktionieren meist am besten mit klaren Ereignis- oder Lastsignalen.

Gute Ausgangspunkte:

- ABS / Bremsblockieren
- TC-Aktivität
- Tyre-Scrub-/Schlupfsignale
- Brake Feel
- Chassis Load
- Gangwechsel
- Kupplungs-Freilauf
- ausgewählte Signale pro Rad

Sei bei sehr kontinuierlichen Effekten wie Motor, Antriebsstrang, Road Feel oder Federungsvibration vorsichtig. Sie können funktionieren, aber Motoren werden schnell unruhig oder dauerhaft aktiv, wenn der Effekt nicht auf Motorhardware abgestimmt ist.

## Empfohlene Formeln

### ABS / Bremsblockieren

Nützlich für Bremspedalmotoren, Vorderradmotoren oder Warnsignale bei Radblockieren.

Vorne:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.BrakeLock.FrontIntensity') || 0);
```

Hinten:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.BrakeLock.RearIntensity') || 0);
```

Pro Rad:

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

### TC-Aktivität

Nützlich für Hinterradmotoren, Gaspedal-Rumble oder Traktionswarnungen.

Vorne:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.TC.FrontActivity') || 0);
```

Hinten:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.TC.RearActivity') || 0);
```

Pro Rad:

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

Nützlich für Radmotoren, Sitzmotoren oder richtungsbezogene Reifenlastsignale.

Vorne:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.TyreScrub.FrontIntensity') || 0);
```

Hinten:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.TyreScrub.RearIntensity') || 0);
```

Pro Rad:

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

Nützlich für subtile Rad- oder Chassis-Motortextur.

Vorne:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.RoadFeel.FrontIntensity') || 0);
```

Hinten:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.RoadFeel.RearIntensity') || 0);
```

Pro Rad:

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

Nützlich für Bremspedalmotoren oder Bremslastsignale vorne/hinten.

Vorne:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.BrakeFeel.FrontIntensity') || 0);
```

Hinten:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.BrakeFeel.RearIntensity') || 0);
```

Pro Rad:

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

Nützlich für Gurte, Spanner, Sitzmotoren oder anhaltende Lastsignale.

Vorne:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.ChassisLoad.FrontIntensity') || 0);
```

Hinten:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.ChassisLoad.RearIntensity') || 0);
```

Links:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.ChassisLoad.LeftIntensity') || 0);
```

Rechts:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.ChassisLoad.RightIntensity') || 0);
```

Pro Rad:

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

Nützlich für gasabhängige Reifenbelastung oder kombinierte Leistungs-/Traktionssignale.

Vorne:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.EngineTyres.FrontIntensity') || 0);
```

Hinten:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.EngineTyres.RearIntensity') || 0);
```

Pro Rad:

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

### Gangwechsel- und Kupplungssignale

Diese eignen sich für kurze Motorimpulse.

Gangwechsel:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.Gearshift.Intensity') || 0);
```

Kupplungs-Freilauf:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.ClutchFreewheel.Intensity') || 0);
```

### Motor und Antriebsstrang

Diese können verwendet werden, sind aber kontinuierlicher. Beginne niedrig.

Motor vorne/hinten:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.Engine.FrontIntensity') || 0);
```

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.Engine.RearIntensity') || 0);
```

Antriebsstrang vorne/hinten:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.Drivetrain.FrontIntensity') || 0);
```

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.Drivetrain.RearIntensity') || 0);
```

Motor pro Rad:

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

Antriebsstrang pro Rad:

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

## Sicherere Motorskalierung

Einige Motoren können bei voller Skalierung zu aggressiv sein.

Versuche den Multiplikator zu reduzieren:

```js
return 60 * ($prop('MCP4SHPlugin.MCP4SH.BrakeLock.FrontIntensity') || 0);
```

Oder füge einen Schwellenwert hinzu, damit kleine Werte den Motor nicht auslösen:

```js
var v = $prop('MCP4SHPlugin.MCP4SH.TC.RearActivity') || 0;
return v > 0.08 ? 100 * v : 0;
```

Für ein schärferes Ereignisgefühl quadriere den Wert:

```js
var v = $prop('MCP4SHPlugin.MCP4SH.BrakeLock.FrontIntensity') || 0;
return 100 * v * v;
```

Für mehr Empfindlichkeit bei kleinen Werten nutze die Quadratwurzel:

```js
var v = $prop('MCP4SHPlugin.MCP4SH.TyreScrub.FrontIntensity') || 0;
return 100 * Math.sqrt(v);
```

## Empfohlene Ausgangspunkte

### Bremspedalmotor

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.BrakeLock.FrontIntensity') || 0);
```

oder:

```js
var lock = $prop('MCP4SHPlugin.MCP4SH.BrakeLock.FrontIntensity') || 0;
var brake = $prop('MCP4SHPlugin.MCP4SH.BrakeFeel.FrontIntensity') || 0;
return Math.max(100 * lock, 45 * brake);
```

### Gaspedalmotor

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.TC.RearActivity') || 0);
```

oder:

```js
var tc = $prop('MCP4SHPlugin.MCP4SH.TC.RearActivity') || 0;
var et = $prop('MCP4SHPlugin.MCP4SH.EngineTyres.RearIntensity') || 0;
return Math.max(100 * tc, 60 * et);
```

### Gangwechselmotor

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.Gearshift.Intensity') || 0);
```

### Lastsignal am Sitzmotor

```js
var rear = $prop('MCP4SHPlugin.MCP4SH.ChassisLoad.RearIntensity') || 0;
var scrub = $prop('MCP4SHPlugin.MCP4SH.TyreScrub.RearIntensity') || 0;
return Math.max(70 * rear, 100 * scrub);
```

## Fehlerbehebung

### Die Formel liefert immer null

Prüfe, ob MCP4SH aktiviert ist und SimHub Live-Telemetrie vom Spiel empfängt.

Prüfe auch den exakten Eigenschaftsnamen. SimHub-Eigenschaftsnamen sind in der Praxis groß-/kleinschreibungssensitiv, daher sorgfältig kopieren/einfügen.

### Der Motor ist immer aktiv

Reduziere den Multiplikator, füge einen Schwellenwert hinzu oder nutze eine stärker ereignisbezogene Eigenschaft.

Beispiel-Schwellenwert:

```js
var v = $prop('MCP4SHPlugin.MCP4SH.RoadFeel.FrontIntensity') || 0;
return v > 0.12 ? 70 * v : 0;
```

### Der Motor ist zu schwach

Erhöhe den Multiplikator vorsichtig:

```js
return 140 * ($prop('MCP4SHPlugin.MCP4SH.BrakeLock.FrontIntensity') || 0);
```

Nur tun, wenn dein Motor-Setup dies sicher verträgt.

### Der Motor fühlt sich unruhig an

Motoren eignen sich meist besser für klare Ereignisse als für kontinuierliche Textur. Probiere Brake Lock, TC, Gearshift oder Chassis Load, bevor du Road Feel oder Federungssignale nutzt.

## Zukünftige Richtung

MCP4SH könnte später einen eigenen ShakeIt-Motors-Helper im Plugin oder Setup Assistant erhalten.

Bis dahin zeigt diese Datei den praktischen Weg:

Verwende öffentliche MCP4SH-Eigenschaften in benutzerdefinierten ShakeIt-Motors-Formeln.
