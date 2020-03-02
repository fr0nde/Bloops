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

Notre objectif étant de rendre le jeu attrayant et compétitif. Ils nous fallaient choisir entre deux systèmes. L'un basique avec des déplacements gauche droite et la possibilité de sauter. L'autre avec un système de tiré-relaché comme un lance pierre. Le système de tiré-relaché permet d'utiliser plus facilement tout l'espace de l'écran et est moins répandu dans les jeux 2D

### Le déplacement

Il nous fallait un système de déplacement qui met en avant le skill, c'est à dire les compétences des utilisateurs a s'approprier et a utiliser la technique de déplacement. L'ajout d'une ligne de trajectoire visible rend le système abouti et fonctionnel.

### Le développement



```js
export default {
  data() {
    return {
      msg: 'Highlighted!'
    }
  }
}
```
