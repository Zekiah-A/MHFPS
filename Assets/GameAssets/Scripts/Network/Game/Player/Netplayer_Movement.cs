using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Netplayer_Movement : MonoBehaviour
{
    public float Speed = 12f;
    public bool SocketConnected = false;

    public const float WALKSPEED = 12f;
    public const float SPRINTSPEED = 16f;
    public const float JUMPHEIGHT = 20f;

    private const float gravity = -9.81f;
    private const float ground_distance = 0.4f;

    private Vector3 velocity;
    private bool is_grounded;

    void Update()
    {
        is_grounded = Physics.CheckSphere(Netplayer.instance.GroundCheck.position, ground_distance, Netplayer.instance.GroundMask);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (is_grounded)
        {
            if (velocity.y < 0)
            {
                velocity.y = -2f;
            }

            if (Input.GetButtonDown("Jump"))
            {
                velocity.y = Mathf.Sqrt(JUMPHEIGHT * -2f * gravity);
                Netplayer.CurrentState = (int)Netplayer.States.Jumping;
            }

            if (Input.GetKey(KeyCode.LeftShift)) //TODO: Change to the unity input system.
            {
                Speed = SPRINTSPEED;
                Netplayer.CurrentState = (int)Netplayer.States.Running;
            }
            else
            {
                Speed = WALKSPEED;
                Netplayer.CurrentState = (int)Netplayer.States.Walking;
            }
        }
        else
        {
            x = x / 1.5f; z = z / 1.5f;
        }

        if (Netplayer.IsFirstPerson)
        {
            Vector3 toMove = transform.right * x + Netplayer.instance.body.forward * z;
            Netplayer.instance.Controller.Move(toMove * Speed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;
            Netplayer.instance.Controller.Move(velocity * Time.deltaTime);
        }
        else
        {
            Vector3 toMove = transform.right * x + Netplayer.instance.Pivot.forward * z;
            Netplayer.instance.Controller.Move(toMove * Speed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;
            Netplayer.instance.Controller.Move(velocity * Time.deltaTime);
        }
        UpdatePosition();
    }

    void UpdatePosition()
    {
            ClientSend.UpdatePositionReceived(this.transform.position);
            ClientSend.UpdateRotationReceived(this.transform.rotation);
    } 
    //TODO: Deal with sending this PROPERLY! (maybe on a separate 30 tick thread?)
}