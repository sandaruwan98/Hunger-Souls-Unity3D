using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat : CharactorStat
{
    Animator anim;
    EnemyController enemycon;
    CapsuleCollider col;
    EnemySoundManager soundManager;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        enemycon = GetComponent<EnemyController>();
        //col = GetComponent<CapsuleCollider>();
        soundManager = GetComponent<EnemySoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        //hit animation
        //anim.SetInteger("scream", Random.Range(0, 10));
    }

    public override void Die()
    {
        base.Die();
        //play die anim
        anim.SetInteger("die", Random.Range(1,3));
        transform.DetachChildren();
        //play sound
        soundManager.PlayDieSound();
        Destroy(enemycon);
        Destroy(transform.gameObject,2f);
       
    }
}
