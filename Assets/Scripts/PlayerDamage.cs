using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerDamage : MonoBehaviour
{
    public PauseMenuScript menu;
    public Button resumebtn;
    public Image healthbar;
    public TextMeshProUGUI healthText;
    public Image bloodpanel;

    public float health = 100f;
    public float health2 = 100f;
    public bool die = false;
    private float width = 114.11f;
    private float next;
    private bool healbool = false;
    private int h;

    private void Start()
    {
        next = Time.time + 50f;
    }
    // Start is called before the first frame update
    void Update()
    {
        if (health2 > health)
        {
            health2--;
        }
        heal();
        if (healbool)
        {
            health2++;
            health++;
            //if(health >= 100f)
            //{
            //    healbool = false;
            //}
        }
        width = (1.1411f) * health2;
        healthbar.rectTransform.sizeDelta = new Vector2(width, 20.53f);
        h = (int)health2;
        healthText.SetText(h.ToString());
        //if(health2 <=50 && health2 >= 20)
        //{
        //    Color c = bloodpanel.color;
        //    c.a = (50 - health2 ) * 0.033f;
        //    bloodpanel.color = c;
        //}
        
    }

   
    public void TakeDamage(float amount)
    {
       
        health -= amount;
        next = Time.time + 10f;
       // Debug.Log(health);
        if (health <= 0f)
        {
            health = 0f;
           // Time.timeScale = 0.4f;
           // Invoke("Die", 1f);
         
        }
    }

   

    void Die()
    {
        menu.pausePanel.SetActive(true);
        menu.gamePanel.SetActive(false);
        resumebtn.enabled = false;
        Time.timeScale = 0f;
    }

    void heal()
    {
        if(Time.time > next && health <= 100f)
        {
            healbool = true;
        }
        else
        {
            healbool = false;
        }
    }
}
