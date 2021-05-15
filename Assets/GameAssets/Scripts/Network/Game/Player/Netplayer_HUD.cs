using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Utils.Colour;

public class Netplayer_HUD : MonoBehaviour //Netplayer
{
    public static Netplayer_HUD instance;

    public Netplayer_HUD()
    {
        instance = this;
        return;
    }

    public InputField InputField;
    public Text ChatboxText;
    Colour localChatColour = new Colour(255, 255, 255, 255);

    public Dictionary<int, GameObject> Items = new Dictionary<int, GameObject>();
    public GameObject InventoryPanel;

    #region Chat
    ///<summary>Update gui with new chat from server. Called from client handle.</summary>
    public void UpdateTextChat(string _msg, Colour _colour)
    {
        float _a = _colour.A / 255; float _r = _colour.R / 255;
        float _g = _colour.G / 255; float _b = _colour.B / 255;

        string newColor = ColorUtility.ToHtmlStringRGBA(new Color(_r, _g, _b, _a));
        _msg = _msg.Insert(0, $"<color=#{newColor}>");

        ChatboxText.text += $"\n" + _msg + "</color>";
    }

    ///<summary>Send to server (through clientsend), which will return this message moderated, and send to all other players. Called from button.</summary>
    public void SendTextChat()
    {
        string[] args = InputField.text.Split(' ');

        switch (args[0])
        {
            case "/help":
                ChatboxText.text += "\n" + "<b>Help commands:</b> \n /colour <i>r g b a</i>";
                break;
            case "/colour":
                try
                {
                    localChatColour = new Colour(byte.Parse(args[1]), byte.Parse(args[2]), byte.Parse(args[3]), byte.Parse(args[4]));
                } 
                catch
                {
                    ChatboxText.text += "\n" + $"<b>Could not apply new colour!</b> " +
                        "<color=#c0c0c0ff>Check that you have provided 4 numbers (RGBA), and have included no additional letters.</color>";
                }
                break;
            default:
                ClientSend.TextChatReceived(InputField.text, localChatColour);
                break;
        }
    }
    #endregion

    #region Inventory

    public void AddInventoryItem(GameObject _item) //TODO: 1 & 2 anomalous - special resizing after - current code is kind how 1 & 2 will work
    {
        Items.Add(Items.Count + 1, _item);

        if (Items.Count <= 2)
        {
            _item = Instantiate(_item, new Vector3(InventoryPanel.transform.position.x - (InventoryPanel.GetComponent<RectTransform>().sizeDelta.x) + (_item.GetComponent<RectTransform>().sizeDelta.x * Items.Count), InventoryPanel.transform.position.y, InventoryPanel.transform.position.z), Quaternion.identity);
            _item.transform.parent = InventoryPanel.transform;
        }
        else
        {
            var _1 = Items[1]; //does it count from 0 or 1
            Debug.Log(_1);

            _item = Instantiate(_item, new Vector3(InventoryPanel.transform.position.x - (InventoryPanel.GetComponent<RectTransform>().sizeDelta.x) + (_item.GetComponent<RectTransform>().sizeDelta.x * Items.Count), InventoryPanel.transform.position.y, InventoryPanel.transform.position.z), Quaternion.identity);
            _item.GetComponent<RectTransform>().transform.localScale /= 2; //1/2
            _item.transform.parent = InventoryPanel.transform;

        }
    } 

    #endregion

    //TODO: Make netplayer hud actually part of the netplayer prefab!
}

