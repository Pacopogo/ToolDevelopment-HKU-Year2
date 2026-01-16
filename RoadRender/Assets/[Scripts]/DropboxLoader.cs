using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DropboxLoader : MonoBehaviour
{
    [SerializeField] private ProjectCreator projectCreator;

    [Header("Project Options")]
    [SerializeField] private TMP_Dropdown dropDown;
    private TMP_Dropdown.OptionData optionData = new TMP_Dropdown.OptionData();

    private void Start()
    {
        dropDown.ClearOptions();
        LoadOptions();
    }

    [ContextMenu("LOAD PROJECTS")]
    public void LoadOptions()
    {
        projectCreator.LoadProjectList();

        foreach (var item in projectCreator.projectlist.Projects)
        {
            TMP_Dropdown.OptionData option;
            option = new TMP_Dropdown.OptionData();
            
            option.text = item;

            Debug.Log(item);
            dropDown.options.Add(option);
        }



    }
}
