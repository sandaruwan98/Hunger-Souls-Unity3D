using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStat : CharactorStat
{
    public Healthbar healthbar;
    BloodPanel BloodPanel;
    public PauseMenuScript ps;

    // Start is called before the first frame update
    void Start()
    {
        healthbar.SetMaxHealth(maxhealth);
        BloodPanel = FindObjectOfType<BloodPanel>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void getMediPack(int value)
    {
        currenthealth += value;
        if (currenthealth > maxhealth)
            currenthealth = maxhealth;
        healthbar.SetHealth(currenthealth);
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        
        // show blood ui to show you have hit 
        BloodPanel.DisplayPanel();


        //healthbar
        healthbar.SetHealth(currenthealth);
    }

    public override void Die()
    {
        base.Die();

        // display lost game
        
        BloodPanel.Gameover();
        ps.GameOver();
        
    }
}
