using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInstance : MonoBehaviour
{
    public BoxCollider2D wallPrefab;
    public Rigidbody2D characterPrefab;
    public BoxCollider2D doorPrefab;
    public CircleCollider2D wheelPrefab;
    public BoxCollider2D movingBloc;
    private Vector3 camOffset = new Vector3(0, 0, 10);

    public Camera cam;

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
        //launch timer and instantiate gameInstance data
        GameInstanceInfo.init();
        cam = Camera.main;

        //instantiate the background
        //SpriteRenderer backgroundInstance;
        //backgroundInstance = Instantiate(backgroundPrefab) as SpriteRenderer;

        //instantiate the character
        Rigidbody2D characterInstance;
        characterInstance = Instantiate(characterPrefab) as Rigidbody2D;
        GameInstanceInfo.positionDepart = characterInstance.position;

        // instantiate btw 1 and 4 walls 
        int nbWall = Random.Range(2, 5);
        List<BoxCollider2D> wallList = new List<BoxCollider2D>();
        BoxCollider2D wallInstance;
        //for (int i = 1; i <= nbWall; i++)
        //{
        //    wallInstance = AddWall(Random.Range(-4.0f, 10.0f), Random.Range(-4.0f, 10.0f));
        //    wallList.Add(wallInstance);
        //}

        wallInstance = Instantiate(wallPrefab, Vector3.zero, new Quaternion(0, 0, 0, 1));
        wallList.Add(wallInstance);
        wallInstance = Instantiate(wallPrefab, new Vector3(-5, -4), new Quaternion(0, 0, 0, 1));
        wallList.Add(wallInstance);
        wallInstance = Instantiate(wallPrefab, new Vector3(-5, -3), new Quaternion(0, 0, 0, 1));
        wallList.Add(wallInstance);
        wallInstance = Instantiate(wallPrefab, new Vector3(-5, -2), new Quaternion(0, 0, 0, 1));
        wallList.Add(wallInstance);
        wallInstance = Instantiate(wallPrefab, new Vector3(-5, -1), new Quaternion(0, 0, 0, 1));
        wallList.Add(wallInstance);

        Vector3 toto = new Vector3(cam.pixelWidth, cam.pixelHeight);
        print(cam.ScreenToWorldPoint(Vector3.zero));

        wallInstance = Instantiate(wallPrefab, cam.ScreenToWorldPoint(toto) + camOffset, new Quaternion(0, 0, 0, 1));
        wallList.Add(wallInstance);

        // instantiate btw 1 and 3 wheel 
        int nbWheel = Random.Range(2, 4);
        List<CircleCollider2D> wheelList = new List<CircleCollider2D>();
        CircleCollider2D wheelInstance;
        for (int i = 1; i <= nbWheel; i++)
        {
            wheelInstance = AddWheel(Random.Range(-9.0f, 9.0f), Random.Range(-5.0f, 5.0f));
            wheelList.Add(wheelInstance);
        }

        //instantiate a moving bloc
        BoxCollider2D movingBlocInstance;
        movingBlocInstance = Instantiate(movingBloc, new Vector2(Random.Range(-4.0f, 10.0f), Random.Range(-4.0f, 10.0f)), new Quaternion(0, 0, 0, 1)) as BoxCollider2D;

        //instantiate the door to end the level
        BoxCollider2D doorInstance;
        Vector2 doorRdmPos = new Vector3(Random.Range(-9.0f, 9.0f), Random.Range(-5.0f, 5.0f), 0);
        Quaternion newRotation = new Quaternion(0, 0, 0, 1);
        doorInstance = Instantiate(doorPrefab, doorRdmPos, newRotation) as BoxCollider2D;

        GameObject btnLaunch = GameObject.Find("BtnLaunch");
        btnLaunch.SetActive(false);
    }

    void Update()
    {
        if (GameInstanceInfo.launchTimer) GameInstanceInfo.timer += Time.deltaTime;
    }

    public void Reset()
    {
        GameInstanceInfo.launchTimer = false;
        Debug.Log("Temps du niveau : " + GameInstanceInfo.timer.ToString("F") + " secondes.");
        Debug.Log("nb try : " + GameInstanceInfo.nbTry);
        Debug.Log("nb rebond : " + GameInstanceInfo.nbBounce);
        SceneManager.LoadScene("InstanceGame");
    }

    public static void EndLevel()
    {
        GameInstanceInfo.launchTimer = false;
        Debug.Log("Temps du niveau : " + GameInstanceInfo.timer.ToString("F") + " secondes.");
        Debug.Log("nb try : " + GameInstanceInfo.nbTry);
        Debug.Log("nb rebond : " + GameInstanceInfo.nbBounce);
        SceneManager.LoadScene("EndLevel");
    }

    private BoxCollider2D AddWall(float x, float y)
    {
        BoxCollider2D wallInstance;
        Vector2 newPosition = new Vector2(x, y);
        Quaternion newRotation = new Quaternion(0, 0, 0, 1);

        wallInstance = Instantiate(wallPrefab, newPosition, newRotation) as BoxCollider2D;
        return wallInstance;
    }

    private CircleCollider2D AddWheel(float x, float y)
    {
        CircleCollider2D wheelInstance;
        Vector2 newPosition = new Vector2(x, y);
        Quaternion newRotation = new Quaternion(0, 0, 0, 1);

        wheelInstance = Instantiate(wheelPrefab, newPosition, newRotation) as CircleCollider2D;
        return wheelInstance;
    }

}
