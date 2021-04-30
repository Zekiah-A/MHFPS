using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Netplayer_Movement : Player
{
    public float Speed = 12f;
    public float WalkSpeed = 12f;
    public float SprintSpeed = 16f;
    public float JumpHeight = 2f;

    public bool SocketConnected = false;

    private Vector3 velocity;
    private const float gravity = -19.62f;//-9.81f; /* More to simulate the charcters mass */
    private const float ground_distance = 0.4f;
    private bool is_grounded;

    void Update()
    {
        is_grounded = Physics.CheckSphere(GroundCheck.position, ground_distance, GroundMask);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (is_grounded)
        {
            if (velocity.y < 0)
                velocity.y = -2f;
            if (Input.GetButtonDown("Jump"))
                velocity.y = Mathf.Sqrt(JumpHeight * -2f * gravity);
            if (Input.GetKey(KeyCode.LeftShift)) //TODO: Change to the unity input system.
                Speed = SprintSpeed;
            else
                Speed = WalkSpeed;
        }
        else
        {
            x = x / 1.5f; z = z / 1.5f;
        }

        if (IsFirstPerson)
        {
            Vector3 toMove = transform.right * x + body.forward * z;
            Controller.Move(toMove * Speed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;
            Controller.Move(velocity * Time.deltaTime);
        }
        else
        {
            Vector3 toMove = transform.right * x + Pivot.forward * z;
            Controller.Move(toMove * Speed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;
            Controller.Move(velocity * Time.deltaTime);
        }

        //ClientSend.UpdateRotationReceived(this.transform.rotation);
    }

    void FixedUpdate()
    {
        try
        {
            ClientSend.UpdatePositionReceived(this.transform.position);
            ClientSend.UpdateRotationReceived(this.transform.rotation);
        }
        catch
        {
            Debug.Log("");
        }
    } 
    //TODO: Deal with sending this PROPERLY! (maybe on a separate 30 tick thread?)
    /*
    #region Packets
    public static void PlayerPositionUpdate(Vector3 _newPos)
    {

    }

    public static void PlayerRotationUpdate(Vector3 _newPos)
    {

    }
    #endregion
    */
}