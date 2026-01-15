using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CircuitManager : MonoBehaviour
{
    [field: SerializeField] public List<GameObject> Roads { get; private set; } = new List<GameObject>();
    private List<MeshFilter> m_Meshes = new List<MeshFilter>();

    [SerializeField] private ExportInProject m_Exporter;

    [SerializeField] private MeshFilter m_TargetMesh;

    public static CircuitManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void AddRoad(GameObject obj)
    {
        Roads.Add(obj);
    }

    /// <summary>
    /// Removes the last object in the list from the m_Roads
    /// </summary>
    [ContextMenu("Remove last")]
    public void RemoveLastRoad()
    {
        Roads.Remove(Roads[Roads.Count - 1]);
    }

    /// <summary>
    /// Clears the entire list
    /// </summary>
    [ContextMenu("CLEAR")]
    public void ClearRoads()
    {
        Roads.Clear();
    }

    [ContextMenu("Make Mesh")]
    public void CombineMesh()
    {
        var combine = new CombineInstance[Roads.Count];

        foreach (GameObject obj in Roads)
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

    [ContextMenu("Export")]
    public void ExportMesh()
    {
        //Safe guard to make an combine mesh before exporting (else you export no-data)
        CombineMesh();

        string path;
        string filename = SceneTransferData.instance.ProjectName;


        Debug.Log("EXPORTING: " + filename);

        //The file path to OBJ
        if (Application.isEditor)
        {
            path = Application.dataPath + "/SaveFolder/" + filename + ".obj";
        }
        else
        {
            path = Application.persistentDataPath + "/" + filename + ".obj";
        }

        m_Exporter.ExportObject(m_TargetMesh.gameObject, path);
    }
}
