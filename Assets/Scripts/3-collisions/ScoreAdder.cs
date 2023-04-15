using UnityEngine;

/**
 * This component increases a given "score" field whenever it is triggered.
 */
public class ScoreAdder : MonoBehaviour {
    [Tooltip("Every object tagged with this tag will trigger adding score to the score field.")]
    [SerializeField] string triggeringTag;
    [SerializeField] NumberField scoreField;
    // [SerializeField] int pointsToAdd;

    private void OnTriggerEnter2D(Collider2D other) {
        var pointsToAdd = other.GetComponent<EnemyDestroyOnTrigger2D>();
        if (other.tag == triggeringTag && scoreField!=null && pointsToAdd) {
            scoreField.AddNumber(pointsToAdd.GetEnemyScore());
        }
    }

    public void SetScoreField(NumberField newTextField) {
        this.scoreField = newTextField;
    }
}
