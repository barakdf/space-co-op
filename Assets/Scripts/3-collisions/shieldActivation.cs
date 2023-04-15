using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldActivation : MonoBehaviour
{
    public void SetShield(bool state) {
        this.gameObject.SetActive(state);
        Debug.Log("Player One Shield state is - " + enabled);
    }
}
