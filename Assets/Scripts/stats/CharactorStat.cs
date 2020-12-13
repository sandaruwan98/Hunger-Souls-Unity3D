using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorStat : MonoBehaviour
{
    public int maxhealth = 100;
    public int currenthealth;
    public Stat damage;
    // Start is called before the first frame update
    void Awake()
    {
        currenthealth = maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void  TakeDamage(int damage)
    {
        currenthealth -= damage;
        if(currenthealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        //Debug.Log("Died");
    }
}
