using UnityEngine;

public class Ratmovement : MonoBehaviour
{
    public float moveSpeed = 10f; // Speed of movement
    public float changeInterval = 1f; // Interval to change direction

    private Vector3 randomDirection;
    private float timer;

    private void Start()
    {
        // Initialize the timer
        timer = changeInterval;

        // Start with a random direction
        randomDirection = GetRandomDirection();
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            // Change direction and reset the timer
            randomDirection = GetRandomDirection();
            timer = changeInterval;
        }

        // Calculate the new position
        Vector3 newPosition = transform.position + new Vector3(randomDirection.x, 0f, randomDirection.z) * moveSpeed * Time.deltaTime;

        // Check for collisions with walls or other objects
        Collider[] hitColliders = Physics.OverlapSphere(newPosition, 0.5f); // Adjust the radius as needed
        foreach (Collider collider in hitColliders)
        {
            if (collider.gameObject.CompareTag("Wall") || collider.gameObject.CompareTag("Obstacle"))
            {
                // Reverse the direction upon collision
                randomDirection = GetRandomDirection();
                break;
            }
        }

        // Apply the new position
        transform.position = newPosition;
    }

    private Vector3 GetRandomDirection()
    {
        // Generate a random direction
        return new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;
    }
}
