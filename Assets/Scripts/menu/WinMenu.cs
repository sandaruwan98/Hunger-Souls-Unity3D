using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{

    public void Mainmenu()
    {
        SceneManager.LoadScene(0);
    }
    public void PlayAgain(int level)
    {
        SceneManager.LoadScene(level);
    }
    public void Quit()
    {
        Application.Quit();
    }

}
