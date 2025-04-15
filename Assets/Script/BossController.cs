using UnityEngine;
using UnityEngine.SceneManagement;

public class BossController : MonoBehaviour
{
    public Transform player; // Reference to the player
    public float moveSpeed = 3f; // Speed at which the boss moves
    public float dashSpeed = 10f; // Speed during dash
    public float dashDistance = 5f; // Distance to dash
    public float attackCooldown = 2f; // Time between attacks
    public int health = 100; // Boss health

    // New variable to define the chase range
    public float chaseRange = 10f; // Range within which the boss will chase the player

    private float attackTimer; // Timer to track attack cooldown
    private Vector3 targetPosition; // Target position for the boss to move towards

    private void Start()
    {
        targetPosition = new Vector3(0, 0, 0); // Set the initial target position (adjust as needed)
    }

    private void Update()
    {
        FollowPlayer();
        AttackPlayer();
    }

    private void FollowPlayer()
    {
        // Calculate the distance to the player
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);

        // Check if the player is within chase range
        if (distanceToPlayer <= chaseRange)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
        else
        {
            // If the player is out of range, move towards the target position
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }

    private void AttackPlayer()
    {
        attackTimer += Time.deltaTime;
        if (attackTimer >= attackCooldown)
        {
            float distanceToPlayer = Vector3.Distance(player.position, transform.position);
            // Check if the player is within attack range
            if (distanceToPlayer <= chaseRange)
            {
                Vector3 direction = (player.position - transform.position).normalized;
                transform.position += direction * dashDistance; // Dash towards the player
                attackTimer = 0f; // Reset the attack timer
            }
        }
    }
}