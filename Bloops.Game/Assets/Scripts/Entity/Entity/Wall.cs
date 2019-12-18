using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private BoxCollider2D bc2d;
    private SpriteRenderer spriteR;

    public GameObject wallPrefab;
    public Sprite SplashSprite;
    // Start is called before the first frame update
    void Start()
    {
        bc2d = GetComponent<BoxCollider2D>();
        spriteR = gameObject.GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 hit = collision.contacts[0].point;
        Vector3 hit3 = hit;
        Vector3 colliderSize = collision.transform.localScale;
        AddSplashSprite(hit3, colliderSize);
    }

    void LoadTextureHit(Sprite sp)
    {
        // Faire le changement de skin du mur pour avoir celui qui contient les traces de peinture
        //Sprite sp = Resources.Load("path") as Sprite;

        spriteR.sprite = sp;
    }


    void AddSplashSprite(Vector3 hitPos, Vector3 colliderScale)
    {
        GameObject go = new GameObject();
        go.transform.position = hitPos;
        SpriteRenderer sr = go.AddComponent<SpriteRenderer>();
        sr.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
        sr.sortingLayerName = "mark";
        sr.sprite = SplashSprite;
        sr.flipX = (UnityEngine.Random.value < 0.5);
        sr.flipY = (UnityEngine.Random.value < 0.5);
        sr.transform.localScale = colliderScale  + new Vector3(1.0F, 1.0F, 1.0F) * 0.2F; ;//wallPrefab.transform.localScale;
        go.transform.parent = wallPrefab.transform;
    }

}
