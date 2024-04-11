using UnityEngine;
using TMPro;

public class FryCollision : MonoBehaviour
{
    private int score = 0;
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        // Initialize the score to 0 at the start
        score = 0;
        UpdateScoreText();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collision is with an object named "rat"
        if (other.gameObject.CompareTag("rat"))
        {
            // Increment the score when a rat is destroyed
            score++;

            // Display the updated score
            UpdateScoreText();

            // Destroy the rat object
            Destroy(other.gameObject);
        }
    }

    // Update the score text
    private void UpdateScoreText()
    {
        // Update the score text with the current score value
        scoreText.text = "Score: " + score;
    }
}