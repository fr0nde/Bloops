using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInstance : MonoBehaviour
{
    public BoxCollider2D wallPrefab;
    public Rigidbody2D characterPrefab;
    public SpriteRenderer backgroundPrefab;
    public BoxCollider2D doorPrefab;

    private float timer;
    private bool launchTimer = false;
    private int nbTry;

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
        //launch timer
        launchTimer = true;

        //instantiate the background
        //SpriteRenderer backgroundInstance;
        //backgroundInstance = Instantiate(backgroundPrefab) as SpriteRenderer;

        //instantiate the character
        Rigidbody2D characterInstance;
        characterInstance = Instantiate(characterPrefab) as Rigidbody2D;

        // instantiate btw 1 and 5 walls 
        int nbWall = Random.Range(2, 6);
        List<BoxCollider2D> wallList = new List<BoxCollider2D>();
        BoxCollider2D wallInstance;
        for (int i = 1; i <= nbWall; i++)
        {
            wallInstance = AddWall(Random.Range(-4.0f, 10.0f), Random.Range(-4.0f, 10.0f));
            wallList.Add(wallInstance);
        }

        //instantiate the door to end the level
        BoxCollider2D doorInstance;
        Vector2 doorRdmPos = new Vector2(Random.Range(-4.0f, 10.0f), Random.Range(-4.0f, 10.0f));
        Quaternion newRotation = new Quaternion(0, 0, 0, 1);
        doorInstance = Instantiate(doorPrefab, doorRdmPos, newRotation) as BoxCollider2D;

        GameObject btnLaunch = GameObject.Find("BtnLaunch");
        btnLaunch.SetActive(false);
    }

    void Update()
    {
        if (launchTimer) timer += Time.deltaTime;
    }

    public void Reset()
    {
        launchTimer = false;
        Debug.Log("Temps du niveau : " + timer.ToString("F") + " secondes.");
        SceneManager.LoadScene("InstanceGame");
    }

    private BoxCollider2D AddWall(float x, float y)
    {
        BoxCollider2D wallInstance;
        Vector2 newPosition = new Vector2(x, y);
        Quaternion newRotation = new Quaternion(0, 0, 0, 1);

        wallInstance = Instantiate(wallPrefab, newPosition, newRotation) as BoxCollider2D;
        return wallInstance;
    }

}
