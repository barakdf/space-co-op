using UnityEngine;

/**
 * This component spawns the given laser-prefab whenever the player clicks a given key.
 * It also updates the "scoreText" field of the new laser.
 */
public class LaserShooter: ClickSpawner {
    [SerializeField] NumberField scoreField;
    Vector3 OriginalVelocity;
    bool ability = false;

    private void Start() {
        OriginalVelocity = new Vector3(base.velocityOfSpawnedObject.x, base.velocityOfSpawnedObject.y, base.velocityOfSpawnedObject.z);
    }
    public void SetAbility(bool state) {
        ability = state;
    }

    protected override GameObject spawnObject() {
        GameObject newObject = base.spawnObject();  // base = super
        // Modify the text field of the new object.
        ScoreAdder newObjectScoreAdder = newObject.GetComponent<ScoreAdder>();
        if (newObjectScoreAdder)
            newObjectScoreAdder.SetScoreField(scoreField);

        return newObject;
    }

        private void Update() {
        if (spawnAction.WasPressedThisFrame()) {
            if(gameObject.tag == "Player1" && ability) {
                base.velocityOfSpawnedObject.x = -7;
                spawnObject();
                base.velocityOfSpawnedObject.x = 7;
                spawnObject();
                base.velocityOfSpawnedObject.x = 0;
                spawnObject();
            } else {
                spawnObject();
            }
        }

    }
}
