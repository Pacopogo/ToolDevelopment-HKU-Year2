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
        LoadOptions();
    }

    [ContextMenu("LOAD PROJECTS")]
    public void LoadOptions()
    {
        projectCreator.LoadProjectList();

        foreach (var item in projectCreator.projectlist.Projects)
        {
            optionData.text = item;
            dropDown.options.Add(optionData);
        }
    }
}
