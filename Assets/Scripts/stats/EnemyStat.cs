using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat : CharactorStat
{
    Animator anim;
    EnemyController con;
    CapsuleCollider col;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        con = GetComponent<EnemyController>();
        col = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        //hit animation

    }

    public override void Die()
    {
        base.Die();
        //play die anim
        anim.SetInteger("die", 1);
        //Destroy
        Destroy(con);
        Destroy(col);
        //Destroy(this.gameObject, 5f);
    }
}
