using UnityEngine;

public class SceneTransferData : MonoBehaviour
{
    public static SceneTransferData instance;

    public string ProjectName;

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
}
