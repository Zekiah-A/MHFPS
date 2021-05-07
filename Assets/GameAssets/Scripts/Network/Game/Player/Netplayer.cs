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

    public static int CurrentState { get; set; } //I need to do player actions, quick
    public static bool IsFirstPerson;

    private const int max_speed = 10;
    private float current_velocity;

    public Netplayer() { return; }

    void Start()
    {
        IsFirstPerson = false;
        CurrentState = (int)States.Idle;
        body = Plr.GetComponent<Transform>(); //change to  editor

        Cursor.lockState = CursorLockMode.Locked; //TODO: Beter cursor lock - janky fix
    }

    void Update()
    {
       if(Input.GetKeyDown(KeyCode.C)) //change to getKeyDown
        {
            IsFirstPerson = !IsFirstPerson;
        }
       if (Input.GetKeyDown(KeyCode.Escape))
       {
           Cursor.lockState = CursorLockMode.None; 
       }
       if (Input.GetKeyDown(KeyCode.Mouse0))
       {
            Cursor.lockState = CursorLockMode.Locked;
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
    } //TODO: move enum to be on it's own - ouside of class
}
