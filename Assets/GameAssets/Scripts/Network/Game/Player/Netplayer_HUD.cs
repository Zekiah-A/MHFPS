using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Netplayer_HUD : MonoBehaviour
{
    public Chat chat;

    public class Chat
    {
        public Dictionary<PlayerManager, string> ChatMessages;

        public InputField InputField;
        public Button SubmitButton;
        public Text ChatboxText;

        public Chat()
        {
            ChatMessages = new Dictionary<PlayerManager, string>();
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
        chat = new Chat();
        //TESTIN G--------------------------------------
        ClientSend.TextChatReceived("Hello world!");
        ClientSend.TextChatReceived("sublime axel");
    } 
    
    void Update()
    {
        
    }
}

