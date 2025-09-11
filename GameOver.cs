using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public void RestartGame()
    {
        // Reload game scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToHome()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
