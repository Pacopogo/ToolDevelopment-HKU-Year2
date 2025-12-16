using UnityEngine;
using System.Collections.Generic;

public class CircuitManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> m_Roads;
    private GameObject lastObj;

    public static CircuitManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void AddRoad(GameObject obj)
    {
        m_Roads.Add(obj);
        lastObj = obj;
    }

    /// <summary>
    /// Removes the last object in the list from the m_Roads
    /// </summary>
    [ContextMenu("Remove last")]
    public void RemoveLastRoad()
    {
        m_Roads.Remove(m_Roads[m_Roads.Count - 1]);
    }

    /// <summary>
    /// Clears the entire list
    /// </summary>
    [ContextMenu("CLEAR")]
    public void ClearRoads()
    {
        m_Roads.Clear();
    }

    [ContextMenu("Make Mesh")]
    public void CombineMesh()
    {
        //Add the mesh combinder here
    }
}
