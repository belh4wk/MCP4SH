# Configuración de MCP4SH en SimHub

El mapeo físico de tus shakers está completado. Termina la parte de SimHub en este orden.

## 1. Generar el perfil de Sound Output

En **SimHub Helper**, elige **Generar perfil**.

Setup Assistant crea un archivo `.sichannels` para cada dispositivo de salida mapeado y lo guarda en:

```text
Documents\SimHub\MCP4SH
```

Estos archivos describen **tus canales de salida físicos**. Se generan a partir del mapeo que acabas de confirmar por tacto.

## 2. Importar el perfil de efectos MCP4SH

En SimHub:

1. Abre **ShakeIt Bass Shakers**.
2. Abre **Effects Profile**.
3. Abre **Profiles Manager**.
4. Elige **Import profile**.
5. Selecciona el `.siprofile` Standard de MCP4SH incluido desde `Documents\SimHub\MCP4SH`.

El `.siprofile` contiene las fórmulas de efectos de MCP4SH, frecuencias, intención de enrutado y configuración de efectos. **No** es tu mapa físico de canales.

## 3. Importar cada archivo `.sichannels` generado

Todavía en **ShakeIt Bass Shakers**:

1. Abre **Sound Output**.
2. Añade o activa el mismo dispositivo de salida que mapeaste en Setup Assistant.
3. Selecciona **Custom channel map**.
4. Elige **Import**.
5. Selecciona el archivo MCP4SH `.sichannels` generado que corresponda a ese dispositivo de salida.
6. Repite el proceso para cada dispositivo de salida mapeado.

No importes un archivo `.sichannels` en el dispositivo equivocado. El nombre del archivo se basa deliberadamente en el dispositivo de salida mapeado y en los roles de canal.

## 4. Verificar antes de conducir

Vuelve a **MCP4SH** en SimHub y haz clic derecho sobre las posiciones de shaker mapeadas en la vista del rig.

Cada pulso de prueba debe llegar al shaker físico esperado. Si no es así, corrige el mapeo antes de ajustar ganancias o efectos.

También puedes usar **Analizar perfil** en SimHub Helper para comprobar un archivo `.sichannels` frente al último mapa físico guardado.

## Mantén separados los dos tipos de perfil

- `.siprofile` = el **perfil de efectos** MCP4SH. Tyto Sensory Labs puede proporcionar versiones actualizadas de este archivo.
- `.sichannels` = **tu enrutado físico de Sound Output generado**. Setup Assistant crea estos archivos a partir del mapeo de tu rig.

MCP4SH no sustituye ni activa silenciosamente tus perfiles de SimHub.

## Rigs con canales compartidos

Si dos o más shakers están conectados físicamente al mismo canal del amplificador, SimHub no puede controlarlos de forma independiente. Cualquier efecto enviado a ese canal se sentirá en todos los shakers conectados a él.

## Si algo parece incorrecto

- Usa **Abrir carpeta de perfiles** para confirmar qué archivos se generaron.
- Usa **Analizar perfil** para inspeccionar el enrutado `.sichannels` seleccionado.
- Repite el mapeo solo si la asignación física de dispositivo/canal es incorrecta.
- No empieces cambiando ganancias por efecto para compensar un mapa de canales incorrecto.
