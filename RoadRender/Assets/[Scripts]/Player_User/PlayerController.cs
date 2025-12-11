using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Transform m_CameraTrans;

    [Header("Settings")]
    [SerializeField] private float m_MouseSensitivity = 6f;
    [SerializeField] private float m_Speed = 6f;
    private float m_BaseSpeed = 8f;

    private Vector2 m_Direction;
    private float m_YDiretion;
    private Vector2 m_MouseDirection;

    private bool m_IsMoving;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void MoveDirection(InputAction.CallbackContext context)
    {
        m_Direction = context.ReadValue<Vector2>().normalized;
    }

    private void FixedUpdate()
    {

        Movement();
        CameraRotation();

    }

    private void Movement()
    {
        float xDir = m_Direction.x * m_Speed * Time.fixedDeltaTime;
        float yDir = m_Direction.y * m_Speed * Time.fixedDeltaTime;
        float zDir = m_YDiretion * m_Speed * Time.fixedDeltaTime;

        transform.Translate(Vector3.right * xDir, Space.Self);
        transform.Translate(m_CameraTrans.forward * yDir, Space.World);
        transform.Translate(Vector3.up * zDir, Space.Self);
    }

    private void CameraRotation()
    {
        float xMouse = m_MouseDirection.x * m_MouseSensitivity * Time.fixedDeltaTime;
        float yMouse = m_MouseDirection.y * m_MouseSensitivity * Time.fixedDeltaTime;

        transform.Rotate(Vector3.up * xMouse, Space.Self);
        m_CameraTrans.Rotate(Vector3.left * yMouse, Space.Self);
    }

    public void AddMoveSpeed(InputAction.CallbackContext context)
    {
        if (!context.performed) 
            return;

        float amplifier = context.ReadValue<float>();
        Mathf.Round(amplifier);

        m_Speed += amplifier;

        if(m_Speed < 0) m_Speed = 0;
        if(m_Speed > 100) m_Speed = 100;
    }

    public void VerticalMove(InputAction.CallbackContext context)
    {
        m_YDiretion = context.ReadValue<float>();
    }

    public void MouseInput(InputAction.CallbackContext context)
    {
        m_MouseDirection = context.ReadValue<Vector2>();
    }
}
