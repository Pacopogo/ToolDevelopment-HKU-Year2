using UnityEngine;

public class PlacerRemover : MonoBehaviour
{
    [SerializeField] private GameObject m_placerObj;
    private void Start()
    {
        CheckIfLast();
    }

    /// <summary>
    /// this function checks if current road is the last road in the list of placed roads
    /// (if it is it will display the placing object)
    /// </summary>
    public void CheckIfLast()
    {
        int last = CircuitManager.instance.Roads.Count - 1;
        
        if (gameObject != CircuitManager.instance.Roads[last])
        {
            m_placerObj.SetActive(false);
            return;
        }

        m_placerObj.SetActive(true);

    }
}
