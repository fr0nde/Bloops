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
    public string fileName;

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
        readFile($"{fileName}.txt");
    }

    void cleanCustomGeneration()
    {
        foreach (GameObject InstanceReference in InstanceReferences)
        {
            Destroy(InstanceReference, 1.0f);
        }
        InstanceReferences = new List<GameObject>() { };
    }

    void generateCustomGeneration(List<GameObjectPosition> selectedPositions)
    {
        foreach (GameObjectPosition selectedPosition in selectedPositions)
        {
            int xCalculated = selectedPosition.x;
            int yCalculated = selectedPosition.y;

            //Debug.Log($"xC: {xCalculated}, yC: {yCalculated}");
            InstanceReferences.Add(Instantiate(prefab, new Vector3(xStart + (x * xCalculated), yStart + (y * -yCalculated)), Quaternion.identity));
        }
    }

    private void readFile(string file)
    {
        IEnumerable<string> lines = System.IO.File.ReadLines($@"Assets\Resources\Map\{file}");
        foreach (string line in lines)
        {
            string[] Pos = line.Split(';');
            int xPos = System.Convert.ToInt32(Pos[0]);
            int yPos = System.Convert.ToInt32(Pos[1]);
            gameObjectPositions.Add(new GameObjectPosition(xPos, yPos));
            InstanceReferences.Add(Instantiate(prefab, new Vector3(xStart + (x * xPos), yStart + (y * -yPos)), Quaternion.identity));
        }
    }


    public void saveFile()
    {
        string text = "";
        foreach (GameObjectPosition pos in gameObjectPositions)
        {
            text += $"{pos.x};{pos.y}\n";
        }
        System.IO.File.WriteAllText($@"Assets\Resources\Map\{fileText.text}.txt", text);
    }

    // Update is called once per frame
    void Update()
    {
        cleanCustomGeneration();
        generateCustomGeneration(gameObjectPositions);
    }
}
