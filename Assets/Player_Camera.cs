using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Camera : Player
{
    public static float Sensitivity = 200f;
    public Vector3 Offsets;
    public Vector3 FPOffsets;

    private float max_z;
    private RaycastHit hit;
    private float start_time;
    //private static Transform body;
    private static float x_rotation;

    public Player_Camera() { return; }

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
            Cursor.lockState = CursorLockMode.Locked;
        }
        else //TODO: FIX BODY NAME (CAPITAL)
        {
            x_rotation -= mouseY;
            x_rotation = Mathf.Clamp(x_rotation, -90f, 90f);

            if (Physics.Linecast(body.position, CamTransform.position, out hit))
            {
                ///CamTransform.localPosition = new Vector3(Offsets.x, Offsets.y, -Vector3.Distance(body.position, hit.point));
                //var moveTo = new Vector3(Offsets.x, Offsets.y, -Vector3.Distance(body.position, hit.point));
                //CamTransform.localPosition = Vector3.Lerp(CamTransform.localPosition, moveTo, 10f);
                Offsets.z += 0.01f; /*/ * Time.deltaTime; /*/
                CamTransform.localPosition = Offsets; /*/ /*/
            }
            else
            {
                ///CamTransform.localPosition = Offsets;
                //CamTransform.localPosition = Vector3.Lerp(CamTransform.localPosition, Offsets, 10f);
                if (Offsets.z >= -8f)
                    Offsets.z -= 0.01f;
                CamTransform.localPosition = Offsets; /*/ /*/
            }

            Pivot.localRotation = Quaternion.Euler(x_rotation, 0f, 0f);
            body.Rotate(Vector3.up * mouseX);
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}