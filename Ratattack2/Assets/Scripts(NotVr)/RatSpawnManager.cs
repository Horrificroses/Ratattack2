using UnityEngine;

public class RatSpawnManager : MonoBehaviour
{
    public GameObject ratPrefab; // Reference to the rat prefab
    public float spawnInterval = 5f; // Time interval between spawns
    public float destroyTime = 90f; // Time after which rats are destroyed (changed to 90 seconds)
    public float spawnHalfSize = 0.5f; // Half-size of the spawn area in the X and Z dimensions
    public float spawnYPosition = 3.45f; // Fixed Y-axis position for spawning
    public GameObject spawnPoint; // Reference to the spawn point game object

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

        // Check if it's time to make rats disappear
        if (elapsedTime >= destroyTime)
        {
            DisappearRats();
            // Destroy the spawn point to stop rats from spawning
            DestroySpawnPoint();
            // Reset the timer
            elapsedTime = 0f;
        }
    }

    private void SpawnRat()
    {
        // Check if elapsed time exceeds 130 seconds, if so, stop spawning rats
        if (elapsedTime > 130f)
        {
            return;
        }

        // Generate random spawn positions within the specified area
        float randomX = Random.Range(-spawnHalfSize, spawnHalfSize);
        float randomZ = Random.Range(-spawnHalfSize, spawnHalfSize);

        // Set the Y-coordinate to the desired spawnYPosition
        Vector3 spawnPosition = new Vector3(randomX, spawnYPosition, randomZ);

        // Instantiate a rat prefab at the spawn position
        Instantiate(ratPrefab, spawnPosition, Quaternion.identity);
    }

    private void DisappearRats()
    {
        GameObject[] rats = GameObject.FindGameObjectsWithTag("rat");

        foreach (GameObject rat in rats)
        {
            Destroy(rat);
        }
    }

    private void DestroySpawnPoint()
    {
        // Destroy the spawn point to stop rats from spawning
        Destroy(spawnPoint);
    }
}
