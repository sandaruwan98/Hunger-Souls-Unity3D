using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStat : CharactorStat
{
    Animator anim;
    EnemyController enemycon;
    CapsuleCollider col;
    EnemySoundManager soundManager;
    NavMeshAgent navagent;
    public float recovertime = 1.7f;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        enemycon = GetComponent<EnemyController>();
        navagent = GetComponent<NavMeshAgent>();
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
        if(Random.Range(0,8) == 4)
        {
            anim.SetTrigger("hit");
            navagent.isStopped = true;
            Invoke("recoverfromHit", recovertime);
        }
        
    }

    private void recoverfromHit()
    {
       
        navagent.isStopped = false;
    }

    public override void Die()
    {
        base.Die();
        //play die anim
        PlayerManger.instance.falseSeen();
        anim.SetInteger("die", Random.Range(1,3));
        transform.DetachChildren();
        //play sound
        soundManager.PlayDieSound();
        Destroy(enemycon);
        Destroy(transform.gameObject,2f);
       
    }
}
