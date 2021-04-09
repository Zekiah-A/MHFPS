using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : Player
{
    public float Speed = 12f;
    public float JumpHeight = 5f;
    public LayerMask ground_mask;

    private Transform body;
    private Vector3 velocity;
    private const float gravity = -9.81f;
    private const float ground_distance = 0.4f;
    private bool is_grounded;

    void Start()
    {
        body = Plr.GetComponent<Transform>();
    }

    void Update()
    {
        is_grounded = Physics.CheckSphere(GroundCheck.position, ground_distance, ground_mask);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (is_grounded)
        {
            if (velocity.y < 0)
            {
                velocity.y = -2f;
            }

            if(Input.GetButtonDown("Jump"))
            {
                velocity.y = Mathf.Sqrt(JumpHeight * -2f * gravity);
            }
        } else
        {
            x = x / 1.5f; z = z / 1.5f;
        }

        Vector3 toMove = transform.right * x + body.forward * z;
        Controller.Move(toMove * Speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        Controller.Move(velocity * Time.deltaTime);
    }
}
