using UnityEngine;

public class PillSpawner : MonoBehaviour {
    [Header("Spawning Rules")]
    public GameObject pillPrefab;       // Drag your Pill_Pickup prefab here
    public Transform[] spawnPoints;     // A list of all your empty spawn locations

    public float spawnTimer = 5f;       // How many seconds between each spawn
    public int maxPillsOnMap = 5;       // Prevents the map from lagging if you miss pills

    private float currentTimer;

    void Start() {
        currentTimer = spawnTimer;
        SpawnRandomPill();
    }

    void Update() {
        // Count down the timer
        currentTimer -= Time.deltaTime;

        if (currentTimer <= 0) {
            // Reset the timer
            currentTimer = spawnTimer;

            // Check if we already have too many pills on the map
            // (We look for the Pill script to count them)
            Pill[] currentPills = FindObjectsOfType<Pill>();

            if (currentPills.Length < maxPillsOnMap) {
                SpawnRandomPill();
            }
        }
    }

    void SpawnRandomPill() {
        // Safety check: Make sure we actually added spawn points in the inspector
        if (spawnPoints.Length == 0) {
            Debug.LogWarning("No spawn points assigned to the spawner!");
            return;
        }

        // Pick a random number between 0 and the amount of spawn points we have
        int randomIndex = Random.Range(0, spawnPoints.Length);

        // Grab that specific spawn point
        Transform chosenSpot = spawnPoints[randomIndex];

        // Create the pill at that exact spot!
        Instantiate(pillPrefab, chosenSpot.position, Quaternion.identity);
    }
}