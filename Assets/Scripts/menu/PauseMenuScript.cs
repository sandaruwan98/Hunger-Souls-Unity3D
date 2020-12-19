using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public static bool GameIsPaused = false;
    bool isGameOver = false;
    public GameObject pausePanel;
    public GameObject goPanel;
    public GameObject gamePanel;
    public GameObject info;
    private Scene Scene;
    public GameObject player;
    RigidbodyFirstPersonController fps;
    // Start is called before the first frame update
    void Start()
    {
        Scene = SceneManager.GetActiveScene();
        fps = PlayerManger.instance.player.GetComponent<RigidbodyFirstPersonController>();
        Invoke("hideinfo",6f);
    }


    void hideinfo()
    {
        info.SetActive(false);
    }
    public void GameOver()
    {
        fps.enabled = false;
        Destroy(player);
        isGameOver = true;
        goPanel.SetActive(true);
        gamePanel.SetActive(false);
        
        Time.timeScale = 0.05f;
        GameIsPaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Invoke("stoptime", 0.15f);
    }


    // Update is called once per frame
    void Update()
    {
 
        if (Input.GetKeyDown(KeyCode.Escape) && !isGameOver)
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
        //Invoke("stopTime",0.1f);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
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
        SceneManager.LoadScene(0);
    }

    public void stoptime()
    {
        Time.timeScale = 0f;
    }

    public void restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(Scene.name);
        GameIsPaused = false;
    }
    
}
