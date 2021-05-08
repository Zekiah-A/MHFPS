using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleUiManager : MonoBehaviour
{
    public void LoadMultiplayer()
    {
        try
        {
            SceneManager.LoadScene("Multiplayer");
        } catch(Exception _e)
        {
            Debug.Log($"Could not load scene Multiplayer: {_e}");
        }
    }

    public void TopBarEnter(GameObject _underline)
    {
        _underline.transform.localScale = new Vector3(1.5f ,_underline.transform.localScale.y, _underline.transform.localScale.z);
    }

    public void TopBarExit(GameObject _underline)
    {
        _underline.transform.localScale = new Vector3(1, _underline.transform.localScale.y, _underline.transform.localScale.z);
    }
}
