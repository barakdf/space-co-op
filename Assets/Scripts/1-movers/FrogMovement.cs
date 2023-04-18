using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FrogMovement : MonoBehaviour
{
    [Tooltip("Step size in meters")] [SerializeField] float speed = 1f;

    [SerializeField]
    InputAction moveUp = new InputAction(type: InputActionType.Button);

    [SerializeField]
    InputAction moveDown = new InputAction(type: InputActionType.Button);

    [SerializeField]
    InputAction moveLeft = new InputAction(type: InputActionType.Button);

    [SerializeField]
    InputAction moveRight = new InputAction(type: InputActionType.Button);

    // Update is called once per frame

    void OnEnable() {
        moveUp.Enable();
        moveDown.Enable();
        moveLeft.Enable();
        moveRight.Enable();    
    }

    void OnDisable() {
        moveUp.Disable();
        moveDown.Disable();
        moveLeft.Disable();
        moveRight.Disable();
    }
    void Update() {
        if(moveUp.IsPressed()) {
            transform.position += new Vector3(0,speed * Time.deltaTime,0);
        } else if (moveDown.IsPressed()) {
            transform.position += new Vector3(0, -Time.deltaTime, 0);
        } else if (moveLeft.IsPressed()) {
           transform.position += new Vector3(-Time.deltaTime, 0, 0);
        }
        else if(moveRight.IsPressed()) {
            transform.position += new Vector3(Time.deltaTime, 0, 0);
        }
    }
}
