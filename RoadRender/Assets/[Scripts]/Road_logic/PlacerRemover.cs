using UnityEngine;

public class PlacerRemover : MonoBehaviour
{
    [SerializeField] private GameObject m_PlacerObj;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit");
        //if (!collision.gameObject.GetComponent<CarSpawner>())
        //    return;

        m_PlacerObj.SetActive(false);


    }

}
