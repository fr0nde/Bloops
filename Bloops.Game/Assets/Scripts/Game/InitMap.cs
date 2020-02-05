using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitMap : MonoBehaviour
{
/*  
 * Attribut fixe qui ne doivent pas bouger         
 */
    private int columnLength = 17;
    private int rowLength = 9;
    private float xStart = -8.5f;
    private float yStart = 3.5f;
    private float x = 1f;
    private float y = 1f;

    public GameObject prefab_wall;
    public GameObject prefab_character;
    public BoxCollider2D prefab_finisher;


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
    private List<GameObjectPosition> gameObjectPositions = new List<GameObjectPosition>() { };
    /*
     * valeur à set avant le lancement de la scène
     */

    public string levelName = "template.txt";


    void Start()
    {
        levelName = $"niveau_{GameSceneInfo.level}.txt";
        readFile(levelName);
    }

    private void readFile(string file)
    {
        IEnumerable<string> lines = System.IO.File.ReadLines($@"Assets\Resources\Map\{file}");
        foreach (string line in lines)
        {
            string[] Pos = line.Split(';');
            int xPos = System.Convert.ToInt32(Pos[0]);
            int yPos = System.Convert.ToInt32(Pos[1]);
            string prefab_type = Pos[2];

            gameObjectPositions.Add(new GameObjectPosition(xPos, yPos));
            if (prefab_type == "character")
            {
                GameObject character = Instantiate(prefab_character, new Vector3(xStart + (x * xPos), yStart + (y * -yPos)), Quaternion.identity);
                character.transform.localScale += new Vector3(-0.2f, -0.2f, -0.01f);
                InstanceReferences.Add(character);
            }
            else if (prefab_type == "finisher")
            {
                Instantiate(prefab_finisher, new Vector3(xStart + (x * xPos), yStart + (y * -yPos)), Quaternion.identity);
            }
            else if (prefab_type == "wall")
            {
                InstanceReferences.Add(Instantiate(prefab_wall, new Vector3(xStart + (x * xPos), yStart + (y * -yPos)), Quaternion.identity));
            }
        }
    }
}
