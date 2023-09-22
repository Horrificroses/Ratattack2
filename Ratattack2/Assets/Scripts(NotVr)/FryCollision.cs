using UnityEngine;

public class FryCollision : MonoBehaviour
{
    private int score = 0;

    private void Start()
    {
        // Initialize the score to 0 at the start
        score = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collision is with an object named "rat"
        if (other.gameObject.CompareTag("rat"))
        {
            // Increment the score when a rat is destroyed
            score++;

            // Display the updated score in the console
            Debug.Log("Score: " + score);

            // Destroy the rat object
            Destroy(other.gameObject);
        }
    }
}
