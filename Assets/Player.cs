using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject Plr;
    public Transform GroundCheck;
    public Transform CamTransform;
    public CharacterController Controller;
    public LayerMask GroundMask;
    public Transform body;
    public static bool IsFirstPerson = true; //haha

    private const int max_speed = 10;
    private float current_velocity;

    public Player() { return; }

    void Start()
    {
        IsFirstPerson = false;
        body = Plr.GetComponent<Transform>(); //change to  editor
    } //REMOVE LATER

    void Update()
    {
        //if(Input.GetKey(KeyCode.C)) //change to getKeyDown
        //{
        //    IsFirstPerson = !IsFirstPerson;
        //}

    }

    public enum States
    {
        Walking,
        Running,
        Jumping,
        Crouching,
        Dead
    }

    public enum Attack
    {
        Punch,
        Kick,
        Stomp,
        Trick,
        Block
    }
}
