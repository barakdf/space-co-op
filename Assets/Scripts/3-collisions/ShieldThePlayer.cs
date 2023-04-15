using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class ShieldThePlayer : MonoBehaviour {
    [Tooltip("The state of the support spaceship abillity to shield the ally")] bool shield;
    [Tooltip("The number of seconds that the shield remains active")] [SerializeField] float duration;
    [SerializeField] shieldActivation playerOneShield;

    private void Start() {
        this.shield = true;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player" && shield) {
            Debug.Log("Shield triggered by player");
            var destroyComponent = other.GetComponent<DestroyOnTrigger2D>();
            // var shieldAnimation = other.GetComponent<SpawnShield>();
            // shieldAnimation.SetActive(false);

            if (destroyComponent) {
                destroyComponent.StartCoroutine(ShieldTemporarily(destroyComponent));        // co-routines
                    // NOTE: If you just call "StartCoroutine", then it will not work, 
                    //       since the present object is destroyed!
                // ShieldTemporarily(destroyComponent);                                      // async-await
                // Destroy(gameObject);  // Destroy the shield itself - prevent double-use
                shield = false;
            }
        } else {
            Debug.Log("Shield triggered by "+other.name);
        }
    }

    private IEnumerator ShieldTemporarily(DestroyOnTrigger2D destroyComponent) {   // co-routines
    // private async void ShieldTemporarily(DestroyOnTrigger2D destroyComponent) {      // async-await
        destroyComponent.enabled = false;
        playerOneShield.SetShield(true);
        for (float i = duration; i > 0; i--) {
            Debug.Log("Shield: " + i + " seconds remaining!");
            yield return new WaitForSeconds(1);       // co-routines
            // await Task.Delay(1000);                // async-await
        }
        Debug.Log("Shield gone!");
        destroyComponent.enabled = true;
        playerOneShield.SetShield(false);
        for (float i = 10; i > 0; i--) {
            Debug.Log("Shield abbility: " + i + " seconds remaining!");
            yield return new WaitForSeconds(1);       // co-routines
            // await Task.Delay(1000);                // async-await
        }
        this.shield = true;
    }
}
