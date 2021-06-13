using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public int id;
    public string username;
    public float health;
    public bool isDead;

    public TextMeshPro healthbar;


    /// <summary> Handling a player being damaged event. </summary>
    /// <param name="sender">Sender.</param>
    /// <param name="a">arguments for the event.</param>
    void HandleCustomEvent(object sender, PlayerDamageArgs args)
    {
        Debug.Log($"Event called and intercepted, {args}.");
    }
}