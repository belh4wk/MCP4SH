# MCP4SH-SimHub-Einrichtung

Deine physische Shaker-Zuordnung ist abgeschlossen. Beende die SimHub-Seite in dieser Reihenfolge.

## 1. Sound-Output-Profil erzeugen

Wähle im **SimHub Helper** **Profil erzeugen**.

Setup Assistant erstellt für jedes zugeordnete Ausgabegerät eine `.sichannels`-Datei und speichert sie unter:

```text
Documents\SimHub\MCP4SH
```

Diese Dateien beschreiben **deine physischen Ausgabekanäle**. Sie werden aus der Zuordnung erzeugt, die du gerade durch Fühlen bestätigt hast.

## 2. MCP4SH-Effektprofil importieren

In SimHub:

1. Öffne **ShakeIt Bass Shakers**.
2. Öffne **Effects Profile**.
3. Öffne **Profiles Manager**.
4. Wähle **Import profile**.
5. Wähle das mitgelieferte MCP4SH-Standard-`.siprofile` aus `Documents\SimHub\MCP4SH`.

Das `.siprofile` enthält die MCP4SH-Effektformeln, Frequenzen, Routing-Absicht und Effektkonfiguration. Es ist **nicht** deine physische Kanalzuordnung.

## 3. Jede erzeugte `.sichannels`-Datei importieren

Weiterhin in **ShakeIt Bass Shakers**:

1. Öffne **Sound Output**.
2. Füge dasselbe Ausgabegerät hinzu oder aktiviere es, das du im Setup Assistant zugeordnet hast.
3. Wähle **Custom channel map**.
4. Wähle **Import**.
5. Wähle die erzeugte MCP4SH-`.sichannels`-Datei, die zu diesem Ausgabegerät gehört.
6. Wiederhole dies für jedes zugeordnete Ausgabegerät.

Importiere keine `.sichannels`-Datei in das falsche Gerät. Der Dateiname basiert absichtlich auf dem zugeordneten Ausgabegerät und den Kanalrollen.

## 4. Vor der Fahrt prüfen

Kehre in SimHub zu **MCP4SH** zurück und rechtsklicke in der Rig-Ansicht auf die zugeordneten Shaker-Positionen.

Jeder Testimpuls sollte den erwarteten physischen Shaker erreichen. Falls nicht, korrigiere die Zuordnung, bevor du Gains oder Effekte abstimmst.

Mit **Profil analysieren** im SimHub Helper kannst du außerdem eine `.sichannels`-Datei gegen die zuletzt gespeicherte physische Zuordnung prüfen.

## Die beiden Profiltypen getrennt halten

- `.siprofile` = das MCP4SH-**Effektprofil**. Tyto Sensory Labs kann aktualisierte Versionen dieser Datei bereitstellen.
- `.sichannels` = **dein erzeugtes physisches Sound-Output-Routing**. Setup Assistant erstellt diese Dateien aus deiner Rig-Zuordnung.

MCP4SH ersetzt oder aktiviert deine SimHub-Profile nicht stillschweigend.

## Rigs mit gemeinsam genutzten Kanälen

Sind zwei oder mehr Shaker physisch am selben Verstärkerkanal angeschlossen, kann SimHub sie nicht unabhängig ansteuern. Jeder Effekt auf diesem Kanal ist auf allen dort angeschlossenen Shakern zu spüren.

## Wenn etwas nicht stimmt

- Nutze **Profilordner öffnen**, um zu prüfen, welche Dateien erzeugt wurden.
- Nutze **Profil analysieren**, um das ausgewählte `.sichannels`-Routing zu prüfen.
- Führe die Zuordnung nur erneut durch, wenn die physische Geräte-/Kanalzuordnung falsch ist.
- Ändere nicht zuerst die einzelnen Effekt-Gains, um eine falsche Kanalzuordnung zu kompensieren.
