using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject MainPanel;
    public GameObject OptionsPanel;
    public GameObject levelsPanel;
    public GameObject LoadingPanel;
    public AudioMixer audioMixer;
    public Slider slider;


    Resolution[] resolutions;
    public TMP_Dropdown resdropdown;


    private void Start()
    {
        resolutions = Screen.resolutions;
        resdropdown.ClearOptions();
        List<string> options = new List<string>();

        int currnet_res_index=0;
        for(int i=0; i < resolutions.Length; i++)
        {
            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currnet_res_index = i;
            }
            string option = resolutions[i].width +" x " +resolutions[i].height;
            options.Add(option);
        }


        resdropdown.AddOptions(options);
        resdropdown.value = currnet_res_index;
        resdropdown.RefreshShownValue();
    }
    //for main panel
    public void StartGame(int index)
    {
        Time.timeScale = 1f;
        StartCoroutine(Loadscene(index));
    }


    IEnumerator Loadscene(int index)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);
        LoadingPanel.SetActive(true);
        levelsPanel.SetActive(false);

        while (!operation.isDone)
        {
            float progres = Mathf.Clamp01(operation.progress/0.9f);
            slider.value = progres;
            yield return null;
        }
    }

    

    public void ShowLevels()
    {
        levelsPanel.SetActive(true);
        MainPanel.SetActive(false);
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

    public void SetQuality(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }


    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetResolution(int index)
    {
        Screen.SetResolution(resolutions[index].width, resolutions[index].height, Screen.fullScreen);

    }

    public void Back()
    {
        OptionsPanel.SetActive(false);
        levelsPanel.SetActive(false);
        MainPanel.SetActive(true);
    }
    
}
