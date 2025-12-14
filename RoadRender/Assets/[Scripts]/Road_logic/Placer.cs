using UnityEngine;

public class Placer : MonoBehaviour, IPlaceable
{
    [Header("Component")]
    [SerializeField] private GameObject PlacerObj;
    [SerializeField] private GameObject PlacePoint;

    [Header("Objects")]
    [SerializeField] private GameObject PlaceTarget;
    private GameObject placingObj;

    [Header("Off-set")]
    [SerializeField] private float yOffSet = 0;

    public void Place()
    {
        if (!PlaceTarget)
            return;

        GameObject placeObj;
        placeObj = Instantiate(PlaceTarget);

        placeObj.transform.position
        = new Vector3(
        PlacePoint.transform.position.x,
        PlacePoint.transform.position.y + yOffSet,
        PlacePoint.transform.position.z);

        placeObj.transform.rotation = PlacePoint.transform.rotation;

        PlacerObj.SetActive(false);
    }
}
