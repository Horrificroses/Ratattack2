using UnityEngine;

public class RatSpawnManager : MonoBehaviour
{
    public GameObject ratPrefab; // Reference to the rat prefab
    public float spawnInterval = 5f; // Time interval between spawns
    public float destroyTime = 90f; // Time after which rats are destroyed

    private Transform spawnPoint;
    private float elapsedTime;

    private void Start()
    {
        // Find the spawn point by name (change "SpawnPoint" to match the actual name)
        spawnPoint = GameObject.Find("SpawnPoint").transform;

        // Start spawning rats
        InvokeRepeating("SpawnRat", 0f, spawnInterval);

        // Start the timer
        elapsedTime = 0f;
    }

    private void Update()
    {
        // Update the timer
        elapsedTime += Time.deltaTime;

        // Check if it's time to destroy rats and stop spawning
        if (elapsedTime >= destroyTime)
        {
            CancelInvoke("SpawnRat"); // Stop spawning
            DestroyRats(); // Destroy all rats
        }
    }

    private void SpawnRat()
    {
        // Instantiate a rat prefab at the spawn point position
        Instantiate(ratPrefab, spawnPoint.position, Quaternion.identity);
    }

    private void DestroyRats()
    {
        GameObject[] rats = GameObject.FindGameObjectsWithTag("rat");

        foreach (GameObject rat in rats)
        {
            Destroy(rat);
        }
    }
}
