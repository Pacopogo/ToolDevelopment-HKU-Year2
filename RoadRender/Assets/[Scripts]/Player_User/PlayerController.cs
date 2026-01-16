using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Transform m_CameraTrans;

    [Header("Settings")]
    [SerializeField] private float m_MouseSensitivity = 6f;
    [SerializeField] private float m_Speed = 6f;

    private Vector2 m_Direction;
    private float m_YDiretion;
    private Vector2 m_MouseDirection;


    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        CursorState(true);

        m_CameraTrans.rotation = new Quaternion(0, 0, 0, 0);
        transform.rotation = new Quaternion(0, 0, 0, 0);

        UpdateMouseSens();
    }

    public void MoveDirection(InputAction.CallbackContext context)
    {
        m_Direction = context.ReadValue<Vector2>().normalized;
    }

    private void Update()
    {
        Movement();
        CameraRotation();
        
    }
    /// <summary>
    /// This function handles the 3d movement of the player/user
    /// </summary>
    private void Movement()
    {
        float xDir = m_Direction.x * m_Speed * Time.deltaTime;
        float yDir = m_Direction.y * m_Speed * Time.deltaTime;
        float zDir = m_YDiretion * m_Speed * Time.deltaTime;

        transform.Translate(Vector3.right * xDir, Space.Self);
        transform.Translate(m_CameraTrans.forward * yDir, Space.World);
        transform.Translate(Vector3.up * zDir, Space.Self);
    }

    /// <summary>
    /// this function handles the rotation of the camera and the body
    /// </summary>
    private void CameraRotation()
    {
        float xMouse = m_MouseDirection.x * m_MouseSensitivity * Time.deltaTime;
        float yMouse = m_MouseDirection.y * m_MouseSensitivity * Time.deltaTime;

        transform.Rotate(Vector3.up * xMouse, Space.Self);
        m_CameraTrans.Rotate(Vector3.left * yMouse, Space.Self);
    }

    /// <summary>
    /// this input event adds/decreases on basis of an Axis input (which are "-" & "+" right now)
    /// </summary>
    /// <param name="context"></param>
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

    public void UpdateMouseSens()
    {
        m_MouseSensitivity = SceneTransferData.instance.mouseSensitivity;

    }

    public void UpdateMouseSensePlayer(float amount)
    {
        SceneTransferData.instance.SetMouseSensitivity(amount);
        UpdateMouseSens();
    }

    public void CursorState(bool lockMode)
    {
        if (lockMode)
        {
         Cursor.lockState = CursorLockMode.Locked;

        }
        else
        {
            Cursor.lockState = CursorLockMode.None;

        }

    }
}
