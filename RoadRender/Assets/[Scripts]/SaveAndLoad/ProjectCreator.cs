using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

/// <summary>
/// This script is to manage the set data from the UI to a save file
/// </summary>
public class ProjectCreator : MonoBehaviour
{
    [Header("Editable text fields")]
    [SerializeField] private TMP_Text nameField;
    [SerializeField] private TMP_Text descriptionField;
    [SerializeField] private TMP_Text debugNumb;

    [Header("Project Options")]
    [SerializeField] private TMP_Dropdown dropDown;
    private TMP_Dropdown.OptionData optionData = new TMP_Dropdown.OptionData();

    private List<ProjectData> projectDataList = new List<ProjectData>();
    private ProjectData currentData = new ProjectData();

    [SerializeField] private SceneTransferData sceneTransferData;
    [SerializeField] private string path;   //To save path
    public ProjectList projectlist;

    private void Start()
    {
        LoadProjectList();
    }

    public void SetNameData()
    {
        currentData.Name = nameField.text;
    }

    public void SetDiscriptionData()
    {
        currentData.Description = descriptionField.text;
    }

    //Don't question why this is a string atm
    public void SetNumber()
    {
        currentData.ImportantNumber = debugNumb.text;
    }

    public void CreateNewSave()
    {
        projectDataList.Add(currentData);
        FileHandler.SaveList<ProjectData>(projectDataList, currentData.Name);

        optionData.text = currentData.Name;

        dropDown.options.Add(optionData);

        SaveFile(currentData.Name);

    }

    private void SaveFile(string name)
    {
        if (Application.isEditor)
        {
            path = Application.dataPath + "/SaveFolder/" + name + ".json";
        }
        else
        {
            path = Application.persistentDataPath + "/" + name + ".json";
        }

        FileStream fileStream = new FileStream(path, FileMode.Create);

        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            string json = JsonUtility.ToJson("", true);
            writer.Write(json);
        }

        //Save the name in the list of Projects
        projectlist.Projects.Add(name);

        SceneTransferData.instance.ProjectName = name;

        SaveProjectFile();

    }

    [ContextMenu("Save Projects")]
    public void SaveProjectFile()
    {
        if (Application.isEditor)
        {
            path = Application.dataPath + "/" + "ProjectList" + ".json";
        }
        else
        {
            path = Application.persistentDataPath + "/" + "ProjectList" + ".json";
        }

        FileStream fileStream = new FileStream(path, FileMode.Create);

        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            string json = JsonUtility.ToJson(projectlist, true);
            writer.Write(json);
        }
    }

    [ContextMenu("Load Projects")]
    public void LoadProjectList()
    {
        if (Application.isEditor)
        {
            path = Application.dataPath + "/" + "ProjectList" + ".json";
        }
        else
        {
            path = Application.persistentDataPath + "/" + "ProjectList" + ".json";
        }

        FileStream fileStream = new FileStream(path, FileMode.Open);
        string json = "";
        using (StreamReader reader = new StreamReader(fileStream))
        {
            json = reader.ReadToEnd();
        }

        projectlist = JsonUtility.FromJson<ProjectList>(json);
    }
}

[System.Serializable]
public class ProjectList
{
    public List<string> Projects = new List<string>();
}