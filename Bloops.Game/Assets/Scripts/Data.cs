using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class PlayerManager
{
    public static Player player = null;
    public static Player getPlayer()
    {
        if (player == null)
        {
            player = SaveSystem.loadPlayer();
        }
        return player;
    }
    
}

[Serializable]
public class Player
{
    public string name;
    public List<LevelData> levels;

    public Player()
    {
        this.name = null;
        this.levels = new List<LevelData>();
    }

    public Player(string name, List<LevelData> levels)
    {
        this.name = name;
        this.levels = levels;
    }

    public void setName(string name)
    {
        this.name = name;
        SaveSystem.savePlayer(this);
    }

    public void addLevel(LevelData ld)
    {
        LevelData currentld = getLevel(ld.level);
        if (currentld != null)
        {
            currentld.timer = ld.timer;
            currentld.bounces = ld.bounces;
            currentld.stars = ld.stars;
        }
        else
        {
        this.levels.Add(ld);
        }
        SaveSystem.savePlayer(this);
    }

    public void setLevels(List<LevelData> levels)
    {
        this.levels = levels;
        SaveSystem.savePlayer(this);
    }

    public LevelData getLevel(string level)
    {
        return levels.Find(x => x.level == level);
    }

    public bool levelIsAvailable(string level)
    {
        if (level == "1") return true;
        
        int levelNumber = Int32.Parse(level);

        if (levelNumber > 1 && getLevel((levelNumber - 1).ToString()) != null)
        {
                return true;
        }
        return false;
    }

    public void unlockLevels()
    {
        List<LevelData> unlockLevels = new List<LevelData>(50);

        int i = 0;
        foreach (LevelData unlockLevel in unlockLevels)
        {
            i++;
            unlockLevel.level = i.ToString();
            unlockLevel.stars = 5;
        }

        this.levels = unlockLevels;
        SaveSystem.savePlayer(this);
    }

    public void resetLevels()
    {
        this.levels = new List<LevelData>();
        SaveSystem.savePlayer(this);
    }
}


[Serializable]
public class LevelData
{
    public string level;
    public float timer;
    public int bounces;
    public int stars;

    public LevelData()
    {
        this.level = null;
        this.timer = 0;
        this.bounces = 0;
        this.stars = 0;
    }
    public LevelData(string level, float timer, int bounces, int stars)
    {
        this.level = level;
        this.timer = timer;
        this.bounces = bounces;
        this.stars = stars;
    }
}


public static class SaveSystem
{
    static string playerPath = Application.persistentDataPath + "/player.db";

    public static void savePlayer(Player player)
    {
        Debug.Log("Running savePlayer");
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(SaveSystem.playerPath, FileMode.Create);

        formatter.Serialize(stream, player);
        stream.Close();

        PlayerManager.player = loadPlayer();
    }

    public static Player loadPlayer()
    {
        Debug.Log("Running loadPlayer");

        if (File.Exists(SaveSystem.playerPath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(SaveSystem.playerPath, FileMode.Open);

            Player player = formatter.Deserialize(stream) as Player;
            return player;
        }
        else
        {
            Debug.LogWarning("Save player not found");
            Player player = new Player();
            savePlayer(player);
            return loadPlayer();
        }
    }
}