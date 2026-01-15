using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

/// <summary>
/// This script will be used to make navigating through the main menu window easier
/// and more hands on for myself
/// </summary>
public class MenuNavigator : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void OpenSaveFolder() {
#if UNITY_EDITOR
        EditorUtility.RevealInFinder(Application.persistentDataPath + "/" + Application.productName);
#endif
        Application.OpenURL(Application.persistentDataPath);

    }
    public void CloseApp() => Application.Quit();
}
