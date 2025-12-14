using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPlacer : MonoBehaviour
{
    [SerializeField] private LayerMask InteracitonLayer;

    private void FixedUpdate()
    {
    }
    public void OnInteract(InputAction.CallbackContext context)
    {
        RaycastHit hit;

        if (!context.performed)

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, InteracitonLayer))
            {
                GameObject gameObj = hit.collider.gameObject;

                if (gameObj.GetComponent<Placer>() != null)
                {
                    gameObj.GetComponent<Placer>().Place();
                }
            }

    }
}
