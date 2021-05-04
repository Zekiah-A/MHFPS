using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientSend : MonoBehaviour
{
    private static void SendTCPData(Packet _packet)
    {
        _packet.WriteLength();
        Client.instance.tcp.SendData(_packet);
    }

    private static void SendUDPData(Packet _packet)
    {
        _packet.WriteLength();
        Client.instance.udp.SendData(_packet);
    }

    #region Packets
    public static void WelcomeReceived()
    {
        using (Packet _packet = new Packet((int)ClientPackets.welcomeReceived))
        {
            _packet.Write(Client.instance.myId);
            _packet.Write(UiManager.instance.usernameField.text);

            SendTCPData(_packet);
        }
    }

    public static void UDPTestReceived()
    {
        using (Packet _packet = new Packet((int)ClientPackets.udpTestReceived))
        {
            _packet.Write("Received a UDP packet.");
            SendUDPData(_packet);
        } 
    }

    public static void UpdatePositionReceived(Vector3 _newPos)
    {
        using (Packet _packet = new Packet((int)ClientPackets.updatePositionReceived))
        {
            _packet.Write(_newPos);
            SendUDPData(_packet);
        }
    }

    public static void UpdateRotationReceived(Quaternion _newRot)
    {
        using (Packet _packet = new Packet((int)ClientPackets.updateRotationReceived))
        {
            _packet.Write(_newRot);
            SendUDPData(_packet); 
        }
    }

    public static void TextChatReceived(string _msg)
    {
        using (Packet _packet = new Packet((int)ClientPackets.textChatReceived))
        {   //write sender and message
            _packet.Write(UiManager.instance.usernameField.text); //TODO: make a dictionary or var for player names, this is stupid
            _packet.Write(_msg);
            SendUDPData(_packet);
        }
    }
    #endregion
}
