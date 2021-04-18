using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class ClientHandle : MonoBehaviour
{
    public static void Welcome(Packet _packet)
    {
        string _msg = _packet.ReadString();
        int _myId = _packet.ReadInt();

        Debug.Log($"Message from server: {_msg}");
        Client.instance.myId = _myId;
        ClientSend.WelcomeReceived();

        Client.instance.udp.Connect(((IPEndPoint)Client.instance.tcp.socket.Client.LocalEndPoint).Port);
    }

    public static void SpawnPlayer(Packet _packet)
    {
        int _id = _packet.ReadInt();
        string _username = _packet.ReadString();
        Vector3 _position = _packet.ReadVector3();
        Quaternion _rotation = _packet.ReadQuaternion();

        GameManager.instance.SpawnPlayer(_id, _username, _position, _rotation);
    }

    public static void UDPTest(Packet _packet)
    {
        string _msg = _packet.ReadString();

        Debug.Log($"Received packet via UDP. Contains message: {_msg}");
        ClientSend.UDPTestReceived();
    }

    public static void PlayerPosition(Packet _packet)
    {
        int _toPlayer = _packet.ReadInt(); //i removed this :thinking: i need it!
        Vector3 _newPos = _packet.ReadVector3();
        Debug.Log($"Player: { _toPlayer} has moved to: { _newPos}");
        ///<sumary>Testing</sumary>
        /////////////////////////////////////////////////////////////////////////////////////////////////////
        foreach (PlayerManager _player in GameManager.players.Values) // "playermanager" is not plr lol
        {
            if (_player.id == _toPlayer) //TODO: (if we have found the recipient with foreach) - this is slow, go direct and move them!
            {
                //Debug.Log($"This is the guy! toplayer: {_toPlayer}, manager: {_player} managerID: {_player.id}");
                Debug.Log($"{_player.username} moved to {_newPos}");

                //TODO: Hmmm
                GameObject _plrObj = GameManager.players[_player.id].gameObject;
                _plrObj.transform.position = _newPos;
            }
            /*
            else //I COULD JUST USE Client.instance.id since THIS is on the player
            {
                Debug.Log(""); //Foreach got the wrong dude
            }
            */
        }   
    }

    public static void  PlayerRotation(Packet _packet)
    {
        int _toPlayer = _packet.ReadInt(); //actually id but i'm confused  
        Vector3 _newRot = _packet.ReadVector3();
        Debug.Log($"Player: { _toPlayer} has rotated to: { _newRot}");
        //for each player on the server, (Player _player in Player), look for one with maching ID
        //if matching foun, move THEM
        /*
        for (int i = 0; i <= GameManager.players.Values; i++)
        {

        }
        */
        foreach (PlayerManager _player in GameManager.players.Values) // "playermanager" is now plr lol
        {
            Debug.Log("It's working so far!"); //Just for testing for now! 
        }

        GameManager.players.TryGetValue(_toPlayer, out PlayerManager _plrManager);
        if (_plrManager != null)
            Debug.Log(_plrManager);
        else
            Debug.Log("No plr managers found");
    }
}
