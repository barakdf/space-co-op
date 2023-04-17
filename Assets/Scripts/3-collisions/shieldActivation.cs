using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldActivation : MonoBehaviour
{
    private void Start() {
        this.gameObject.SetActive(false);
    }
    public void SetShield(bool state) {
        this.gameObject.SetActive(state);
        Debug.Log("Player One Shield state is - " + enabled);
    }
}
