using UnityEngine;
using System.Collections.Generic;


[CreateAssetMenu(fileName = "Road Data", menuName = "Road Direction/Road_Dir", order = 1)]
public class RoadDirectionData : ScriptableObject
{
    public List<GameObject> Roads = new List<GameObject>();
}
