using UnityEngine;

public class SceneTransferData : MonoBehaviour
{
    public static SceneTransferData instance;

    public string ProjectName;

    public float mouseSensitivity = 10;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    public void SetMouseSensitivity(float amount)
    {
        if (mouseSensitivity <= 0)
        {
            mouseSensitivity = 0;
            return;
        }

        mouseSensitivity += amount;
    }
}
