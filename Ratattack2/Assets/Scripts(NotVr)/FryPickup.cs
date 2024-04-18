using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FryPickup : MonoBehaviour
{
    public AudioClip pickupSound; // Sound effect to play

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = pickupSound;
    }

    private void OnEnable()
    {
        // Subscribe to the interaction events
        GetComponent<XRGrabInteractable>().selectEntered.AddListener(OnPickup);
    }

    private void OnDisable()
    {
        // Unsubscribe from the interaction events
        GetComponent<XRGrabInteractable>().selectEntered.RemoveListener(OnPickup);
    }

    private void OnPickup(SelectEnterEventArgs args)
    {
        // Play the pickup sound effect
        audioSource.Play();

        // You can add any other logic here, like increasing score or removing the fry object
    }
}
