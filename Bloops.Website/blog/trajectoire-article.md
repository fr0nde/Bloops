---
title: 'Les déplacements du personnage'
image: https://files.facepunch.com/s/57140e930812.jpg
date: '2019-12-24'
tags:
  - personnage
  - déplacement
  - dev
  - 2d
summary: "Le déplacement du personnage est la mécanique principale de tout jeux de plateforme. Elle permet de donner de la difficulté et de rendre le jeux attrayant."
---

### La réflexion

Notre objectif étant de rendre le jeu attrayant et compétitif. Ils nous fallaient choisir entre deux systèmes. L'un basique avec des déplacements gauche droite et la possibilité de sauter. L'autre avec un système de tiré-relaché comme un lance pierre. Le système de tiré-relaché permet d'utiliser plus facilement tout l'espace de l'écran. Il est aussi moins répandu dans les jeux 2D


### Le déplacement

L'idée principale est de mettre en avant le skill, c'est-à-dire les compétences des utilisateurs à s'approprier et à utiliser la technique de déplacement. L'ajout d'une ligne de trajectoire visible donne à l'utilisateur une perception de la puissance du lancer et de la trajectoire. Ce qui rend le système abouti et fonctionnel.

![Exemple en jeu](/assets/trajectoire.JPG)


### Le développement

Des recherches sur internet étaient nécessaires, pour les différents calculs mathématiques de trajectoire.

* Pour faire simple :
    * Récupérer la position de départ au contact du mobile/tablette => posDeb
    * Dessiner une droite partant de la position de départ jusqu'a la position à l'instant T du contact => posFin
    * Soustraire la position de début et de fin pour obtenir la distance => totalDistance

```csharp
// Calcule la position de départ
Vector3 posDeb = calculPos(character.position, reversedEndPos, characterSize / 2);
// Attribue le premier point du lineRenderer
lr.SetPosition(0, posDeb);

// Calcul la distance du linerenderer
float distTotal = Vector3.Distance(character.position, reversedEndPos);
// Bloque la distance a 3.5F
if (distTotal > 3.5F) distTotal = 3.5F;
// Génere le deuxième point du linerenderer à partir du taille minimal
if (distTotal > 0.8F)
{
    // Calcule une valeur entre 80 et 255 pour l'opacité du lineRenderer
    int colorOpacity = (int)(80 * distTotal);
    if (colorOpacity < 80)
    {
        colorOpacity = 80;
    } else if (colorOpacity > 255)
    {
        colorOpacity = 255;
    }
    // new Color32(231, 228, 227, (byte)colorOpacity)
    lr.material.color = new Color32(58, 154, 255, (byte)colorOpacity);
    // Calcule la position de fin 
    Vector3 posFin = calculPos(character.position, reversedEndPos, distTotal);
    lr.SetPosition(1, posFin);
    // Stock la distance total du drag
    totalDistance = posFin - posDeb;
} else
{
    lr.material.color = new Color32(231, 228, 227, 0);
    totalDistance = Vector3.zero;
}
```