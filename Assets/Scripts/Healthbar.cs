using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Healthbar : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI Htext;
    

    public void SetHealth(int health)
    {
        if(health >= 0)
        {
            Htext.text = health.ToString();
            slider.value = health;
        }
        
    }

    public void SetMaxHealth(int health)
    {
        Htext.text = health.ToString();
        slider.maxValue = health;
        slider.value = health;
    }

  
}
