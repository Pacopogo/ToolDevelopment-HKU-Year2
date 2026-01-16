using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerQuickKeys : MonoBehaviour
{
    public void Undo(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        CircuitManager.instance.UndoRoad();
    }
}
