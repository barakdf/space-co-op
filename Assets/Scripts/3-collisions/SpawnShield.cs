using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnShield : MonoBehaviour
{
    [Tooltip("Shield prefab")][SerializeField] GameObject prefabToSpawn;
    GameObject shield;
    bool enableShield = false;
    // Start is called before the first frame update
    void Start()
    {
        this.shield = spawnObject();
        enabled = false;
    }

    public void SetShield(bool state) {
        this.enableShield = state;
    }

    GameObject spawnObject() {
        Debug.Log("Spawning a new object");

        // Step 1: spawn the new object.
        Vector3 positionOfSpawnedObject = transform.position;  // span at the containing object position.
        Quaternion rotationOfSpawnedObject = Quaternion.identity;  // no rotation.
        GameObject newObject = Instantiate(prefabToSpawn, positionOfSpawnedObject, rotationOfSpawnedObject);

        return newObject;
    }

    private void Update() {
        // if (enableShield) {
        //     spawnObject();
        //     enableShield = false;
        // }
        // shield.transform = this.transform;
    }
}
