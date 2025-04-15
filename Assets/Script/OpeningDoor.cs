using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningDoor : MonoBehaviour
{
    public bool isLocked = true; // Indicates if the door is locked
    public GameObject key; // Reference to the key GameObject
    public bool isTrigger = false; // Indicates if the player can interact with the door

    private void Start()
    {
        // Optionally, you can set the key GameObject in the Inspector
        if (key != null)
        {
            key.SetActive(true); // Ensure the key is active in the scene
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player collides with the door
        if (other.CompareTag("Player"))
        {
            // Check if the player has the key
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null && playerController.hasKey)
            {
                isTrigger = true; // Player can interact with the door
                StartCoroutine(OpenDoor()); // Start the door opening coroutine
            }
            else
            {
                isTrigger = false; // Player cannot interact with the door
                Debug.Log("You need a key to open this door.");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Reset isTrigger when the player exits the trigger area
        if (other.CompareTag("Player"))
        {
            isTrigger = false; // Player is no longer in the trigger area
        }
    }

    private IEnumerator OpenDoor()
    {
        if (isLocked)
        {
            Debug.Log("Door opened!");
            isLocked = false; // Unlock the door

            // Optionally, you can add a delay or animation here before destroying the door
            yield return new WaitForSeconds(1f); // Wait for 1 second (optional)

            Destroy(gameObject); // Destroy the door GameObject
        }
    }
}