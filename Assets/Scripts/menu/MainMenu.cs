using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject MainPanel;
    public GameObject OptionsPanel;
    public GameObject LoadingPanel;
    public AudioMixer audioMixer;
    public Slider slider;
    

    //for main panel
    public void StartGame()
    {
        Time.timeScale = 1f;
        StartCoroutine(Loadscene());
    }


    IEnumerator Loadscene()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(1);
        LoadingPanel.SetActive(true);
        MainPanel.SetActive(false);

        while (!operation.isDone)
        {
            float progres = Mathf.Clamp01(operation.progress/0.9f);
            slider.value = progres;
            yield return null;
        }
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
