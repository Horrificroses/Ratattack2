using UnityEngine;

public class RatSpinner : MonoBehaviour
{
    public float spinSpeed = 5f; // Adjust the speed of spinning

    void Update()
    {
        // Rotate the rat around its up axis
        transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
    }
}
