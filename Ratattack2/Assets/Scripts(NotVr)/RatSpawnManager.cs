using UnityEngine;

public class RatSpawnManager : MonoBehaviour
{
    public GameObject ratPrefab; // Reference to the rat prefab
    public float spawnInterval = 5f; // Time interval between spawns
    public float destroyTime = 90f; // Time after which rats are destroyed
    public float spawnHalfSize = 0.5f; // Half-size of the spawn area in the X and Z dimensions
    public float spawnYPosition = 3.45f; // Fixed Y-axis position for spawning

    private float elapsedTime;

    private void Start()
    {
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
        // Generate random spawn positions within the specified area
        float randomX = Random.Range(-spawnHalfSize, spawnHalfSize);
        float randomZ = Random.Range(-spawnHalfSize, spawnHalfSize);

        // Set the Y-coordinate to the desired spawnYPosition
        Vector3 spawnPosition = new Vector3(randomX, spawnYPosition, randomZ);

        // Instantiate a rat prefab at the spawn position
        Instantiate(ratPrefab, spawnPosition, Quaternion.identity);
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
