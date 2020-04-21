using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class InitMap : MonoBehaviour
{
    /*  
    * Attribut fixe qui ne doivent pas bouger         
    */

    /*
    * Modif flo du 15/40/2020
    * -9 < x > +8   -----> 18 possibilitées / attendus 17
    * -5 < y > +5   -----> 11 possibilitées / attendus 9   
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
    private Camera cam;

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
    private Map map;


    void Start()
    {
        cam = Camera.main;

        // instantiate the bordure
        map = Utils.LoadJsonMap("bordure.txt");
        InstantiateWall(map);

        // Instantiate the map
        levelName = $"niveau_{GameSceneInfo.level}.txt";
        map = Utils.LoadJsonMap(levelName);
        InstantiateWall(map);
        InstantiateCharacter(map);
        InstantiatePortal(map);
    }

    private void InstantiateCharacter(Map pMap)
    {
        int xPos = pMap.character.pos_x;
        int yPos = pMap.character.pos_y;

        GameObject character = Instantiate(prefab_character, new Vector3(xPos, yPos), Quaternion.identity);
        InstanceReferences.Add(character);
    }

    private void InstantiatePortal(Map pMap)
    {
        int xPos = pMap.portal.pos_x;
        int yPos = pMap.portal.pos_y;

        Instantiate(prefab_finisher, new Vector3(xPos, yPos), Quaternion.identity);
    }


    private void InstantiateWall(Map pMap)
    {
        foreach (Bloc bloc in pMap.blocs)
        {
            int xPos = bloc.pos_x;
            int yPos = bloc.pos_y;

            if (bloc.type == Type.MUR)
            {
                gameObjectPositions.Add(new GameObjectPosition(xPos, yPos));

                Instantiate(prefab_wall, new Vector3(xPos, yPos), Quaternion.identity);
            }
        }
    }
}
