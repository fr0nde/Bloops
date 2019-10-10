using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public float speed;             //Floating point variable to store the player's movement speed.
    private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.
    private Vector2 posFin;
    private Vector2 posDeb;
    private Camera cam;
    private Animator anim;

    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        cam = Camera.main;
    }

    void Update()
    {
        //if (Input.touchCount > 0)
        //{
        //    Touch touch = Input.GetTouch(0);
        //    if (touch.phase == TouchPhase.Began)
        //    {
        //        Vector3 toto = new Vector3(touch.position.x, touch.position.y, 0);
        //        Debug.Log(cam.ScreenToWorldPoint(toto));
        //        rb2d.position = cam.ScreenToWorldPoint(toto);

        //    }

        //}

        // Handle screen touches.
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            bool launch = false;

            if (touch.phase == TouchPhase.Began)
            {
                Vector3 positionRelative = new Vector3(touch.position.x, touch.position.y, 0);
                posDeb = cam.ScreenToWorldPoint(positionRelative);
                anim.Play("launch_right", 0, 0);
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
                anim.Play("idle", 0, 0);
            }

            if (!launch)
            {
                Vector3 positionRelative = new Vector3(touch.position.x, touch.position.y, 0);
                rb2d.position = cam.ScreenToWorldPoint(positionRelative);
            }
        }
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    //void FixedUpdate()
    //{
    //    //Store the current horizontal input in the float moveHorizontal.
    //    float moveHorizontal = Input.GetAxis("Horizontal");

    //    //Store the current vertical input in the float moveVertical.
    //    float moveVertical = Input.GetAxis("Vertical");

    //    //Use the two store floats to create a new Vector2 variable movement.
    //    Vector2 movement = new Vector2(moveHorizontal, moveVertical);

    //    //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
    //    rb2d.AddForce(movement * speed);
    //}
}
