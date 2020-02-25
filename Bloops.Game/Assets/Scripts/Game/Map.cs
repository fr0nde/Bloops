

using UnityEngine;

[System.Serializable]
public class Bloc
{
    public string type;
    public int pos_x;
    public int pos_y;
}

[System.Serializable]
public class Map
{
    public string name;
    public string[] rules;
    public Bloc[] blocs;
}

public class Utils
{
    public static Map LoadJsonMap(string fileName)
    {
        string text = System.IO.File.ReadAllText($@"Assets\Resources\Map\{fileName}");

        return JsonUtility.FromJson<Map>(text);
    }
}
