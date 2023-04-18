using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRenderTexture : MonoBehaviour
{
    private Camera cameraComponent;
  

    private void Start()
    {
        cameraComponent = GetComponent<Camera>();
        
    }

    private void Update()
    {
   
        Debug.Log("Screen.width " + Screen.width);
        Debug.Log("Screen.height " + Screen.height);
    }
}
