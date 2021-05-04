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
    //TODO: Smoothly lerp/translate between positions (since we only get updates 30 times/sec)
    public static void PlayerPosition(Packet _packet)
    {
        int _toPlayer = _packet.ReadInt(); 
        Vector3 _newPos = _packet.ReadVector3();
        Debug.Log($"Player: { _toPlayer} has moved to: { _newPos}");

        foreach (PlayerManager _player in GameManager.players.Values)
        {
            if (_player.id == _toPlayer) //TODO: (if we have found the recipient with foreach) - this is slow, go direct and move them!
            {
                Debug.Log($"{_player.username} moved to {_newPos}");

                GameObject _plrObj = GameManager.players[_player.id].gameObject;
                _plrObj.transform.position = _newPos;
                //TODO: _plrObj.transform.localPosition = Vector3.MoveTowards(_plrObj.transform.localPosition, _newPos, Time.deltaTime * _plrMovement.Speed);
                break;
            }
        }   
    }
    //TODO: Smoothly rotate to new position.
    public static void PlayerRotation(Packet _packet)
    {
        int _toPlayer = _packet.ReadInt(); 
        Quaternion _newRot = _packet.ReadQuaternion();
        Debug.Log($"Player: { _toPlayer} has rotated to: { _newRot}");

        foreach (PlayerManager _player in GameManager.players.Values)
        {
            if (_player.id == _toPlayer) //TODO: (if we have found the recipient with foreach) - this is slow, go direct and move them!
            {
                Debug.Log($"{_player.username} rotated to {_newRot}");

                GameObject _plrObj = GameManager.players[_player.id].gameObject;
                _plrObj.transform.rotation = _newRot;
                break;
            }
        }
    }

    public static void TextChat(Packet _packet)
    {
        //TODO: call send to chat function for this player (local)!
        int _sender = _packet.ReadInt();
        string _msg = _packet.ReadString(); //this may actually be the wrong way round, let's see
        Debug.Log(_msg);

        //Netplayer_HUD.Chat.
    }
}
