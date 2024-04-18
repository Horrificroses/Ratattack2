using UnityEngine;
using TMPro;

public class TimerDisplay : MonoBehaviour
{
    public float totalTime = 130f; // Total time for the timer in seconds
    private float currentTime; // Current time left
    public TextMeshProUGUI timerText; // Reference to the TextMeshProUGUI component

    void Start()
    {
        // Initialize current time to total time
        currentTime = totalTime;
    }

    void Update()
    {
        // Update the timer
        currentTime -= Time.deltaTime;

        // Display the time in minutes and seconds
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);

        // Update the TextMeshProUGUI component
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        // Check if the timer has reached zero
        if (currentTime <= 0)
        {
            // Timer has reached zero, you can add code here for what happens when the timer ends
            Debug.Log("Timer has reached zero!");
            // Optionally, stop the timer or reset it to some value
            // currentTime = 0;
        }
    }
}
