using System.Collections.Generic;
using TMPro;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

/// <summary>
/// This class is to Set all the variables from the Creator menu to the MetaData
/// </summary>
public class ProjectCreator : MonoBehaviour
{
    [Header("Editable text fields")]
    [SerializeField] private TMP_Text nameField;
    [SerializeField] private TMP_Text descriptionField;
    [SerializeField] private TMP_Text debugNumb;

    private List<ProjectData> projectDataList = new List<ProjectData>();
    private ProjectData currentData = new ProjectData("","");

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
        FileHandler.Save<ProjectData>(projectDataList, currentData.Name);
    }
}
