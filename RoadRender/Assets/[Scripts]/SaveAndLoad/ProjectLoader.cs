using System.Collections.Generic;
using UnityEngine;

public class ProjectLoader : MonoBehaviour
{
    [Header("Load Data")]
    [SerializeField] private SaveManager m_SaveManager;
    private SaveData m_SaveData;

    [SerializeField] private bool loadingProject = false;

    public List<RoadData> RoadDatas;

    [Header("Prefabs")]
    [SerializeField] private GameObject m_RoadForward;
    [SerializeField] private GameObject m_RoadLeft;
    [SerializeField] private GameObject m_RoadRight;
    [SerializeField] private GameObject m_RoadUp;
    [SerializeField] private GameObject m_RoadDown;

    private void Start()
    {
        if (loadingProject)
        {
            LoadProject();
        }
    }

    [ContextMenu("PLACE PROJECT")]
    public void LoadProject()
    {
        m_SaveManager.Load();

        m_SaveData = m_SaveManager.GetLoadData();

        foreach (var road in m_SaveData.m_RoadData)
        {
            RoadDatas.Add(road);

            PlaceRoadFromData(
                road.m_Roadtype,
                road.m_Position,
                new Vector3(road.x, road.y, road.z)
                );
        }
    }

    public void PlaceRoadFromData(RoadDirection type, Vector3 pos, Vector3 rot)
    {
        GameObject roadObj = null;
        GameObject tempObj;

        switch (type)
        {
            case RoadDirection.forward:
                roadObj = m_RoadForward;
                break;
            case RoadDirection.left:
                roadObj = m_RoadLeft;
                break;
            case RoadDirection.right:
                roadObj = m_RoadRight;
                break;
            case RoadDirection.up:
                roadObj = m_RoadUp;
                break;
            case RoadDirection.down:
                roadObj = m_RoadDown;
                break;
            default:
                break;
        }

        tempObj = Instantiate(roadObj);
        tempObj.transform.position = pos;
        tempObj.transform.rotation = new Quaternion(rot.x, rot.y, rot.z, 0);

        CircuitManager.instance.AddRoad(tempObj);

        Debug.Log(rot);
    }
}
