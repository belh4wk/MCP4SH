# Utiliser MCP4SH avec ShakeIt Motors

MCP4SH expose des propriétés SimHub publiques utilisables en dehors du flux habituel ShakeIt Bass Shakers.

Vous pouvez donc également utiliser les sorties MCP4SH dans des effets personnalisés **ShakeIt Motors**, tant que l’effet moteur peut lire les propriétés SimHub via `$prop(...)`.

Ce guide s’adresse aux utilisateurs qui souhaitent expérimenter avec des moteurs de vibration, moteurs de pédales, tendeurs de harnais, ventilateurs, servos ou d’autres retours de type moteur pilotés par MCP4SH.

## Version courte

MCP4SH n’a pas besoin de contrôler directement ShakeIt Motors pour que cela fonctionne.

MCP4SH publie des propriétés utiles. ShakeIt Motors peut les lire, puis utiliser ces valeurs dans des effets moteur personnalisés.

Formule de base :

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.PROPERTY.NAME') || 0);
```

La plupart des propriétés MCP4SH sont normalisées de `0.0` à `1.0`.

Les effets moteur SimHub attendent souvent une valeur de type `0` à `100`, les exemples ci-dessous multiplient donc par `100`.

## Bons candidats pour les moteurs

Les moteurs fonctionnent généralement mieux avec des événements ou indications de charge bien définis.

Bons points de départ :

- ABS / blocage des freins
- activité TC
- Tyre Scrub / indications de glissement
- Brake Feel
- Chassis Load
- changement de vitesse
- roue libre d’embrayage
- certaines indications par roue

Soyez prudent avec les effets très continus comme moteur, transmission, Road Feel ou vibration de suspension. Ils peuvent fonctionner, mais un moteur peut vite devenir bruyant ou actif en permanence si l’effet n’est pas adapté à ce matériel.

## Formules recommandées

### ABS / blocage des freins

Utile pour les moteurs de pédale de frein, moteurs avant ou alertes de blocage de roue.

Avant :

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.BrakeLock.FrontIntensity') || 0);
```

Arrière :

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.BrakeLock.RearIntensity') || 0);
```

Par roue :

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

### Activité TC

Utile pour les moteurs arrière, la vibration de la pédale d’accélérateur ou les alertes de traction.

Avant :

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.TC.FrontActivity') || 0);
```

Arrière :

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.TC.RearActivity') || 0);
```

Par roue :

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

Utile pour les moteurs de roue, de siège ou les indications directionnelles de contrainte des pneus.

Avant :

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.TyreScrub.FrontIntensity') || 0);
```

Arrière :

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.TyreScrub.RearIntensity') || 0);
```

Par roue :

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

Utile pour une texture subtile sur des moteurs de roue ou de châssis.

Avant :

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.RoadFeel.FrontIntensity') || 0);
```

Arrière :

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.RoadFeel.RearIntensity') || 0);
```

Par roue :

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

Utile pour les moteurs de pédale de frein ou les indications de charge de freinage avant/arrière.

Avant :

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.BrakeFeel.FrontIntensity') || 0);
```

Arrière :

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.BrakeFeel.RearIntensity') || 0);
```

Par roue :

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

Utile pour les harnais, tendeurs, moteurs de siège ou indications de charge soutenue.

Avant :

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.ChassisLoad.FrontIntensity') || 0);
```

Arrière :

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.ChassisLoad.RearIntensity') || 0);
```

Gauche :

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.ChassisLoad.LeftIntensity') || 0);
```

Droite :

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.ChassisLoad.RightIntensity') || 0);
```

Par roue :

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

Utile pour la contrainte des pneus liée à l’accélérateur ou les indications combinées puissance/traction.

Avant :

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.EngineTyres.FrontIntensity') || 0);
```

Arrière :

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.EngineTyres.RearIntensity') || 0);
```

Par roue :

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

### Indications de changement de vitesse et d’embrayage

Ces signaux conviennent bien aux impulsions moteur courtes.

Changement de vitesse :

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.Gearshift.Intensity') || 0);
```

Roue libre d’embrayage :

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.ClutchFreewheel.Intensity') || 0);
```

### Moteur et transmission

Ils peuvent être utilisés, mais sont plus continus. Commencez avec un niveau faible.

Moteur avant/arrière :

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.Engine.FrontIntensity') || 0);
```

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.Engine.RearIntensity') || 0);
```

Transmission avant/arrière :

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.Drivetrain.FrontIntensity') || 0);
```

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.Drivetrain.RearIntensity') || 0);
```

Moteur par roue :

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

Transmission par roue :

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

## Mise à l’échelle plus sûre

Certains moteurs peuvent être trop agressifs à pleine échelle.

Essayez de réduire le multiplicateur :

```js
return 60 * ($prop('MCP4SHPlugin.MCP4SH.BrakeLock.FrontIntensity') || 0);
```

Ou ajoutez un seuil pour que les petites valeurs ne déclenchent pas le moteur :

```js
var v = $prop('MCP4SHPlugin.MCP4SH.TC.RearActivity') || 0;
return v > 0.08 ? 100 * v : 0;
```

Pour un événement plus net, mettez la valeur au carré :

```js
var v = $prop('MCP4SHPlugin.MCP4SH.BrakeLock.FrontIntensity') || 0;
return 100 * v * v;
```

Pour plus de sensibilité aux faibles valeurs, utilisez la racine carrée :

```js
var v = $prop('MCP4SHPlugin.MCP4SH.TyreScrub.FrontIntensity') || 0;
return 100 * Math.sqrt(v);
```

## Points de départ suggérés

### Moteur de pédale de frein

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.BrakeLock.FrontIntensity') || 0);
```

ou :

```js
var lock = $prop('MCP4SHPlugin.MCP4SH.BrakeLock.FrontIntensity') || 0;
var brake = $prop('MCP4SHPlugin.MCP4SH.BrakeFeel.FrontIntensity') || 0;
return Math.max(100 * lock, 45 * brake);
```

### Moteur de pédale d’accélérateur

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.TC.RearActivity') || 0);
```

ou :

```js
var tc = $prop('MCP4SHPlugin.MCP4SH.TC.RearActivity') || 0;
var et = $prop('MCP4SHPlugin.MCP4SH.EngineTyres.RearIntensity') || 0;
return Math.max(100 * tc, 60 * et);
```

### Moteur de changement de vitesse

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.Gearshift.Intensity') || 0);
```

### Indication de charge sur moteur de siège

```js
var rear = $prop('MCP4SHPlugin.MCP4SH.ChassisLoad.RearIntensity') || 0;
var scrub = $prop('MCP4SHPlugin.MCP4SH.TyreScrub.RearIntensity') || 0;
return Math.max(70 * rear, 100 * scrub);
```

## Dépannage

### La formule renvoie toujours zéro

Vérifiez que MCP4SH est activé et que SimHub reçoit la télémétrie du jeu en direct.

Vérifiez également le nom exact de la propriété. En pratique, les noms de propriétés SimHub sont sensibles à la casse ; copiez-collez avec soin.

### Le moteur est toujours actif

Réduisez le multiplicateur, ajoutez un seuil ou utilisez une propriété davantage liée à un événement.

Exemple de seuil :

```js
var v = $prop('MCP4SHPlugin.MCP4SH.RoadFeel.FrontIntensity') || 0;
return v > 0.12 ? 70 * v : 0;
```

### Le moteur est trop faible

Augmentez prudemment le multiplicateur :

```js
return 140 * ($prop('MCP4SHPlugin.MCP4SH.BrakeLock.FrontIntensity') || 0);
```

Ne le faites que si votre installation moteur peut le supporter en toute sécurité.

### Le moteur semble bruyant

Les moteurs conviennent généralement mieux aux événements clairs qu’aux textures continues. Essayez Brake Lock, TC, Gearshift ou Chassis Load avant Road Feel ou les signaux de type suspension.

## Évolution future

MCP4SH pourra plus tard ajouter un assistant ShakeIt Motors dédié dans le plugin ou Setup Assistant.

Pour l’instant, ce fichier donne la méthode pratique :

Utilisez les propriétés publiques MCP4SH dans les formules personnalisées ShakeIt Motors.
