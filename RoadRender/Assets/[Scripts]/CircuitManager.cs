using UnityEngine;
using System.Collections.Generic;

public class CircuitManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> m_Roads;
    private List<MeshFilter> m_Meshes = new List<MeshFilter>();

    [SerializeField] private MeshFilter m_TargetMesh;

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
        var combine = new CombineInstance[m_Roads.Count];

        foreach(GameObject obj in m_Roads)
        {
            MeshFilterObject meshObj = obj.GetComponent<MeshFilterObject>();
            m_Meshes.Add(meshObj.GetFilter());
        }

        for (int i = 0; i < m_Meshes.Count; i++)
        {
            combine[i].mesh = m_Meshes[i].sharedMesh;
            combine[i].transform = m_Meshes[i].transform.localToWorldMatrix;
        }

        Mesh mesh = new Mesh();

        mesh.CombineMeshes(combine);

        m_TargetMesh.mesh = mesh;

    }
}
