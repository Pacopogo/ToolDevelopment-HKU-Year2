using UnityEngine;
public class RoadDataComponent : MonoBehaviour
{
    public string name = "yes its a bit of text";
    public Vector3 m_Position;
    public float x,y,z;
    public RoadDirection m_Roadtype;

    private void Start()
    {
        name = gameObject.name;
        m_Position = transform.position;
        
        //Saving rotation
        x = transform.eulerAngles.x;
        y = transform.eulerAngles.y;
        z = transform.eulerAngles.z;
    }
}
