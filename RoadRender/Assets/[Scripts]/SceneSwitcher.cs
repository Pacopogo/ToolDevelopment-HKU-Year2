using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void LoadSceneName(string sceneName) => SceneManager.LoadSceneAsync(sceneName);
}
