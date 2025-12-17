using UnityEngine;

public class MeshFilterObject : MonoBehaviour
{
    [SerializeField] private MeshFilter m_MeshFilter;
    public MeshFilter GetFilter() => m_MeshFilter;
}
