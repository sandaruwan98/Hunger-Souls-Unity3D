using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManger : MonoBehaviour
{
    #region Singleton

    public static PlayerManger instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject player;
    public bool reloading = false;
    private bool seen = false;

    public bool isSeen { get => seen; set => seen = value; }

    public void falseSeen()
    {
        Invoke("setss", 5f);
    }
    void setss()
    {
        seen = false;
    }
    public void GameOver()
    {
        Time.timeScale = 0.2f;
    }
}
