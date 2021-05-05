using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Netplayer_HUD : MonoBehaviour
{
    //public Chat chat;

    public InputField InputField;
    public Button SubmitButton;
    public Text ChatboxText;

    class Chat : Netplayer_HUD
    {
        public Dictionary<PlayerManager, string> ChatMessages;

        public Chat()
        {
            //ChatMessages = new Dictionary<PlayerManager, string>();
            //string[] Messages;
        }

        public static void UpdateTextChat(string _msg)
        {
            //This is called from clientHandle!!!! //add a new message to the list
        }

        public static void SendTextChat()
        {
            //Send to server (through clientsend), which will return this message moderated, and send to all other players.
        }
    }

    void Start()
    {
        //chat = new Chat();
        //TESTIN G-------------------------------------- works but not yet supposed  to send lol
        ClientSend.TextChatReceived("Hello world!");
        ClientSend.TextChatReceived("sublime axel");
    } 
    
    void Update()
    {

    }
}

