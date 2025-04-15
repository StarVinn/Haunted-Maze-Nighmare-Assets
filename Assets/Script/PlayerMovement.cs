using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Speed of the player
    public float rotationSpeed = 700f; // Speed of rotation
    public string sceneToLoad;

    private CharacterController characterController;
    private Animator animator; // Reference to the Animator

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>(); // Get the Animator component
    }

    void Update()
    {
        // Get input from the player
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Create a movement vector
        Vector3 move = new Vector3(horizontal, 0, vertical);
        move = Camera.main.transform.TransformDirection(move); // Move relative to the camera
        move.y = 0; // Keep the movement on the ground plane

        // Normalize the movement vector to avoid faster diagonal movement
        if (move.magnitude > 1)
        {
            move.Normalize();
        }

        // Move the player
        characterController.Move(move * speed * Time.deltaTime);

        // Rotate the player to face the movement direction
        if (move != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(move);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        // Update Animator parameters
        UpdateAnimator(move);
    }

    private void UpdateAnimator(Vector3 move)
    {
        // Set animator parameters based on movement
        animator.SetBool("isRunning", move.magnitude > 0); // Set isRunning based on movement
        animator.SetFloat("speed", move.magnitude); // Set speed based on movement magnitude
    }

    //private void OnTriggerEnter(Collider collider)
    //{
    //    if (collider.CompareTag("hantu"))
    //    {
    //        Time.timeScale = 0;
    //        SceneManager.LoadScene(sceneToLoad);
    //    }
    //}
}