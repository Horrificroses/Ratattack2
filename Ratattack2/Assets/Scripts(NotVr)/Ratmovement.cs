using UnityEngine;

public class Ratmovement : MonoBehaviour
{
    public float moveSpeed = 10f; // Speed of movement
    public float changeInterval = 1f; // Interval to change direction

    private Vector3 randomDirection;
    private float timer;
    private bool isFacingRight = true;
    private Transform ratTransform;

    private void Start()
    {
        // Initialize the timer
        timer = changeInterval;

        // Start with a random direction
        randomDirection = GetRandomDirection();

        // Get the rat's transform component
        ratTransform = transform;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            // Change direction and reset the timer
            randomDirection = GetRandomDirection();
            timer = changeInterval;

            // Check and adjust the rat's facing direction
            if (randomDirection.x < 0 && isFacingRight)
            {
                Flip();
            }
            else if (randomDirection.x > 0 && !isFacingRight)
            {
                Flip();
            }
        }

        // Calculate the new position
        Vector3 newPosition = ratTransform.position + randomDirection * moveSpeed * Time.deltaTime;

        // Check for collisions with obstacles
        Collider[] hitColliders = Physics.OverlapSphere(newPosition, 0.5f); // Adjust the radius as needed
        foreach (Collider collider in hitColliders)
        {
            if (collider.gameObject.CompareTag("Obstacle"))
            {
                // Reverse the direction upon collision
                randomDirection = GetRandomDirection();
                break;
            }
        }

        // Apply the new position
        ratTransform.position = newPosition;
    }

    private Vector3 GetRandomDirection()
    {
        // Generate a random direction
        return new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;
    }

    private void Flip()
    {
        // Reverse the rat's facing direction
        isFacingRight = !isFacingRight;

        // Rotate the rat 180 degrees around the Y-axis
        ratTransform.Rotate(0f, 180f, 0f);
    }
}