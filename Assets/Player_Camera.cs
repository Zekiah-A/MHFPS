using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Camera : Player
{
    public static float Sensitivity = 100f;

    private static Transform Body;
    private static float xRotation;

    public Player_Camera() { return; }

    public void Start() 
    {
        Body = Plr.GetComponent<Transform>();
    }

    public void Update()
    { 
        if(IsFirstPerson)
        {
            float mouseX = Input.GetAxis("Mouse X") * Sensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * Sensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            CamTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            Body.Rotate(Vector3.up * mouseX);
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}