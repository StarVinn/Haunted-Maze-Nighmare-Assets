using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Import this for UI elements
using TMPro;

public class PlayerController : MonoBehaviour
{
    public bool hasKey = false; // Track if the player has the key
    public TextMeshProUGUI keyText;

    private void Start()
    {
        // Initialize the text to be empty at the start
        keyText.text = "";
        keyText.color = new Color(keyText.color.r, keyText.color.g, keyText.color.b, 0);

    }

    private void Update()
    {
        // Check for interaction with the door
        if (Input.GetKeyDown(KeyCode.E)) // Change 'E' to whatever key you want for interaction
        {
            // You can add door interaction logic here if needed
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player collides with the key
        if (other.CompareTag("Key"))
        {
            CollectKey(other.gameObject);
        }
    }

    private void CollectKey(GameObject key)
    {
        hasKey = true; // Set the key status to true
        Debug.Log("Key collected!");

        // Update the UI text to inform the player
        keyText.text = "Key Collected!";
        keyText.color = new Color(keyText.color.r, keyText.color.g, keyText.color.b, 1); // Set alpha to 1 (fully visible)

        // Start the fade-out coroutine
        StartCoroutine(FadeOutText(2f)); // Fade out over 2 seconds

        Destroy(key); // Remove the key from the scene
    }

    private IEnumerator FadeOutText(float duration)
    {
        float startAlpha = keyText.color.a;
        float time = 0;

        // Fade out the text
        while (time < duration)
        {
            time += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, 0, time / duration);
            keyText.color = new Color(keyText.color.r, keyText.color.g, keyText.color.b, alpha);    
            yield return null; // Wait for the next frame
        }

        // Ensure the text is completely transparent at the end
        keyText.color = new Color(keyText.color.r, keyText.color.g, keyText.color.b, 0);
    }

}