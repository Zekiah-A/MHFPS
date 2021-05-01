using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Netplayer : MonoBehaviour
{
    public Netplayer instance;

    public GameObject Plr;
    public Transform body;
    public Transform GroundCheck;
    public Transform CamTransform;
    public Transform Pivot;
    public CharacterController Controller;
    public LayerMask GroundMask;

    public static int CurrentState { get; set; }
    public static bool IsFirstPerson; //TODO: Use static to hide from other classes

    private const int max_speed = 10;
    private float current_velocity;

    public Netplayer() { return; }

    void Start()
    {
        IsFirstPerson = false;
        CurrentState = (int)States.Idle;
        body = Plr.GetComponent<Transform>(); //change to  editor
    } //REMOVE LATER

    void Update()
    {
       if(Input.GetKeyDown(KeyCode.C)) //change to getKeyDown
        {
            IsFirstPerson = !IsFirstPerson;
        }

    }

    public enum States
    {
        Idle,
        Walking,
        Running,
        Jumping,
        Crouching,
        Dead
    }
    /*
    public enum Attack
    {
        Punch,
        Kick,
        Stomp,
        Trick,
        Block
    }
    */
}
