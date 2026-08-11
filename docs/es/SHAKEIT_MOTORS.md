# Usar MCP4SH con ShakeIt Motors

MCP4SH expone propiedades públicas de SimHub que pueden utilizarse fuera del flujo normal de ShakeIt Bass Shakers.

Esto significa que también puedes usar la salida de MCP4SH dentro de efectos personalizados de **ShakeIt Motors**, siempre que el efecto pueda leer propiedades de SimHub mediante `$prop(...)`.

Esta guía es para usuarios que quieran experimentar con motores de vibración, motores de pedal, tensores de cinturón, ventiladores, servos u otros tipos de feedback motorizado controlados por MCP4SH.

## Versión corta

MCP4SH no necesita controlar directamente ShakeIt Motors para que esto funcione.

MCP4SH publica propiedades útiles. ShakeIt Motors puede leerlas y usar esos valores en efectos de motor personalizados.

Patrón básico de fórmula:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.PROPERTY.NAME') || 0);
```

La mayoría de propiedades de MCP4SH están normalizadas de `0.0` a `1.0`.

Los efectos de motor de SimHub suelen esperar un valor de `0` a `100`, por eso los ejemplos multiplican por `100`.

## Buenos candidatos para motores

Los motores suelen funcionar mejor con eventos o señales de carga claras.

Buenos puntos de partida:

- ABS / bloqueo de freno
- actividad TC
- Tyre Scrub / señales de deslizamiento
- Brake Feel
- Chassis Load
- cambio de marcha
- rueda libre del embrague
- señales seleccionadas por rueda

Ten cuidado con efectos muy continuos como motor, transmisión, Road Feel o vibración de suspensión. Pueden funcionar, pero los motores pueden volverse ruidosos o estar activos constantemente si el efecto no está ajustado para este hardware.

## Fórmulas recomendadas

### ABS / bloqueo de freno

Útil para motores del pedal de freno, motores delanteros o avisos de bloqueo de rueda.

Delante:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.BrakeLock.FrontIntensity') || 0);
```

Detrás:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.BrakeLock.RearIntensity') || 0);
```

Por rueda:

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

### Actividad TC

Útil para motores traseros, vibración del acelerador o avisos de tracción.

Delante:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.TC.FrontActivity') || 0);
```

Detrás:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.TC.RearActivity') || 0);
```

Por rueda:

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

Útil para motores de rueda, de asiento o señales direccionales de esfuerzo del neumático.

Delante:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.TyreScrub.FrontIntensity') || 0);
```

Detrás:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.TyreScrub.RearIntensity') || 0);
```

Por rueda:

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

Útil para una textura sutil en motores de rueda o chasis.

Delante:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.RoadFeel.FrontIntensity') || 0);
```

Detrás:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.RoadFeel.RearIntensity') || 0);
```

Por rueda:

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

Útil para motores del pedal de freno o señales de carga de frenada delante/detrás.

Delante:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.BrakeFeel.FrontIntensity') || 0);
```

Detrás:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.BrakeFeel.RearIntensity') || 0);
```

Por rueda:

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

Útil para cinturones, tensores, motores de asiento o señales de carga sostenida.

Delante:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.ChassisLoad.FrontIntensity') || 0);
```

Detrás:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.ChassisLoad.RearIntensity') || 0);
```

Izquierda:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.ChassisLoad.LeftIntensity') || 0);
```

Derecha:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.ChassisLoad.RightIntensity') || 0);
```

Por rueda:

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

Útil para esfuerzo del neumático relacionado con el acelerador o señales combinadas de potencia/tracción.

Delante:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.EngineTyres.FrontIntensity') || 0);
```

Detrás:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.EngineTyres.RearIntensity') || 0);
```

Por rueda:

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

### Señales de cambio y embrague

Son útiles para pulsos cortos del motor.

Cambio de marcha:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.Gearshift.Intensity') || 0);
```

Rueda libre del embrague:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.ClutchFreewheel.Intensity') || 0);
```

### Motor y transmisión

Se pueden usar, pero son más continuos. Empieza bajo.

Motor delante/detrás:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.Engine.FrontIntensity') || 0);
```

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.Engine.RearIntensity') || 0);
```

Transmisión delante/detrás:

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.Drivetrain.FrontIntensity') || 0);
```

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.Drivetrain.RearIntensity') || 0);
```

Motor por rueda:

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

Transmisión por rueda:

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

## Escalado de motor más seguro

Algunos motores pueden ser demasiado agresivos a escala completa.

Prueba a reducir el multiplicador:

```js
return 60 * ($prop('MCP4SHPlugin.MCP4SH.BrakeLock.FrontIntensity') || 0);
```

O añade un umbral para que valores pequeños no activen el motor:

```js
var v = $prop('MCP4SHPlugin.MCP4SH.TC.RearActivity') || 0;
return v > 0.08 ? 100 * v : 0;
```

Para eventos más definidos, eleva el valor al cuadrado:

```js
var v = $prop('MCP4SHPlugin.MCP4SH.BrakeLock.FrontIntensity') || 0;
return 100 * v * v;
```

Para más sensibilidad con valores bajos, usa la raíz cuadrada:

```js
var v = $prop('MCP4SHPlugin.MCP4SH.TyreScrub.FrontIntensity') || 0;
return 100 * Math.sqrt(v);
```

## Puntos de partida sugeridos

### Motor del pedal de freno

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.BrakeLock.FrontIntensity') || 0);
```

o:

```js
var lock = $prop('MCP4SHPlugin.MCP4SH.BrakeLock.FrontIntensity') || 0;
var brake = $prop('MCP4SHPlugin.MCP4SH.BrakeFeel.FrontIntensity') || 0;
return Math.max(100 * lock, 45 * brake);
```

### Motor del pedal del acelerador

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.TC.RearActivity') || 0);
```

o:

```js
var tc = $prop('MCP4SHPlugin.MCP4SH.TC.RearActivity') || 0;
var et = $prop('MCP4SHPlugin.MCP4SH.EngineTyres.RearIntensity') || 0;
return Math.max(100 * tc, 60 * et);
```

### Motor de cambio de marcha

```js
return 100 * ($prop('MCP4SHPlugin.MCP4SH.Gearshift.Intensity') || 0);
```

### Señal de carga en motor de asiento

```js
var rear = $prop('MCP4SHPlugin.MCP4SH.ChassisLoad.RearIntensity') || 0;
var scrub = $prop('MCP4SHPlugin.MCP4SH.TyreScrub.RearIntensity') || 0;
return Math.max(70 * rear, 100 * scrub);
```

## Solución de problemas

### La fórmula siempre devuelve cero

Comprueba que MCP4SH esté activado y que SimHub reciba telemetría en vivo del juego.

Comprueba también el nombre exacto de la propiedad. En la práctica, los nombres de propiedades de SimHub distinguen mayúsculas y minúsculas; copia y pega con cuidado.

### El motor siempre está activo

Reduce el multiplicador, añade un umbral o usa una propiedad más ligada a eventos.

Ejemplo de umbral:

```js
var v = $prop('MCP4SHPlugin.MCP4SH.RoadFeel.FrontIntensity') || 0;
return v > 0.12 ? 70 * v : 0;
```

### El motor es demasiado débil

Aumenta el multiplicador con cuidado:

```js
return 140 * ($prop('MCP4SHPlugin.MCP4SH.BrakeLock.FrontIntensity') || 0);
```

Hazlo solo si tu configuración de motor puede soportarlo con seguridad.

### El motor se siente ruidoso

Los motores suelen ser mejores para eventos claros que para textura continua. Prueba Brake Lock, TC, Gearshift o Chassis Load antes de Road Feel o señales de suspensión.

## Dirección futura

MCP4SH podría añadir más adelante un ShakeIt Motors Helper dedicado dentro del plugin o Setup Assistant.

Por ahora, este archivo muestra el camino práctico:

Usa las propiedades públicas de MCP4SH dentro de fórmulas personalizadas de ShakeIt Motors.
