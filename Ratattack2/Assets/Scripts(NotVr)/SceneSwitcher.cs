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
        if (string.IsNullOrEmpty(sceneName))
        {
            // If sceneName is empty or null, reload the current scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            // Otherwise, load the scene specified by sceneName
            SceneManager.LoadScene(sceneName);
        }
    }
}
