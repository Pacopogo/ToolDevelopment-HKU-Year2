using UnityEngine;
public enum RoadDirection
{
    forward,
    left,
    right,
    up,
    down,
}
public class DirectionLogic : MonoBehaviour, IPlaceable
{
    public RoadDirection RoadDirection;
    [SerializeField] private RoadDirectionData m_DirectionData;
    [SerializeField] private Transform m_PlacePoint;

    [SerializeField] private GameObject m_ParentObj;

    public void Place()
    {
       GameObject obj = Instantiate(m_DirectionData?.Roads[0]);

        obj.transform.position = m_PlacePoint.position;
        obj.transform.rotation = m_PlacePoint.rotation;

        CircuitManager.instance.AddRoad(obj);

        m_ParentObj.SetActive(false);
    }
}
