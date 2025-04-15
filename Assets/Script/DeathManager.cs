using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathManager : MonoBehaviour
{
    public Button restartButton;
    public Button mainMenuButton;
    public string sceneToLoad;

    void Start()
    {
        restartButton.onClick.AddListener(RestartGame);
        mainMenuButton.onClick.AddListener(GoToMainMenu);
    }

    void RestartGame()
    {
        SceneManager.LoadScene(sceneToLoad);
        Time.timeScale = 1;
    }

    void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); // Replace with your main menu scene name
    }
}