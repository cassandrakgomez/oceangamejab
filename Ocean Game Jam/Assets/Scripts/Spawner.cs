using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject rockPrefab; // Rock prefab reference
    [SerializeField] float minSpawnRate = 0.3f; // Minimum spawn delay
    [SerializeField] float maxSpawnRate = 1.5f; // Maximum spawn delay

    private float spawnRate;
    private float timer = 0f;

    void Start()
    {
        spawnRate = Random.Range(minSpawnRate, maxSpawnRate); // Set initial random spawn rate
    }

    void SpawnRocks()
    {
        // Calculate screen bounds for spawning
        float screenHeight = Camera.main.orthographicSize * 2f; // Screen height
        float spawnY = Random.Range(-screenHeight / 2f, screenHeight / 2f); // Random Y within screen bounds
        float spawnX = Camera.main.transform.position.x + (Camera.main.aspect * Camera.main.orthographicSize); // Right edge

        Vector3 spawnPos = new Vector3(spawnX, spawnY, 0); // Final spawn position
        GameObject spawnedRock = Instantiate(rockPrefab, spawnPos, Quaternion.identity);

        // Add movement to the rock
        Rigidbody2D rb = spawnedRock.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = new Vector2(-2f, 0f); // Rocks glide leftwards
        }

        //Debug.Log($"Spawning rock at position: {spawnPos}");
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnRate)
        {
            SpawnRocks();
            timer = 0;
            spawnRate = Random.Range(minSpawnRate, maxSpawnRate); // Randomize next spawn time
        }
    }
}
