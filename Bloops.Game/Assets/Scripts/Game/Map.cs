using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public enum Type { MUR, PERSONNAGE, PORTAIL }

[System.Serializable]
public class Bloc
{
    public Type type;
    public int pos_x;
    public int pos_y;

    public Bloc(Type type, int pos_x, int pos_y)
    {
        this.type = type;
        this.pos_x = pos_x;
        this.pos_y = pos_y;
    } 
}

[System.Serializable]
public class Map
{
    public string name;
    public List<string> rules;
    public List<Bloc> blocs;
    public Bloc character;
    public Bloc portal;

    public Map()
    {
        this.name = "";
        this.rules = new List<string>();
        this.blocs = new List<Bloc>();
    }
}

public class Utils
{
    public static Map LoadJsonMap(string fileName)
    {
        string text = System.IO.File.ReadAllText($@"Assets\Resources\Map\{fileName}");

        return JsonUtility.FromJson<Map>(text);
    }

    public static void SaveJsonMap(string fileName, Map map)
    {
        string text = JsonUtility.ToJson(map);

        System.IO.File.WriteAllText($@"Assets\Resources\Map\{fileName}", text);
    }
}
