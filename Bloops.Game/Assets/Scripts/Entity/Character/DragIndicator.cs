using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragIndicator : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 endPos;
    private Camera cam;
    private Rigidbody2D character;
    public GameObject playerScript;
    private PlayerCharacter PlayerCharacter;
    private float characterSize;
    private Vector3 totalDistance;
    private LineRenderer lr;
    private Vector3 camOffset = new Vector3(0, 0, 10);
    [SerializeField] private AnimationCurve ac;

    // Start is called before the first frame update
    void Start()
    {
        // Get PlayerScript
        PlayerCharacter = playerScript.GetComponent<PlayerCharacter>();
        // Get character
        character = GetComponent<Rigidbody2D>();
        // Get charachter radius
        characterSize = GetComponent<CircleCollider2D>().radius;
        // Get camera
        cam = Camera.main;
        // Pour enlever le warning d'init de la variable...
        if (ac == null) ac = new AnimationCurve();
        // Init un go lineRenderer
        lr = gameObject.AddComponent<LineRenderer>();
        // Indique au go qu'il a deux points d'ancrage
        lr.positionCount = 2;
        // Utilise l'espace du téléphone
        lr.useWorldSpace = true;
        // set le layer du linerenderer
        lr.sortingLayerName = "Player";
        // Ajoute l'animationCurve pour un effet de triangle
        lr.widthCurve = ac;
        // Ajoute des bords arrondis
        lr.numCapVertices = 5;
        //taille
        lr.widthMultiplier = 0.8f;
        // Ajoute le material de base
        lr.material = new Material(Shader.Find("Sprites/Default"));
        // Ajoute une couleur 
        lr.material.color = new Color32(231, 228, 227, 80);
        // Ne montre pas le lineRenderer a son instantiation
        lr.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Si le personnage ne bouge pas
        if (character.velocity.magnitude == 0)
        {
            // Quand on appuie sur l'écran
            if (Input.GetMouseButtonDown(0))
            {
                // Active le lineRenderer
                lr.enabled = true;
                // Récupère la position du doigt lors du premier touché de l'écran
                startPos = cam.ScreenToWorldPoint(Input.mousePosition) + camOffset;

                // Set le premier point d'ancrage à la position du personnage
                lr.SetPosition(0, character.position);
                // Utilise les coordonées x y similaires selon l'écran
                
            }
            // Quand on a toujours le doigt sur l'écran
            if (Input.GetMouseButton(0))
            {
                // Corrige le problème de drag invisible
                // Si le joueur laisse son doigt alors que le personange bouge
                lr.enabled = true;
                // Récupère la position du doigt à l'instant présent
                endPos = cam.ScreenToWorldPoint(Input.mousePosition) + camOffset;

                // Récupère la position inversé
                Vector3 reversePos = endPos - startPos;
                // Ajoute laposition inversé a la position du personnage
                Vector3 reversedEndPos = (Vector3)character.position + reversePos;

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
                
            }
            // Quand on relache le doigt de l'écran
            if (Input.GetMouseButtonUp(0))
            {
                if (totalDistance != Vector3.zero)
                {
                    // Fonction LaunchPlayer dans le script PlayerCharacter
                    PlayerCharacter.LaunchPlayer(totalDistance);
                }
                // Désactive le linerenderer
                lr.enabled = false;
            }
        }
        
    }
    Vector3 calculPos(Vector3 deb, Vector3 fin, float distance)
    {
        // Calcul la direction du linerenderer
        Vector2 direction = fin - deb;
        // Calcul l'angle du linerenderer
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (angle < 0f) angle += 360f;

        // Calcul la position du point selon l'angle et la direction
        // cf : https://answers.unity.com/questions/759542/get-coordinate-with-angle-and-distance.html
        float x = Convert.ToSingle(Math.Cos(angle * Mathf.Deg2Rad));
        float y = Convert.ToSingle(Math.Sin(angle * Mathf.Deg2Rad));
        Vector3 newPosition = new Vector3(x, y, 0) * distance + deb;
        return newPosition;
    }
}
