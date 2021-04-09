using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : Player
{
    public float speed = 12f;

    private Transform Body;

    void Start()
    {
        Body = Plr.GetComponent<Transform>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 toMove = transform.right * x + Body.forward * z;

        Controller.Move(toMove * speed * Time.deltaTime);
    }
}
