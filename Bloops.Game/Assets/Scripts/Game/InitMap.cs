using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class InitMap : MonoBehaviour
{
    // Variable a changer pour modifier le sprite du mur
    private Sprite textureSprite, backgroundSprite;

    public GameObject prefab_wall;
    public GameObject prefab_trap;
    public GameObject prefab_character;
    public GameObject background;
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

    public string levelName = "niveau_6";
    private Map map;


    void Start()
    {
        // Instantiate the map
        if (GameSceneInfo.level > 0)
        {
            levelName = $"niveau_{GameSceneInfo.level}";
        }
        map = Utils.LoadJsonMap(levelName);

        // On initialise les statistiques
        GameInstanceInfo.init();

        // Récupère la bonne texture de bloc pour le monde
        textureSprite = Resources.Load<Sprite>($"Wall/mur-m{map.world}");
        backgroundSprite = Resources.Load<Sprite>($"Screen/background-{map.world}");

        // Instantiate the background
        SpriteRenderer backgroundRenderer = background.GetComponent<SpriteRenderer>();
        backgroundRenderer.sprite = backgroundSprite;

        InstantiateWall(map);
        InstantiateCharacter(map);
        InstantiatePortal(map);
    }

    private void InstantiateCharacter(Map pMap)
    {
        int xPos = pMap.character.pos_x;
        int yPos = pMap.character.pos_y;
        GameObject character = Instantiate(prefab_character, new Vector3(xPos, yPos), Quaternion.identity);
        character.transform.parent = this.transform;
        InstanceReferences.Add(character);
        GameInstanceInfo.positionDepart = new Vector2(xPos, yPos);
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

            if (bloc.type == "MUR")
            {
                gameObjectPositions.Add(new GameObjectPosition(xPos, yPos));
                GameObject newWall = Instantiate(prefab_wall, new Vector3(xPos, yPos), Quaternion.identity);

                Wall wall = newWall.GetComponent<Wall>();
                wall.ChangeTexture(textureSprite);
            }
            if (bloc.type == "PIEGE")
            {
                gameObjectPositions.Add(new GameObjectPosition(xPos, yPos));
                GameObject newSpike = Instantiate(prefab_trap, new Vector3(xPos, yPos), Quaternion.identity);
                newSpike.transform.Rotate(0, 0, bloc.rotation);
            }
        }
    }
}
