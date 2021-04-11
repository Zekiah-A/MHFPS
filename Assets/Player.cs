using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject Plr;
    public Transform body;
    public Transform GroundCheck;
    public Transform CamTransform;
    //public Transform PlayerModel;
    public Transform Pivot;
    public CharacterController Controller;
    public LayerMask GroundMask;

    public static bool IsFirstPerson; //haha

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
       if(Input.GetKeyDown(KeyCode.C)) //change to getKeyDown
        {
            IsFirstPerson = !IsFirstPerson;
        }

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
