using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Netplayer_HUD : MonoBehaviour
{
    public static Netplayer_HUD instance;

    public InputField InputField;
    //public Button SubmitButton;
    public Text ChatboxText;

    public Netplayer_HUD()
    {
        instance = this;
        return;
    }

    #region CHAT

    public Dictionary<PlayerManager, string> ChatMessages;

    ///<summary>Update gui with new chat from server. Called from client handle.</summary>
    public void UpdateTextChat(string _msg) => ChatboxText.text += $"\n" + _msg;

    ///<summary>Send to server (through clientsend), which will return this message moderated, and send to all other players. Called from button.</summary>
    public void SendTextChat() => ClientSend.TextChatReceived(InputField.text);

    #endregion

    //TODO: Make netplayer hud actually part of the netplayer prefab!
}
