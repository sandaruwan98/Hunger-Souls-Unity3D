using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject MainPanel;
    public GameObject OptionsPanel;
    public AudioMixer audioMixer;
    

    //for main panel
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Options()
    {
        OptionsPanel.SetActive(true);
        MainPanel.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }



    //for options
    public void IsFullScreen(bool isFull)
    {
        Screen.fullScreen = isFull;
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void Back()
    {
        OptionsPanel.SetActive(false);
        MainPanel.SetActive(true);
    }
    
}
