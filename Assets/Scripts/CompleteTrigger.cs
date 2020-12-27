
using UnityEngine;

using UnityEngine.SceneManagement;

public class CompleteTrigger : MonoBehaviour
{
    public GameObject panel;
    private bool complete = false;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            complete = true;
            panel.SetActive(true);
           // Destroy(other.gameObject);
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            panel.SetActive(false);
            complete = false;
        }
        
            
    }

    private void Update()
    {
        if (complete)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                Time.timeScale = 0f;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
}
