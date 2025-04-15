using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button startButton;
    public Button optionsButton;
    public Button creditsButton;
    public Button quitButton; // Reference to the Quit button
    public Button victoryButton;

    void Start()
    {
        startButton.onClick.AddListener(StartGame);
        optionsButton.onClick.AddListener(OpenOptions);
        creditsButton.onClick.AddListener(OpenCredits);
        quitButton.onClick.AddListener(QuitGame);
        victoryButton.onClick.AddListener(CreditsTrigger);
    }

    void StartGame()
    {
        SceneManager.LoadScene("Level1");
        Time.timeScale = 1; 
    }

    void OpenOptions()
    {
        // Code to open options menu
    }

    void OpenCredits()
    {
        // Code to display credits
    }

    void CreditsTrigger()
    {
        SceneManager.LoadScene("VictoryScene");
        Time.timeScale = 1;
    }

    void QuitGame()
    {
#if UNITY_EDITOR
        // If we are in the editor, stop play mode
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // If we are in a standalone build, quit the application
        Application.Quit();
#endif
    }
}