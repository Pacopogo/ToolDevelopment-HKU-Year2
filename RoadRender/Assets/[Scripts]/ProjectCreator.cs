using System.Collections.Generic;
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
    }
}
