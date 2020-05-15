using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using System.IO;

public class GenerateWall : MonoBehaviour
{
    public int columnLength, rowLength;
    public float xStart, yStart;
    public float x, y;
    public GameObject prefab;
    public Camera cam;
    public Text fileText;
    public string fileName = "bordure";
    private Map map;


    public List<GameObjectPosition> gameObjectPositions = new List<GameObjectPosition>() { };

    [System.Serializable]
    public class GameObjectPosition
    {
        public int x;
        public int y;

        public GameObjectPosition(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    private List<GameObject> InstanceReferences = new List<GameObject>() { };

    void Start()
    {
        map = Utils.LoadJsonMap(fileName);
        LoadMap();
    }

    public void saveMap()
    {
        map = new Map();
        foreach (GameObjectPosition pos in gameObjectPositions)
        {
            map.blocs.Add(new Bloc("MUR", pos.x, pos.y, 0));
        }
        Utils.SaveJsonMap(fileText.text, map);
    }

    private void LoadMap()
    {
        foreach (Bloc bloc in map.blocs)
        {
            int xPos = bloc.pos_x;
            int yPos = bloc.pos_y;

            gameObjectPositions.Add(new GameObjectPosition(xPos, yPos));
        }
    }

    void cleanCustomGeneration()
    {
        foreach (GameObject InstanceReference in InstanceReferences)
        {
            Destroy(InstanceReference, 1.0f);
        }
        InstanceReferences = new List<GameObject>() { };
    }

    void fillCustomGeneration()
    {
        foreach (GameObjectPosition pos in gameObjectPositions)
        {
            int xPos = pos.x;
            int yPos = pos.y;
            
            InstanceReferences.Add(Instantiate(prefab, new Vector3(xStart + (x * xPos), yStart + (y * -yPos)), Quaternion.identity));
        }
    }

 

    // Update is called once per frame
    void Update()
    {
        cleanCustomGeneration();
        fillCustomGeneration();
    }
}
