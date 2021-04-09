using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Camera : Player
{
    public static float Sensitivity = 100f;

    private static Transform body;
    private static float x_rotation;

    public Player_Camera() { return; }

    public void Start() 
    {
        body = Plr.GetComponent<Transform>();
    }

    public void Update()
    { 
        if(IsFirstPerson)
        {
            float mouseX = Input.GetAxis("Mouse X") * Sensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * Sensitivity * Time.deltaTime;

            x_rotation -= mouseY;
            x_rotation = Mathf.Clamp(x_rotation, -90f, 90f);

            CamTransform.localRotation = Quaternion.Euler(x_rotation, 0f, 0f);
            body.Rotate(Vector3.up * mouseX);
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}