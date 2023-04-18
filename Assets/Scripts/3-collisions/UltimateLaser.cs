using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UltimateLaser : MonoBehaviour
{
    [Tooltip("The state of the support spaceship abillity to shield the ally")] bool ultReady;
    [Tooltip("The number of seconds that the shield remains active")] [SerializeField] float duration;

    [SerializeField] CircleAnim UltLaserTimer;

    [SerializeField] InputAction activateAbility = new InputAction(type: InputActionType.Button);

    private void Start() {
        this.ultReady = true;
    }

        void OnEnable()  {
        activateAbility.Enable();
        
    }

    void OnDisable()  {
        activateAbility.Disable();
        
    }

    private void LaserUlt() {
        if (ultReady) {
            Debug.Log("Shield triggered by player");
            var LaserShoot = gameObject.GetComponent<LaserShooter>();
            // var shieldAnimation = other.GetComponent<SpawnShield>();
            // shieldAnimation.SetActive(false);

            if (LaserShoot) {
                LaserShoot.StartCoroutine(EnableUltLaser(LaserShoot));        // co-routines

                ultReady = false;
            }
        }
    }

    private IEnumerator EnableUltLaser(LaserShooter laserShoot) {   // co-routines
    // private async void ShieldTemporarily(DestroyOnTrigger2D destroyComponent) {      // async-await
        laserShoot.SetAbility(true);
        UltLaserTimer.resetCircle();
        for (float i = duration; i > 0; i--) {
            Debug.Log("LaserUlt: " + i + " seconds remaining!");
            yield return new WaitForSeconds(1);       // co-routines
            // await Task.Delay(1000);                // async-await
        }
        laserShoot.SetAbility(false);
        
        for (float i = 10; i > 0; i--) {
            Debug.Log("Shield abbility: " + i + " seconds remaining!");
            yield return new WaitForSeconds(1);       // co-routines
            // await Task.Delay(1000);                // async-await
        }
        UltLaserTimer.SetCircleColor(true);
        this.ultReady = true;
    }

    private void Update() {
        if(activateAbility.WasPressedThisFrame()) {
            LaserUlt();
        }
    }
}
