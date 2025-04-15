using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Check if the "R" key is pressed
        if (Input.GetKeyDown(KeyCode.R))
        {
            // Reset the time scale to normal (in case it was paused)
            Time.timeScale = 1;

            // Get the current active scene
            Scene currentScene = SceneManager.GetActiveScene();

            // Reload the current scene using its build index
            SceneManager.LoadScene(currentScene.buildIndex);
        }
    }
}
