using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float speed = 3.5f; // Speed of the enemy
    public float stoppingDistance = 2.0f; // Distance at which the enemy stops chasing
    public float detectionRadius = 10.0f; // Radius within which the enemy can detect the player

    private Rigidbody rb; // Reference to the Rigidbody component

    private void Start()
    {
        // Get the Rigidbody component
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Check if the player is assigned
        if (player != null)
        {
            // Calculate the distance to the player
            float distance = Vector3.Distance(transform.position, player.position);

            // Check if the player is within the detection radius
            if (distance <= detectionRadius)
            {
                // If the player is outside the stopping distance, move towards the player
                if (distance > stoppingDistance)
                {
                    ChasePlayer();
                }
            }
        }
    }

    private void ChasePlayer()
    {
        // Calculate the direction to the player
        Vector3 direction = (player.position - transform.position).normalized;

        // Calculate the desired velocity
        Vector3 desiredVelocity = direction * speed;

        // Apply the desired velocity to the Rigidbody
        rb.linearVelocity = new Vector3(desiredVelocity.x, rb.linearVelocity.y, desiredVelocity.z);

        // Optionally, rotate the enemy to face the player
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}