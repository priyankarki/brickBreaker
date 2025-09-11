using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitGame : MonoBehaviour
{
    [Header("Home Scene Name")]
    public string homeSceneName = "MainMenu";

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            SceneManager.LoadScene(homeSceneName);
            Time.timeScale = 1f;
        }
    }
}
