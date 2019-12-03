using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private BoxCollider2D bc2d;
    private SpriteRenderer spriteR;
    public Sprite TopSpriteCollide;
    public Sprite BotSpriteCollide;
    public Sprite LeftSpriteCollide;
    public Sprite RightSpriteCollide;
    // Start is called before the first frame update
    void Start()
    {
        bc2d = GetComponent<BoxCollider2D>();
        spriteR = gameObject.GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 hit = collision.contacts[0].normal;
        Vector3 hit3 = hit;

        if (hit3 == -gameObject.transform.up)
        {
            // If the ball hits the top of the brick
            Debug.Log("Hit TOP");
            LoadTextureHit(TopSpriteCollide);
        }
        else if (hit3 == gameObject.transform.up)
        {
            // If the ball hits the bottom of the brick
            Debug.Log("Hit BOT");
            LoadTextureHit(BotSpriteCollide);

        }
        else if (hit3 == gameObject.transform.right)
        {
            // If the ball hits the left of the brick
            Debug.Log("Hit LEFT");
            LoadTextureHit(LeftSpriteCollide);

        }
        else if (hit3 == -gameObject.transform.right)
        {
            // If the ball hits the right of the brick
            Debug.Log("Hit RIGHT");
            LoadTextureHit(RightSpriteCollide);

        }
    }

    void LoadTextureHit(Sprite sp)
    {
        // Faire le changement de skin du mur pour avoir celui qui contient les traces de peinture
        //Sprite sp = Resources.Load("path") as Sprite;

        spriteR.sprite = sp;
    }

}
