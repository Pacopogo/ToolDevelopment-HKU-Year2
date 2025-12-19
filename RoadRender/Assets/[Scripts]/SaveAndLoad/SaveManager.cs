using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
public class SaveManager : MonoBehaviour
{
    [SerializeField] private string path;   //To save path
    [SerializeField] private string filename;
    [SerializeField] private CircuitManager circuitManager;
    public SaveData data;

    [SerializeField] private UnityEvent OnSave;
    [SerializeField] private UnityEvent OnLoad;

    [ContextMenu("Save")]
    public void Save()
    {
        Debug.Log("SAVING");

        SaveData saveData = new SaveData();
        saveData.m_RoadData = new List<RoadData>();
        var roads = circuitManager.Roads.Select(x => x.GetComponent<RoadDataComponent>());

        //When adding new types to the Road data add them here too
        foreach (var road in roads) {
            RoadData data = new RoadData()
            {
                m_Position = road.m_Position,
                x = road.x,
                y = road.y,
                z = road.z,
                m_Roadtype = road.m_Roadtype,
                name = road.name
            };
            saveData.m_RoadData.Add(data);
        }

        if (Application.isEditor)
        {
            path = Application.dataPath + "/SaveFolder/" + filename + ".json";
        }
        else
        {
            path = Application.persistentDataPath + "/SaveFolder/" + filename + ".json";
        }

        FileStream fileStream = new FileStream(path, FileMode.Create);

        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            string json = JsonUtility.ToJson(saveData, true);
            writer.Write(json);
        }

        OnSave?.Invoke();
    }
    
    [ContextMenu("Load")]
    public void Load()
    {
        if (Application.isEditor)
        {
            path = Application.dataPath + "/SaveFolder/" + filename + ".json";
        }
        else
        {
            path = Application.persistentDataPath + "/SaveFolder/" + filename + ".json";
        }

        FileStream fileStream = new FileStream(path, FileMode.Open);
        string json = "";
        using (StreamReader reader = new StreamReader(fileStream))
        {
            json = reader.ReadToEnd();
        }
        data = JsonUtility.FromJson<SaveData>(json);

        OnLoad?.Invoke();
    }

    public SaveData GetLoadData()
    {
        if (data == null)
            Load();

        return data;
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
    public string name = "MyProject";
    public Vector3 m_Position;
    public float x,y,z;
    public RoadDirection m_Roadtype;
}