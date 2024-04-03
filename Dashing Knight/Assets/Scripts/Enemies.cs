using UnityEngine;

public class Enemies : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float followDistance = 5f; // Distance at which the enemy starts following the player
    public float speed = 2f; // Speed of the enemy
    public float patrolRange = 5f; // Range within which the enemy patrols

    private Vector3 initialPosition; // Initial position of the enemy
    private bool isFollowingPlayer = false; // Flag to indicate if the enemy is following the player
    private SpriteRenderer spriteRenderer; // Reference to the sprite renderer component

    void Start()
    {
        initialPosition = transform.position; // Store initial position
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get the sprite renderer component
    }

    void Update()
    {
        // Check if the player is within follow distance
        if (Vector3.Distance(transform.position, player.position) < followDistance)
        {
            isFollowingPlayer = true;
        }
        else
        {
            isFollowingPlayer = false;
        }

        if (isFollowingPlayer)
        {
            // Move towards the player
            Vector3 direction = (player.position - transform.position).normalized;
            direction.y = 0; // Keep y-coordinate constant
            direction.z = 0; // Keep z-coordinate constant
            transform.position += direction * speed * Time.deltaTime;

            // Flip the sprite based on the direction
            if (direction.x > 0) // Moving right
            {
                spriteRenderer.flipX = false; // Set sprite renderer to not flip
            }
            else if (direction.x < 0) // Moving left
            {
                spriteRenderer.flipX = true; // Flip the sprite horizontally
            }
        }
        else
        {
            // Move back and forth within patrol range
            Vector3 targetPosition = initialPosition + new Vector3(Mathf.PingPong(Time.time * speed, patrolRange * 2) - patrolRange, 0, 0);
            targetPosition.y = transform.position.y; // Keep y-coordinate constant
            targetPosition.z = transform.position.z; // Keep z-coordinate constant
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            // Flip the sprite based on patrol direction
            if (targetPosition.x > transform.position.x) // Moving right
            {
                spriteRenderer.flipX = false; // Set sprite renderer to not flip
            }
            else if (targetPosition.x < transform.position.x) // Moving left
            {
                spriteRenderer.flipX = true; // Flip the sprite horizontally
            }
        }
    }
}
