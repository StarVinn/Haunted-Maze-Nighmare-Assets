using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string sceneToLoad; // The name of the scene to load
    private float stayTime = 3f; // Time required to stay in the portal
    private float timer = 0f; // Timer to track how long the player has been in the portal
    private bool isPlayerInPortal = false; // Flag to check if the player is in the portal

    private void Update()
    {
        // If the player is in the portal, increment the timer
        if (isPlayerInPortal)
        {
            timer += Time.deltaTime;

            // Check if the timer has reached the required stay time
            if (timer >= stayTime)
            {
                LoadScene(); // Load the new scene
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the player
        if (other.CompareTag("Player"))
        {
            isPlayerInPortal = true; // Set the flag to true
            timer = 0f; // Reset the timer
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the colliding object is the player
        if (other.CompareTag("Player"))
        {
            isPlayerInPortal = false; // Set the flag to false
            timer = 0f; // Reset the timer
        }
    }

    private void LoadScene()
    {
        // Load the specified scene
        SceneManager.LoadScene(sceneToLoad);
    }
}
