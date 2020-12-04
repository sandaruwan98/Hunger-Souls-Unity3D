using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pausePanel;
    public GameObject gamePanel;
    private Scene Scene;
    
    // Start is called before the first frame update
    void Start()
    {
        Scene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    private void Pause()
    {
        pausePanel.SetActive(true);
        gamePanel.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.visible = true;
    }

    public void Resume()
    {
        pausePanel.SetActive(false);
        gamePanel.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.visible = false;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Menu()
    {

        Time.timeScale = 1f;
    }

    public void options()
    {

    }

    public void restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(Scene.name);
        GameIsPaused = false;
    }
}
