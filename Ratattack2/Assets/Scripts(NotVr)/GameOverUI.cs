using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    public GameObject gameOverPanel; // Reference to the UI panel to display game over message
    public float gameOverDuration = 130f; // Duration after which game over panel appears
    private float elapsedTime;

    private void Start()
    {
        // Disable the game over panel initially
        gameOverPanel.SetActive(false);
        // Reset the timer
        elapsedTime = 0f;
    }

    private void Update()
    {
        // Update the timer
        elapsedTime += Time.deltaTime;

        // Check if it's time to show game over panel
        if (elapsedTime >= gameOverDuration)
        {
            ShowGameOver();
        }
    }

    // Call this method to show the game over panel
    public void ShowGameOver()
    {
        // Enable the game over panel
        gameOverPanel.SetActive(true);
    }

    // Call this method to hide the game over panel
    public void HideGameOver()
    {
        // Disable the game over panel
        gameOverPanel.SetActive(false);
    }
}
