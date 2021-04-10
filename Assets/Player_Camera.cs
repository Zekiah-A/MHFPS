using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Camera : Player
{
    public static float Sensitivity = 200f;
    public Vector3 Offsets;

    private float max_z;
    private RaycastHit hit;
    //private static Transform body;
    private static float x_rotation;

    public Player_Camera() { return; }

    public void Start() 
    {
        body = Plr.GetComponent<Transform>();
        max_z = Offsets.z;

        CamTransform.localPosition = Offsets; //DELETE!
    }

    public void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * Sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * Sensitivity * Time.deltaTime;

        if (IsFirstPerson)
        {
            x_rotation -= mouseY;
            x_rotation = Mathf.Clamp(x_rotation, -90f, 90f);

            CamTransform.localRotation = Quaternion.Euler(x_rotation, 0f, 0f);
            body.Rotate(Vector3.up * mouseX);
            Cursor.lockState = CursorLockMode.Locked;
        }
        else //TODO: FIX BODY NAME (CAPITAL)
        {
            /*
            if(Physics.CheckSphere(CamTransform.position, 0.5f, GroundMask))
            {
                Offsets.z += 1f;
            } else {
                if(Mathf.Floor(Offsets.z) >= max_z)
                {
                    Offsets.z -= 1f;
                }
            }
            CamTransform.localPosition = Offsets; 
            */

            if (Physics.Linecast(body.position, CamTransform.position, out hit))
            {
                CamTransform.localPosition = new Vector3(Offsets.x, Offsets.y, -Vector3.Distance(body.position, hit.point));
            }
            else
            {
                CamTransform.localPosition = Offsets;
            }

            CamTransform.localRotation = Quaternion.Euler(x_rotation, 0f, 0f);
            body.Rotate(Vector3.up * mouseX);
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}