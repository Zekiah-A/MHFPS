using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Netrigid : MonoBehaviour
{
    public int RigidID;

    ///<summary>Sign this rigidbody object with the game manager</summary>
    void Awake()
    {
        GameManager.rigidbodies.Add(RigidID, this);
    }

    //TODO: "OnHit" is ___WAY___ more efficient.
    void FixedUpdate()
    {
        ///<summary>Send loc, rot and this object ID at once by passing onto clientsend</summary>
        ClientSend.RigidUpdateReceived(RigidID, this.transform.position);
    }
}
