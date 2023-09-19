using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAiming : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    public Transform playerBody;

    private float xRotation = 0f;
    void Start()
    {
        mouseSensitivity = mouseSensitivity * 100;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update lis called once per frame
    void Update()
    {
        if(Cursor.lockState != CursorLockMode.Locked)
            Cursor.lockState = CursorLockMode.Locked;
        //mouse inputs
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //rotates camera up and down 
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90, 90); //makes sure camera doesn't go 360 degrees

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX); //moves body with the camera
        
    }
}
