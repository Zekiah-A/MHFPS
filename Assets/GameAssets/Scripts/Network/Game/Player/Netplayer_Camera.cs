using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Netplayer_Camera : Netplayer
{
    public static float Sensitivity = 200f;
    public Vector3 Offsets;
    public Vector3 FPOffsets;

    private float max_z;
    private RaycastHit hit;
    private float start_time;
    //private static Transform body;
    private static float x_rotation;

    public Netplayer_Camera() { return; }

    public void Start() 
    {
        body = Plr.GetComponent<Transform>();
        start_time = Time.time;
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
            CamTransform.localPosition = FPOffsets;
            //TODO: Toggle cursor lock.
        }
        else //TODO: FIX BODY NAME (CAPITAL)
        {
            x_rotation -= mouseY;
            x_rotation = Mathf.Clamp(x_rotation, -90f, 90f);

            if (Physics.Linecast(body.position, CamTransform.position, out hit))
            {
                Offsets.z += 0.01f; /*/ * Time.deltaTime; /*/
                CamTransform.localPosition = Offsets; /*/ /*/
            }
            else
            {
                ///CamTransform.localPosition = Offsets;
                //CamTransform.localPosition = Vector3.Lerp(CamTransform.localPosition, Offsets, 10f);
                if (Offsets.z >= -8f) //TODO: PROPER VAR
                    Offsets.z -= 0.01f;
                CamTransform.localPosition = Offsets;
            }

            Pivot.localRotation = Quaternion.Euler(x_rotation, 0f, 0f);
            body.Rotate(Vector3.up * mouseX);
        }
    }
}