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
public class Netplayer_Actions : Netplayer
{
    public Dictionary<int, GameObject> Inventory = new Dictionary<int, GameObject>();

    private GameObject local_player;
    private bool can_punch;

    [SerializeField]
    float punch_distance;
    [SerializeField] 
    float punch_delay;

    void Start()
    {
        local_player = this.gameObject;
    }


    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Punch();
        }
    }

    void Punch() 
    {
        Debug.Log("Player punched");

        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit _hit, punch_distance/*, GroundMask*/))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * _hit.distance, Color.yellow, 0.2f); //0.2 for easier seeing
            Debug.Log($"Did Hit {_hit.transform.gameObject}");

            GameObject hitObject = _hit.transform.gameObject;
            PlayerManager hitManager = hitObject.GetComponent<PlayerManager>();
            if (hitManager != null)
            {
                //TODO: send new health to server, which will check CLient.Player.Health and update this for everyone
                ClientSend.PlayerDamageReceived();
            }
            
            //Hack: just to test.
            ClientSend.PlayerDamageReceived();
        }
    }

}
