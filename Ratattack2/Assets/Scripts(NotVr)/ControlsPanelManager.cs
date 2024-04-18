using UnityEngine;

public class ControlsPanelManager : MonoBehaviour
{
    public GameObject controlsPanel;
    public AudioSource clickSound; // Reference to the AudioSource component that will play the click sound

    // Method to toggle the visibility of the controls panel
    public void ToggleControlsPanel()
    {
        controlsPanel.SetActive(!controlsPanel.activeSelf);
        PlayClickSound(); // Call the method to play the click sound
    }

    // Method to hide the controls panel
    public void HideControlsPanel()
    {
        controlsPanel.SetActive(false);
        PlayClickSound(); // Call the method to play the click sound
    }

    // Method to play the click sound
    private void PlayClickSound()
    {
        if (clickSound != null)
        {
            clickSound.Play();
        }
    }
}
