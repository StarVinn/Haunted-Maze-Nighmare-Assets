using System.Collections; // Required for IEnumerator
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Add this to use SceneManager

public class JumpscareTrigger : MonoBehaviour
{
    public Image jumpscareImage; // Reference to the jumpscare image
    public AudioSource jumpscareAudio; // Reference to the audio source
    public float displayDuration = 1.5f; // Duration to display the jumpscare
    public float fadeDuration = 0.5f; // Duration for fade in/out
    public string deathSceneName; // Name of the scene to load after the jumpscare
    public Canvas jumpscareCanvas; // Reference to the Canvas

    private void Start()
    {
        // Deactivate the jumpscare canvas at the start
        if (jumpscareCanvas != null)
        {
            jumpscareCanvas.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("hantu")) // Check if the player collides with the Boss
        {
            // Activate the jumpscare canvas
            if (jumpscareCanvas != null)
            {
                jumpscareCanvas.gameObject.SetActive(true);
            }
            StartCoroutine(TriggerJumpscare());
            
        }
    }

    private IEnumerator TriggerJumpscare()
    {
        // Play the jumpscare audio
        jumpscareAudio.Play();

        // Fade in the jumpscare image
        float elapsedTime = 0f;
        Color imageColor = jumpscareImage.color;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            imageColor.a = Mathf.Clamp01(elapsedTime / fadeDuration);
            jumpscareImage.color = imageColor;
            yield return null;
        }

        // Wait for the display duration
        yield return new WaitForSeconds(displayDuration);

        // Fade out the jumpscare image
        elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            imageColor.a = Mathf.Clamp01(1 - (elapsedTime / fadeDuration));
            jumpscareImage.color = imageColor;
            yield return null;
        }

        // Optionally, you can deactivate the image or reset it
        jumpscareImage.gameObject.SetActive(false);

        SceneManager.LoadScene(deathSceneName);
    }
}