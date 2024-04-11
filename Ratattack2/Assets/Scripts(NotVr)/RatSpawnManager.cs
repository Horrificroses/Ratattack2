// RatSpawnManager.cs
using UnityEngine;

public class RatSpawnManager : MonoBehaviour
{
    public GameObject ratPrefab; // Reference to the rat prefab
    public float spawnInterval = 5f; // Time interval between spawns
    public float destroyTime = 10f; // Time after which rats are destroyed
    public float spawnHalfSize = 0.5f; // Half-size of the spawn area in the X and Z dimensions
    public float spawnYPosition = 3.45f; // Fixed Y-axis position for spawning

    private float elapsedTime;

    private void Start()
    {
        // Start spawning rats
        InvokeRepeating("SpawnRat", 0f, spawnInterval);

        // Start the timer
        elapsedTime = 0f;

        // Schedule the rats disappearance after the specified time
        Invoke("DisappearRats", destroyTime);
    }

    private void Update()
    {
        // Update the timer
        elapsedTime += Time.deltaTime;
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

    private void DisappearRats()
    {
        GameObject[] rats = GameObject.FindGameObjectsWithTag("rat");

        foreach (GameObject rat in rats)
        {
            Destroy(rat);
        }
    }
}
