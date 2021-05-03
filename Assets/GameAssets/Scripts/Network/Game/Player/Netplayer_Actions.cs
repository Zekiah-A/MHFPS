using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*  __________________________
 * |Abilities                 |
 * |¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯|
 * |R - Reload                |
 * |F - Punch / Initiate fight|
 * |T - Stomp                 |
 * |G - Countermitz           |
 * |``¬¬¬                     |
 * |                          |
 * |                          |
 * |                          |
 *  ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
 */
public class Netplayer_Actions : Player
{
    //public Dictionary<int, string> Inventory = new Dictionary<int, string>();

    private GameObject local_player;
    private bool can_punch;

    [SerializeField] float punch_distance;
    [SerializeField] float punch_delay;

    void Start()
    {
        local_player = this.gameObject;
    }


    void Update()
    {
        //switch(Netplayer.CurrentState)
        //{
        //    case (int)Netplayer.States.Dead:
        //        can_punch = false;
        //        break;
        //    default:
        //        can_punch = false;
        //        break;
        //}
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Player punched");


            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit _hit, punch_distance, GroundMask))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * _hit.distance, Color.yellow, 0.2f); //0.2 for easier seeing
                Debug.Log($"Did Hit {_hit.transform.gameObject}");

                GameObject hitObject = _hit.transform.gameObject;                
                if (hitObject.GetComponent<Player>()) //if is player
                {

                }
            }
        }
                //cast ray
    }

    void Punch() 
    { 
        
    }

    void PlayAnimation()
    {

    }
}
