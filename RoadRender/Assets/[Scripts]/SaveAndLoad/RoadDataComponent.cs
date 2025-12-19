using UnityEngine;
public class RoadDataComponent : MonoBehaviour
{
    public string name = "yes its a bit of text";
    public Vector3 m_Position;
    public Vector3 m_Rotation;
    public RoadDirection m_Roadtype;

    private void Start()
    {
        name = gameObject.name;
        m_Position = transform.position;
        
        //Saving rotation
        m_Rotation.x = transform.rotation.x;
        m_Rotation.y = transform.rotation.y;
        m_Rotation.z = transform.rotation.z;
    }
}
