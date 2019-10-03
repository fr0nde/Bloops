using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class BinarySerializationService
{
    #region Public static methods

    public static string ToJson<T>(T obj)
    {
        return JsonUtility.ToJson(obj);
    }

    public static T FromJson<T>(string json)
    {
        return JsonUtility.FromJson<T>(json);
    }
    public static void ToBinaryFile<T>(string filename, T obj)
    {
        string filePath = GetFilePath(filename);
        using (FileStream file = File.Open(filePath, FileMode.OpenOrCreate))
        {
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(file, obj);
        }
    }

    public static T? FromBinaryFile<T>(string filename) where T : struct
    {
        string filePath = GetFilePath(filename);
        if (!File.Exists(filePath))
        {
            return null;
        }

        using (FileStream file = File.Open(filePath, FileMode.Open))
        {
            BinaryFormatter bf = new BinaryFormatter();
            return (T)bf.Deserialize(file);
        }
    }

    #endregion

    #region Private static methods

    private static string GetFilePath(string filename)
    {
        return $"{ApplicationService.DataPath}/{filename}.dat";
    }

    #endregion
}
