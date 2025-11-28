using System.Diagnostics;
using UnityEditor;
using UnityEngine;

/// <summary>
/// This script will be used to make navigating through the main menu window easier
/// and more hands on for myself
/// </summary>
public class MenuNavigator : MonoBehaviour
{
    public void OpenSaveFolder() {
#if UNITY_EDITOR
        EditorUtility.RevealInFinder(Application.persistentDataPath + "/" + Application.productName);
#endif
    }
    public void CloseApp() => Application.Quit();
}
