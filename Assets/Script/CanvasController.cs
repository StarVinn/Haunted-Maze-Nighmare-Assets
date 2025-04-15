using UnityEngine;

public class CanvasController : MonoBehaviour
{
    // Reference to the Canvas GameObject
    private Canvas canvas;

    void Start()
    {
        // Get the Canvas component
        canvas = GetComponent<Canvas>();

        // Ensure the Canvas is active when the scene loads
        if (canvas != null)
        {
            canvas.enabled = true; // Make sure the Canvas is enabled
        }

    }
}