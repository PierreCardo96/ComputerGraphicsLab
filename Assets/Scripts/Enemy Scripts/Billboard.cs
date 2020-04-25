using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Camera playerCamera;

    private void Start()
    {
        playerCamera = Camera.main;
    }

    private void LateUpdate()
    {
        LookAtPlayer();
    }

    private void LookAtPlayer()
    {
        //Look in the same direction of the camera
        transform.LookAt(transform.position + playerCamera.transform.forward);
    }
}
