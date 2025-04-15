using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CreditsManager : MonoBehaviour
{
    public float scrollSpeed = 50f; // Speed of the credits scrolling
    public RectTransform creditsPanel; // Reference to the RectTransform of the credits panel
    public Button mainMenuButton; // Reference to the main menu button
    public TMP_Text creditsText; // Reference to the Text component for the credits

    private void Start()
    {
        // Set the button to inactive at the start
        mainMenuButton.gameObject.SetActive(false);

        // Start the rainbow effect
        StartCoroutine(RainbowText());
    }

    private void Update()
    {
        // Scroll the credits
        creditsPanel.anchoredPosition += new Vector2(0, scrollSpeed * Time.deltaTime);

        // Check if the credits have finished scrolling
        if (creditsPanel.anchoredPosition.y >= Screen.height)
        {
            // Show the main menu button
            mainMenuButton.gameObject.SetActive(true);
        }
    }

    public void LoadMainMenu()
    {
        // Load the main menu scene (replace "MainMenu" with your actual main menu scene name)
        SceneManager.LoadScene("MainMenu");
    }

    private IEnumerator RainbowText()
    {
        Color[] colors = new Color[] { Color.red, Color.yellow, Color.green, Color.cyan, Color.blue, Color.magenta };
        float duration = 1f; // Duration for each color transition
        float elapsedTime = 0f;

        while (true)
        {
            for (int i = 0; i < colors.Length; i++)
            {
                Color startColor = colors[i];
                Color endColor = colors[(i + 1) % colors.Length]; // Loop back to the first color
                elapsedTime = 0f;

                while (elapsedTime < duration)
                {
                    creditsText.color = Color.Lerp(startColor, endColor, elapsedTime / duration);
                    elapsedTime += Time.deltaTime;
                    yield return null; // Wait for the next frame
                }

                // Ensure the final color is set
                creditsText.color = endColor;
            }
        }
    }
}