# Configuración SimHub MCP4SH de 4 esquinas

Esta página es para usuarios que quieran enrutar efectos MCP4SH a cuadros de script separados FL, FR, RL y RR en SimHub.

El perfil principal v1.1 sigue siendo el punto de partida recomendado. Usa esta página para un perfil manual de 4 esquinas o para convertir un perfil delante/detrás en enrutado real por esquina.

## Dónde van estas fórmulas

En SimHub ShakeIt Bass Shakers, abre el efecto que quieras enrutar y coloca el script correspondiente en los cuadros de salida separados por rueda:

- `FL` = delantero izquierdo
- `FR` = delantero derecho
- `RL` = trasero izquierdo
- `RR` = trasero derecho

Cada fórmula devuelve `0..100`, que es lo que SimHub espera en estos campos de script.

## Vibración de suspensión

Úsalas para la capa continua de textura/oscilación de suspensión.

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

## Impactos de suspensión

Úsalas para la capa separada de golpe fuerte / tope / impacto.

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

Úsalas para la capa Tyre Scrub / chirrido / textura de deslizamiento.

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

Úsalas para la capa de textura de carretera / sensación de superficie.

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

Úsalas para la capa sostenida de tensión / carga del chasis.

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

Úsalas para la capa combinada de interacción motor/neumático de MCP4SH.

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

Úsalas para mordida / textura de frenado.

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

## ABS / bloqueo de freno

Úsalas para ABS, bloqueo de freno y eventos de frenado similares al bloqueo.

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

Úsalas para actividad del control de tracción.

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

El motor no es realmente izquierdo/derecho por naturaleza, así que las salidas por rueda reflejan las capas de motor delante/detrás para facilitar el enrutado de 4 esquinas.

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

## Transmisión

La transmisión tampoco es realmente izquierda/derecha por naturaleza, así que las salidas por rueda reflejan las capas delante/detrás para facilitar el enrutado de 4 esquinas.

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

## Notas

Las propiedades por rueda son salidas públicas finales de enrutado, no telemetría en bruto.

Cuando MCP4SH dispone de datos reales por esquina, como suspensión y comportamiento del neumático derivado del deslizamiento, las salidas por esquina usan esos datos.

Cuando un efecto es naturalmente delante/detrás o de todo el coche, como motor y transmisión, las salidas por esquina facilitan el enrutado sin fingir que existe un motor izquierdo/derecho separado.
