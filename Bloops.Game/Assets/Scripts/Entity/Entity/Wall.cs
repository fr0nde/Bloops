using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private BoxCollider2D bc2d;
    private SpriteRenderer spriteRenderer;
    private SpriteMask spriteMask;
    public GameObject wallPrefab;
    public Sprite SplashSprite;
    // Start is called before the first frame update
    void Awake()
    {
        bc2d = GetComponent<BoxCollider2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteMask = gameObject.GetComponent<SpriteMask>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 hit = collision.contacts[0].point;
        Vector3 hit3 = hit;
        Vector3 colliderSize = collision.transform.localScale;
        AddSplashSprite(hit3, colliderSize);
    }

    public void ChangeTexture(Sprite texture)
    {
        // Affecte la texture au wall
        spriteRenderer.sprite = texture;
        spriteMask.sprite = texture;
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
