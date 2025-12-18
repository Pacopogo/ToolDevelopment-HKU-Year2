using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor.Overlays;
using UnityEngine;
public class SaveManager : MonoBehaviour
{
    [SerializeField] private string path;   //To save path
    [SerializeField] private string filename;
    [SerializeField] private CircuitManager circuitManager;
    public SaveData data;
    [ContextMenu("Save")]
    public void Save()
    {
        SaveData saveData = new SaveData();
        saveData.m_RoadData = new List<RoadData>();
        var roads = circuitManager.Roads.Select(x => x.GetComponent<RoadDataComponent>());
        foreach (var road in roads) {
            RoadData data = new RoadData()
            {
                m_Position = road.m_Position,
                m_Roadtype = road.m_Roadtype,
                name = road.name
            };
            saveData.m_RoadData.Add(data);
        }

        if (Application.isEditor)
        {
            path = Application.dataPath + "/" + filename + ".json";
        }
        else
        {
            path = Application.persistentDataPath + "/" + filename + ".json";
        }

        FileStream fileStream = new FileStream(path, FileMode.Create);

        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            string json = JsonUtility.ToJson(saveData, true);
            writer.Write(json);
        }
    }
    
    [ContextMenu("Load")]
    public void Load()
    {
        if (Application.isEditor)
        {
            path = Application.dataPath + "/" + filename + ".json";
        }
        else
        {
            path = Application.persistentDataPath + "/" + filename + ".json";
        }

        FileStream fileStream = new FileStream(path, FileMode.Open);
        string json = "";
        using (StreamReader reader = new StreamReader(fileStream))
        {
            json = reader.ReadToEnd();
        }
        data = JsonUtility.FromJson<SaveData>(json);

    }

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

[System.Serializable]
public class SaveData
{
    public List<RoadData> m_RoadData = new();
}

[System.Serializable]
public class RoadData
{
    public string name = "yes its a bit of text";
    public Vector3 m_Position;
    public RoadDirection m_Roadtype;
}