using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStat : CharactorStat
{
    public RectTransform healthbar;
    public TextMeshProUGUI healthtext;
    public int healthbarMaxLen;
    int healthbarLen;

    // Start is called before the first frame update
    void Start()
    {
        healthbarLen = healthbarMaxLen;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        // show blood ui to show you have hit 
        
        
        //show health bar
        healthbarLen = (currenthealth / maxhealth) * healthbarMaxLen;

        //healthbar.rect.Set(width: healthbarLen);
         healthtext.text = currenthealth.ToString();
    }

    public override void Die()
    {
        base.Die();
        Debug.Log("Player died");
        //animation 
        // display lost game
        // restrat or goto menu
    }
}
