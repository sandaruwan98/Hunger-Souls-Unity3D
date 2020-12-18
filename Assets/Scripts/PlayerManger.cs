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
    public void GameOver()
    {
        Time.timeScale = 0.2f;
    }
}
