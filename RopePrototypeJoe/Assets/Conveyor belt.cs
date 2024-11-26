using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyorbelt : MonoBehaviour
{
    public GameObject collectablePrefab; // Assign the Collectables prefab here
    public Transform spawnPoint; // Point where collectables spawn (off-screen to the left)
    public float moveSpeed = 2f; // Speed at which the collectables move
    public float spawnInterval = 2f; // Interval between spawning collectables
    private float timeSinceLastSpawn = 0f; // Tracks time since the last spawn


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Accumulate time
        timeSinceLastSpawn += Time.deltaTime;

        // Check if enough time has passed to spawn the next collectable
        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnCollectable();
            timeSinceLastSpawn = 0f; // Reset the timer after spawning
        }
    }

    void SpawnCollectable()
    {

        // Adjust spawn position to be above the conveyor belt sprite (spawn above the spawnPoint)
        Vector3 spawnPosition = spawnPoint.position;
        spawnPosition.y += 1f; // Adjust this value to control how far above the sprite the collectable spawns

        // Instantiate a new collectable prefab at the spawn point
        GameObject newCollectable = Instantiate(collectablePrefab, spawnPoint.position, Quaternion.identity);

        // Access the Collectables script and initialize it
        Collectables mover = newCollectable.GetComponent<Collectables>();
        if (mover != null)
        {
            mover.Initialize(moveSpeed); // Pass the speed to the collectable
        }
        else
        {
            Debug.LogError("Collectables script not found on the prefab!");
        }
    }

}
