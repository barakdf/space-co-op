﻿using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

/**
 * This component instantiates a given prefab at random time intervals and random bias from its object position.
 */
public class TimedSpawnerRandom: MonoBehaviour {
    [SerializeField] Mover[] prefabToSpawn;
    [SerializeField] Vector3 velocityOfSpawnedObjects;
    [Tooltip("Minimum time between consecutive spawns, in seconds")] [SerializeField] float minTimeBetweenSpawns = 1f;
    [Tooltip("Maximum time between consecutive spawns, in seconds")] [SerializeField] float maxTimeBetweenSpawns = 3f;
    [Tooltip("Maximum distance in X between spawner and spawned objects, in meters")] [SerializeField] float maxXDistance = 0.5f;

    
    void Start() {
         this.StartCoroutine(SpawnRoutine());    // co-routines
        // _ = SpawnRoutine();                   // async-await
    }



    IEnumerator SpawnRoutine() {    // co-routines
    // async Task SpawnRoutine() {  // async-await
        while (true) {
            float timeBetweenSpawnsInSeconds = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
            int randomIndexPickOfSpawners = (int)Random.Range(0, prefabToSpawn.Length);
            // Debug.Log("current index - " + randomIndexPickOfSpawners);
            yield return new WaitForSeconds(timeBetweenSpawnsInSeconds);       // co-routines
            // await Task.Delay((int)(timeBetweenSpawnsInSeconds*1000));       // async-await
            Vector3 positionOfSpawnedObject = new Vector3(
                transform.position.x + Random.Range(-maxXDistance, +maxXDistance),
                transform.position.y,
                transform.position.z);
            GameObject pickedSpawner = prefabToSpawn[randomIndexPickOfSpawners].gameObject;
            GameObject newObject = Instantiate(pickedSpawner, positionOfSpawnedObject, Quaternion.identity);
            int score = newObject.GetComponent<EnemyDestroyOnTrigger2D>().GetEnemyScore(); // Get the enemy score for the speed scale
            newObject.GetComponent<Mover>().SetVelocity(velocityOfSpawnedObjects*score);
        }
    }
}
