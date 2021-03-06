﻿using Bloops.Shared.Entities;
using Bloops.Shared.Repository;
using System;
using System.Collections.Generic;
using System.Text;
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

    private Map map;


    void Start()
    {

        LevelContainer.Initialize();
        WorldContainer.Initialize();

        if (GameSceneInfo.level == 0)
        {
            GameSceneInfo.level = Convert.ToInt32("1");
        }

        Level level = LevelContainer.GetLevelById(GameSceneInfo.level);

        World world = WorldContainer.GetWorldById(level.WorldId);

        string levelName = $"niveau_{GameSceneInfo.level}";
        
        map = Utils.LoadJsonMap(levelName);
        
        initMapInfo();

        loadSkin(skins[skinIndex]);
    }
    
    private void initMapInfo()
    {
        // Initialise le titre du niveau
        titleText.text = map.name;
        // Initialise la description du niveau
        List<string> instructions = map.rules;
        infoText.text = string.Join("\n", instructions);
    }
    private void loadSkin(Character character)
    {
        Debug.Log(character);
        skinTitleText.text = "Choix du personnage: " + character.Name;
        Texture2D skinTexture = Resources.Load<Texture2D>(character.Path);
        skinImage.texture = skinTexture;
    }

    public void previousSkin()
    {
        skinIndex -= 1;
        if (skinIndex == -1)
        {
            skinIndex = skins.Count - 1;
        }
        loadSkin(skins[skinIndex]);

    }

    public void nextSkin()
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
        LoadSceneInfo.startScene = "GameInstanceInfo";
        LoadSceneInfo.nextScene = "InstanceGameV2";
        LoadSceneInfo.timer = "2";
        LoadSceneInfo.infoText = "Ceci est un texte d'information qui sera à l'avenir surement aléatoire";
        SceneManager.LoadScene("LoadScene");
    }
}
