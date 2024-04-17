using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string sceneName;

    public void OnButtonClick()
    {
        SwitchScene();
    }

    private void SwitchScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
