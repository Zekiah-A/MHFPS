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
 * |``¬¬¬                          |
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
        local_player = this.gameObject;
    }


    void Update()
    {
        switch(Netplayer.CurrentState)
        {
            case (int)Netplayer.States.Dead:
                can_punch = true;
                break;
            default:
                can_punch = false;
                break;
        }
    }

    void Punch() 
    { 
        
    }

    void PlayAnimation()
    {

    }
}
