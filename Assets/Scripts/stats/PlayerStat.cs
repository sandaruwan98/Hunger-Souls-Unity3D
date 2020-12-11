using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : CharactorStat
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        // show blood ui to show you have hit
    }

    public override void Die()
    {
        base.Die();
        //animation 
        // display lost game
        // restrat or goto menu
    }
}
