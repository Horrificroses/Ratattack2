using UnityEngine;
using System.Collections.Generic;

public class NetCollision : MonoBehaviour
{
    public List<GameObject> rats;

    private void Start()
    {
        // Find all "rat" objects in the scene and add them to the list.
        GameObject[] ratArray = GameObject.FindGameObjectsWithTag("rat");
        rats.AddRange(ratArray);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("net"))
        {
            foreach (GameObject rat in rats)
            {
                // Check if the collided object is a "rat" object.
                if (other.gameObject == rat)
                {
                    // Destroy the "rat" object.
                    rats.Remove(rat);
                    Destroy(rat);
                    break; // Exit the loop since we found and destroyed the "rat" object.
                }
            }
        }
    }
}
