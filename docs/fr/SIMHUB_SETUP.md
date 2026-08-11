# Configuration MCP4SH dans SimHub

Votre mappage physique des shakers est terminé. Finalisez la partie SimHub dans cet ordre.

## 1. Générer le profil Sound Output

Dans **SimHub Helper**, choisissez **Générer le profil**.

Setup Assistant crée un fichier `.sichannels` pour chaque périphérique de sortie mappé et l'enregistre dans :

```text
Documents\SimHub\MCP4SH
```

Ces fichiers décrivent **vos canaux de sortie physiques**. Ils sont générés à partir du mappage que vous venez de confirmer au ressenti.

## 2. Importer le profil d'effets MCP4SH

Dans SimHub :

1. Ouvrez **ShakeIt Bass Shakers**.
2. Ouvrez **Effects Profile**.
3. Ouvrez **Profiles Manager**.
4. Choisissez **Import profile**.
5. Sélectionnez le `.siprofile` Standard MCP4SH fourni dans `Documents\SimHub\MCP4SH`.

Le `.siprofile` contient les formules d'effets MCP4SH, les fréquences, l'intention de routage et la configuration au niveau des effets. Ce n'est **pas** votre mappage physique des canaux.

## 3. Importer chaque fichier `.sichannels` généré

Toujours dans **ShakeIt Bass Shakers** :

1. Ouvrez **Sound Output**.
2. Ajoutez ou activez le même périphérique de sortie que celui mappé dans Setup Assistant.
3. Sélectionnez **Custom channel map**.
4. Choisissez **Import**.
5. Sélectionnez le fichier MCP4SH `.sichannels` généré correspondant à ce périphérique de sortie.
6. Répétez pour chaque périphérique de sortie mappé.

N'importez pas un fichier `.sichannels` dans le mauvais périphérique. Le nom du fichier est volontairement basé sur le périphérique de sortie mappé et les rôles des canaux.

## 4. Vérifier avant de rouler

Revenez dans **MCP4SH** dans SimHub et faites un clic droit sur les positions de shakers mappées dans la vue du rig.

Chaque impulsion de test doit atteindre le shaker physique attendu. Si ce n'est pas le cas, corrigez le mappage avant de régler les gains ou les effets.

Vous pouvez aussi utiliser **Analyser le profil** dans SimHub Helper pour comparer un fichier `.sichannels` au dernier mappage physique enregistré.

## Garder les deux types de profils séparés

- `.siprofile` = le **profil d'effets** MCP4SH. Tyto Sensory Labs peut fournir des versions mises à jour de ce fichier.
- `.sichannels` = **votre routage physique Sound Output généré**. Setup Assistant crée ces fichiers à partir du mappage de votre rig.

MCP4SH ne remplace ni n'active silencieusement vos profils SimHub.

## Rigs avec canaux partagés

Si deux shakers ou plus sont physiquement câblés sur le même canal d'amplificateur, SimHub ne peut pas les adresser indépendamment. Tout effet envoyé à ce canal sera ressenti sur chaque shaker qui y est connecté.

## Si quelque chose semble incorrect

- Utilisez **Ouvrir le dossier des profils** pour vérifier quels fichiers ont été générés.
- Utilisez **Analyser le profil** pour inspecter le routage `.sichannels` sélectionné.
- Ne refaites le mappage que si l'affectation physique périphérique/canal est incorrecte.
- Ne commencez pas à modifier les gains par effet pour compenser un mauvais mappage des canaux.
