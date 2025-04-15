using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour
{
    public float moveSpeed = 2f; // Speed of movement
    public float moveDistance = 5f; // Distance to move forward and backward
    public Quaternion resetRotation = Quaternion.Euler(0, 0, 0); // Rotation to reset to when returning to start position

    private Vector3 startPosition;
    private Vector3 targetPosition;
    private bool movingForward = true;
    private Animator animator; // Reference to the Animator

    void Start()
    {
        startPosition = transform.position;
        targetPosition = startPosition + transform.forward * moveDistance;
        animator = GetComponent<Animator>(); // Get the Animator component
    }

    void Update()
    {
        MoveObject();
    }

    void MoveObject()
    {
        // Calculate the step size based on the speed and time
        float step = moveSpeed * Time.deltaTime;

        // Move the object
        if (movingForward)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                // Instantly rotate 180 degrees when reaching target position
                transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y + 180, 0);
                movingForward = false; // Switch direction
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, step);
            if (Vector3.Distance(transform.position, startPosition) < 0.1f)
            {
                // Reset rotation to the specified rotation when reaching start position
                transform.rotation = resetRotation; // Use the public variable for rotation
                movingForward = true; // Switch direction
            }
        }

        // Update Animator parameter based on movement
        UpdateAnimator();
    }

    private void UpdateAnimator()
    {
        // Set the isMoving parameter based on whether the object is moving
        animator.SetBool("isMoving", movingForward || !movingForward); // Always true while moving
    }
}