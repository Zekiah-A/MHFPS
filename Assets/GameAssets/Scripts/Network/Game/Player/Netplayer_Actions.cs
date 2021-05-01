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
 * |                          |
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

    void Start()
    {
        //CurrentState = (int)Netplayer.States.Idle;
        local_player = this.gameObject;
    }


    void Update()
    {
        if (Netplayer.CurrentState != (int)Netplayer.States.Dead)
        {
            can_punch = true;
        }
        else
        {
            can_punch = false;
        }
    }

    void Punch() 
    { 
        
    }

    void PlayAnimation()
    {

    }
}
