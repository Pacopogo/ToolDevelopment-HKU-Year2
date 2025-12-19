using System.Linq;
using TMPro;
using UnityEngine;

/// <summary>
/// This script is to get the currently selected project form the dropdown box and
/// display the data from that project
/// 
/// This script does not work yet!!!
/// for some reason it still gives Empty version of ProjectData ):
/// </summary>
public class CurrentProjectDisplayer : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;

    [Header("Display Components")]
    [SerializeField] private TMP_Text nameText;
    
    public void GetProject()
    {

    }

    public void SetProject()
    {
       SceneTransferData.instance.ProjectName = nameText.text;
    }
}
