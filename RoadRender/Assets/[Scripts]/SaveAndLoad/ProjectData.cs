using UnityEngine;
/// <summary>
/// This is the current data to be saved
/// Most of it is dummy data and made so I can test and make a simple save and load script
/// </summary>
[System.Serializable]
public class ProjectData
{
    public string Name;
    public string Description;
    public string ImportantNumber;     //this number isn't important but it is to test if it saves the data
}
