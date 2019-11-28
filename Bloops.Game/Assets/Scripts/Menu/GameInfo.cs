using Bloops.Shared.Entities;
using Bloops.Shared.Repository;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Character
{
    public string Name { get; set; }
    public string Path { get; set; }

    public Character(string name, string path)
    {
        Name = name;
        Path = path;
    }
}

public class LevelInstance
{
    public string MapName { get; set; }
    public int MapLevel { get; set; }
    public List<string> Instructions { get; set; }

    public LevelInstance(string mapName, int mapLevel, List<string> instructions)
    {
        MapName = mapName;
        MapLevel = mapLevel;
        Instructions = instructions;
    }
}
public class GameInfo : MonoBehaviour
{
    public Text infoText = null;
    public Text titleText = null;
    public Text skinTitleText = null;
    private List<Character> skins = new List<Character>()
        {
            new Character("Bloops", "Personnage/personnage-1"),
            new Character("Poued", "Personnage/personnage-2"),
            new Character("Bireps", "Personnage/personnage-3")
        };
    public RawImage skinImage = null;
    private int skinIndex = 0;
    private uint gameLevel;

    void Start()
    {
        LevelContainer.Initialize();
        WorldContainer.Initialize();

        Level level = LevelContainer.GetLevelById(GameSceneInfo.level);
        World world = WorldContainer.GetWorldById(level.WorldId);

        //List<string> instruction = new List<string>() { "Gravité activé", "Moins de 3 rebonds", "Moins de 10 secondes" };
        //LevelInstance levelInstance = new LevelInstance("Fôret Magique", GameSceneInfo.level, instruction);

        initMapInfo(level, world);
        loadSkin(skins[0]);
    }

    private void initMapInfo(Level level, World world)
    {
        // Initialise le titre du niveau
        titleText.text = $"{world.Title} - {level.Id}";
        // Initialise la description du niveau
        List<string> instructions = new List<string>() { "toto", "todod" };
        infoText.text = string.Join("\n", instructions);
    }
    private void loadSkin(Character character)
    {
        skinTitleText.text = "Choix du personnage: " + character.Name;
        Texture2D skinTexture = Resources.Load<Texture2D>(character.Path);
        skinImage.texture = skinTexture;
    }

    private void previousSkin()
    {
        skinIndex -= 1;
        if (skinIndex == -1)
        {
            skinIndex = skins.Count - 1;
        }
        loadSkin(skins[skinIndex]);

    }

    private void nextSkin()
    {
        skinIndex += 1;
        if (skinIndex == skins.Count)
        {
            skinIndex = 0;
        }
        loadSkin(skins[skinIndex]);

    }

    public void loadPreviousScene()
    {
        SceneManager.LoadScene("AventureMenu");
    }


    public void loadGameInstance()
    {
        SceneManager.LoadScene("InstanceGame");
    }
}
