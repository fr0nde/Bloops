using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCharacter : GameInstance
{
    public float speed;             //Floating point variable to store the player's movement speed.
    private Rigidbody2D character;       //Store a reference to the Rigidbody2D component required to use 2D Physics.

    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        character = GetComponent<Rigidbody2D>();
    }

    public void LaunchPlayer(Vector3 dragDistance)
    {
        // Reset the force
        character.velocity = new Vector2(0f, 0f);

        character.AddForce(-dragDistance * speed, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        character.velocity = Vector2.zero;

        if (collision.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene("InstanceGame");
        }
        if (collision.gameObject.tag == "BlocKill")
        {
            print($"Le personnage est mort il à touché le bloc qui tue");
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
            
    }
}
