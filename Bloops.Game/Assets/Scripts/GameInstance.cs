using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInstance : MonoBehaviour
{
    public BoxCollider2D wallPrefab;
    public Rigidbody2D characterPrefab;
    public SpriteRenderer backgroundPrefab;

    //void Awake()
    //{
    //    // Get the character
    //    playerGo = GameObject.Find("Character");
    //    Debug.Log(playerGo);
    //    //playerCharacter = playerGo.GetComponent<PlayerCharacter>();

    //    // Get wall GameObject
    //    wallGo = GameObject.Find("Wall");
    //    wall = wallGo.GetComponent<Wall>();

    //}

    public void Launch()
    {
        //instantiate the background
        SpriteRenderer backgroundInstance;
        backgroundInstance = Instantiate(backgroundPrefab) as SpriteRenderer;

        //instantiate the character
        Rigidbody2D characterInstance;
        characterInstance = Instantiate(characterPrefab) as Rigidbody2D;

        // instantiate btw 1 and 4 walls 
        int nbWall = Random.Range(2, 5);
        List<BoxCollider2D> wallList = new List<BoxCollider2D>();
        BoxCollider2D wallInstance;
        for (int i = 1; i <= nbWall; i++)
        {
            wallInstance = addWall(Random.Range(-4.0f, 10.0f), Random.Range(-4.0f, 10.0f));
            wallList.Add(wallInstance);
        }
        GameObject btnLaunch = GameObject.Find("BtnLaunch");
        btnLaunch.SetActive(false);
    }

    public void Reset()
    {
        SceneManager.LoadScene(0);
    }

    private BoxCollider2D addWall(float x, float y)
    {
        BoxCollider2D wallInstance;
        Vector2 newPosition = new Vector2(x, y);
        Quaternion newRotation = new Quaternion(0, 0, 0, 1);

        wallInstance = Instantiate(wallPrefab, newPosition, newRotation) as BoxCollider2D;
        return wallInstance;
    }
}
