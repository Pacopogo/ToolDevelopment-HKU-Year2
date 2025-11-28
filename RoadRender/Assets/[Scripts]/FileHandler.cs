using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// This script is to read and write files
/// 
/// I followed this script along form a youtube tutorial
/// https://www.youtube.com/watch?v=KZft1p8t2lQ
/// </summary>
public static class FileHandler
{
    public static void Save<T>(List<T> SaveData, string filename)
    {
        Debug.Log(GetPath(filename));
        string jsonData = JsonHelper.ToJson<T>(SaveData.ToArray());
        WriteSave(GetPath(filename), jsonData);
    }

    public static void Load() 
    {

    }

    private static string GetPath(string filename)
    {
        return Application.persistentDataPath + "/" + filename; 
    }

    private static void WriteSave(string filePath, string JsonText)
    {
        FileStream fileStream = new FileStream(filePath, FileMode.Create);

        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(JsonText);
        }
    }
}

// Source - https://stackoverflow.com/a
// Posted by Programmer, modified by community. See post 'Timeline' for change history
// Retrieved 2025-11-28, License - CC BY-SA 4.0
public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}
