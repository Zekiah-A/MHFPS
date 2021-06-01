using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Netrigid : MonoBehaviour
{
    public int RigidID;

    // Start is called before the first frame update
    void Start()
    {
        GameObject thisobject = gameObject;
    }
    //TODO: "OnHit" is ___WAY___ more efficient.
    void FixedUpdate()
    {
        ///<summary>Send loc, rot and this object ID at once by passing onto clientsend</summary>
        ClientSend.RigidUpdateReceived(RigidID, this.transform.position);
    }
}
