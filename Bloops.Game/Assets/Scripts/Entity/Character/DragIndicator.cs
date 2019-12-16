using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragIndicator : MonoBehaviour
{
    Vector3 startPos;
    Vector3 endPos;
    private Camera cam;
    private Rigidbody2D rb2d;
    LineRenderer lr;

    Vector3 camOffset = new Vector3(0, 0, 10);

    [SerializeField] AnimationCurve ac;
    Color c1 = new Color(100, 10, 10, 10);
    Color c2 = new Color(11, 1, 1, 0);

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
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
            // Inidque au go qu'il a deux points d'ancrage
            lr.positionCount = 2;
            // Set le premier point d'ancrage à la position du personnage
            lr.SetPosition(0, rb2d.position);
            // Utilise les coordonées x y similaires selon l'écran
            lr.useWorldSpace = true;
            // set le layer du linerenderer
            lr.sortingLayerName = "Background";
            // Ajoute l'animationCurve pour un effet de triangle
            lr.widthCurve = ac;
            // Ajoute des bords arrondis
            lr.numCapVertices = 10;
            // Ajoute le material de base
            lr.material = new Material(Shader.Find("Sprites/Default"));
            // Ajoute une couleur au linerenderer
            lr.startColor = c1;
            lr.endColor = c2;
        }
        // Quand on a toujours le doigt sur l'écran
        if (Input.GetMouseButton(0))
        {
            // Récupère la position du doigt lors du premier touché de l'écran
            endPos = cam.ScreenToWorldPoint(Input.mousePosition) + camOffset;
            // Récupère la distance entre les deux position du doigt enregistrées
            Vector3 distance = endPos - startPos;
            // Récupère la pos du personnage
            Vector3 posPersonnage = rb2d.position;
            // Ajoute la distance à la postion du personnage
            Vector3 posFin = posPersonnage + distance;
            // Set le deuxième points d'ancrage du linerenderer pour le dessiner
            lr.SetPosition(1, posFin);
        }
        // Quand on relache le doigt de l'écran
        if (Input.GetMouseButtonUp(0))
        {
            //Désactive le linerenderer
            lr.enabled = false;
        }
    }
}
