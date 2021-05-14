using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleUiManager : MonoBehaviour
{
    private int animspeed = 2;
    private bool animate;
    private GameObject effector;

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
        effector = _underline;
        animate = true;
    }

    public void TopBarExit(GameObject _underline)
    {
        effector = _underline;
        animate = false;
    }

    void Update()
    {
        if (effector)
        {
            if (animate)
                effector.transform.localScale = Vector3.Lerp(effector.transform.localScale, new Vector3(2f, effector.transform.localScale.y, effector.transform.localScale.z), animspeed * Time.deltaTime);
            else
                effector.transform.localScale = Vector3.Lerp(effector.transform.localScale, new Vector3(1f, effector.transform.localScale.y, effector.transform.localScale.z), animspeed * Time.deltaTime);
        }
    }
}
