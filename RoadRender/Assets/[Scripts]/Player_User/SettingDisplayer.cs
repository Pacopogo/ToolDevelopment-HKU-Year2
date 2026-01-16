using TMPro;
using UnityEngine;

public class SettingDisplayer : MonoBehaviour
{
    [SerializeField] private TMP_Text m_mouseSense;

    private void Start()
    {
        UpdateMouseText();
    }
    public void UpdateMouseText() => m_mouseSense.text = SceneTransferData.instance.mouseSensitivity.ToString();

}
