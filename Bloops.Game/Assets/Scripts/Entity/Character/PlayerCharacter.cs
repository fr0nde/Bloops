using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCharacter : GameInstance
{
    public float speed;             //Floating point variable to store the player's movement speed.
    private Rigidbody2D character;       //Store a reference to the Rigidbody2D component required to use 2D Physics.
    private Vector2 posFin;
    private Vector2 posDeb;
    private Camera cam;

    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        character = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    void Update()
    {
        if (character.velocity.magnitude == 0)
        {
            // Handle screen touches.
            if (Input.GetMouseButtonDown(0))
            {
                posDeb = cam.ScreenToWorldPoint(Input.mousePosition);
            }
            if (Input.GetMouseButtonUp(0))
            {
                posFin = cam.ScreenToWorldPoint(Input.mousePosition);

                // Plus on rallonge le doigt sur l'axe horizontale, plus x augmente 
                float longueurX = posFin.x - posDeb.x;
                // Plus on rallonge le doigt sur l'axe verticale, plus y augmente 
                float longueurY = posFin.y - posDeb.y;

                // Reset the force
                character.velocity = new Vector2(0f, 0f);

                Vector2 movement = new Vector2(longueurX, longueurY);

                character.AddForce(new Vector2(-longueurX, -longueurY) * speed, ForceMode2D.Impulse);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        character.velocity = Vector2.zero;

        Debug.Log("Le personnage est entré dans un obstacle");
        if (collision.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene("InstanceGame");
        }
    }
}
