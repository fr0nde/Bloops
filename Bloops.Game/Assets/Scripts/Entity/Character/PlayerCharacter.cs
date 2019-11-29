using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCharacter : MonoBehaviour
{
    public float speed;             //Floating point variable to store the player's movement speed.
    private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.
    private Vector2 posFin;
    private Vector2 posDeb;
    private Camera cam;

    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    void Update()
    {
        // Handle screen touches.
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            bool launch = false;

            if (touch.phase == TouchPhase.Began)
            {
                Vector3 positionRelative = new Vector3(touch.position.x, touch.position.y, 0);
                posDeb = cam.ScreenToWorldPoint(positionRelative);
            }

            if (touch.phase == TouchPhase.Ended)
            {
                Vector3 positionRelative = new Vector3(touch.position.x, touch.position.y, 0);
                posFin = cam.ScreenToWorldPoint(positionRelative);

                // Plus on rallonge le doigt sur l'axe horizontale, plus x augmente 
                float longueurX = posFin.x - posDeb.x;
                // Plus on rallonge le doigt sur l'axe verticale, plus y augmente 
                float longueurY = posFin.y - posDeb.y;
                Debug.Log("pos x : " + -longueurX + " pos y : " + -longueurY);

                // Reset the force
                rb2d.velocity = new Vector2(0f, 0f);

                Vector2 movement = new Vector2(longueurX, longueurY);

                rb2d.AddForce(new Vector2(-longueurX, -longueurY) * speed, ForceMode2D.Impulse);
                launch = true;
            }

            if (!launch)
            { 
                //Vector2 positionRelative = new Vector2(touch.position.x, touch.position.y);
                //rb2d.position = cam.ScreenToWorldPoint(positionRelative);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        rb2d.velocity = Vector2.zero;

        Debug.Log("Le personnage est entré dans un obstacle");
        if (collision.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene(0);
        }
    }
}
