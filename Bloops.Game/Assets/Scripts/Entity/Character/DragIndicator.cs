using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragIndicator : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 endPos;
    private Camera cam;
    private Rigidbody2D character;
    private Vector3 characterSize;
    public LineRenderer lr;
    public Material mat;
    private Vector3 posCharacterWithoutSize = Vector3.zero;

    Vector3 camOffset = new Vector3(0, 0, 10);

    [SerializeField] AnimationCurve ac;
    Color c1 = new Color(27, 174, 243, 1);
    Color c2 = new Color(27, 174, 243, 0.25f);

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<Rigidbody2D>();
        characterSize = GetComponent<CircleCollider2D>().bounds.size;
        cam = Camera.main;
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
                // Pour enlever le warning d'init de la variable...
                if (ac == null) ac = new AnimationCurve();
                // Récupère la position du doigt lors du premier touché de l'écran
                startPos = cam.ScreenToWorldPoint(Input.mousePosition) + camOffset;
                // Init un go lineRenderer si il n'y en a pas
                if (lr == null) lr = gameObject.AddComponent<LineRenderer>();
                // Active le lineRenderer
                lr.enabled = true;
                // Indique au go qu'il a deux points d'ancrage
                lr.positionCount = 2;
                // position du personnage + sa taille
                if (startPos.x < character.position.x)
                {
                    posCharacterWithoutSize.x = character.position.x - characterSize.x;
                } else
                {
                    posCharacterWithoutSize.x = character.position.x + characterSize.x;
                }
                if (startPos.y < character.position.y)
                {
                    posCharacterWithoutSize.y = character.position.y - characterSize.y;
                }
                else
                {
                    posCharacterWithoutSize.y = character.position.y + characterSize.y;
                }
                // Set le premier point d'ancrage à la position du personnage
                lr.SetPosition(0, posCharacterWithoutSize);

                // Utilise les coordonées x y similaires selon l'écran
                lr.useWorldSpace = true;
                // set le layer du linerenderer
                lr.sortingLayerName = "Background";
                // Ajoute l'animationCurve pour un effet de triangle
                lr.widthCurve = ac;
                // Ajoute des bords arrondis
                lr.numCapVertices = 5;
                //taille
                lr.widthMultiplier = 0.8f;
                // Ajoute le material de base
                lr.material = new Material(Shader.Find("Sprites/Default"));
                lr.material.color = new Color32(231, 228, 227, 80);
            }
            // Quand on a toujours le doigt sur l'écran
            if (Input.GetMouseButton(0))
            {
                // Récupère la position du doigt lors du premier touché de l'écran
                endPos = cam.ScreenToWorldPoint(Input.mousePosition) + camOffset;
                // Récupère la distance entre les deux position du doigt enregistrées
                Vector3 distance = endPos - startPos;
                if (distance == Vector3.zero)
                {
                    lr.SetPosition(1, posCharacterWithoutSize);
                } else
                {
                    // Récupère la pos du personnage
                    Vector3 posPersonnage = character.position;
                    // Ajoute la distance à la postion du personnage
                    // Maximum de distance de 2.5f
                    if (distance.x > 2.5f)
                    {
                        distance.x = 2.5f;
                    }
                    else if (distance.x < -2.5f)
                    {
                        distance.x = -2.5f;
                    }
                    if (distance.y > 2.5f)
                    {
                        distance.y = 2.5f;
                    }
                    else if (distance.y < -2.5f)
                    {
                        distance.y = -2.5f;
                    }

                    if (endPos.x < character.position.x)
                    {
                        posCharacterWithoutSize.x = posPersonnage.x - characterSize.x;
                    }
                    else
                    {
                        posCharacterWithoutSize.x = posPersonnage.x + characterSize.x;
                    }
                    if (endPos.y < character.position.y)
                    {
                        posCharacterWithoutSize.y = posPersonnage.y - characterSize.y;
                    }
                    else
                    {
                        posCharacterWithoutSize.y = posPersonnage.y + characterSize.y;
                    }

                    Vector3 posFin = posCharacterWithoutSize + distance;
                    // Set le deuxième points d'ancrage du linerenderer pour le dessiner
                    lr.SetPosition(1, posFin);
                }
            }
        }
        // Quand on relache le doigt de l'écran
        if (Input.GetMouseButtonUp(0))
        {
            //Désactive le linerenderer
            lr.enabled = false;
        }
    }
}
