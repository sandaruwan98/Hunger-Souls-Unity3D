using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject MainPanel;
    public GameObject OptionsPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }


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
        
    }

    public void Back()
    {
        OptionsPanel.SetActive(false);
        MainPanel.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
