using UnityEngine;

[System.Serializable]
public class ProjectData
{
    public string Name;
    public string Description;
    public string ImportantNumber;     //this number isn't important but it is to test if it saves the data

    public ProjectData(string name, string discription)
    {
        Name = name;
        Description = discription;
        ImportantNumber = "";
    }

}
