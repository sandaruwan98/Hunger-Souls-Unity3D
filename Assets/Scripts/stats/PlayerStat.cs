using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStat : CharactorStat
{
    public Healthbar healthbar;
   
   

    // Start is called before the first frame update
    void Start()
    {
        healthbar.SetMaxHealth(maxhealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        // show blood ui to show you have hit 



        //healthbar
        healthbar.SetHealth(currenthealth);
    }

    public override void Die()
    {
        base.Die();
        //Debug.Log("Player died");
        //animation 
        // display lost game
        // restrat or goto menu
    }
}
