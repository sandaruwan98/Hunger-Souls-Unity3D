using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public float lookRadius = 10f;
    Transform target;
    PlayerStat playerStat;
    CharactorStat myStat;
    NavMeshAgent agent;
    Animator anim;
    EnemySoundManager soundManager;
    public float attackSpeed = 1f;
    private float attackcooldown= 0f;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        myStat = GetComponent<CharactorStat>();
        soundManager = GetComponent<EnemySoundManager>();
        target = PlayerManger.instance.player.transform;
        playerStat = target.GetComponent<PlayerStat>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        attackcooldown -= Time.deltaTime;
        float speed = agent.velocity.magnitude / agent.speed;
        anim.SetFloat("speed", speed);

        if (distance <= lookRadius)
        {
            PlayerManger.instance.isSeen = true;
            agent.SetDestination(target.position);
            //play sound 
            soundManager.PlayMoveSound();

            //anim.SetFloat("attack", attackcooldown);
            if (distance <= agent.stoppingDistance+0.1f)
            {

                

                FaceTarget();

                
                if(attackcooldown <= 0)
                {
                    attack();
                    attackcooldown = 1f / attackSpeed;
                }
                
            }
        }
       
    }

    private void attack()
    {
        anim.SetTrigger("attack");
        playerStat.TakeDamage(myStat.damage.GetValue());
        soundManager.PlayAttackSound();
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookrotation = Quaternion.LookRotation( new Vector3( direction.x, 0, direction.z) );
        transform.rotation =  Quaternion.Slerp(transform.rotation , lookrotation,Time.deltaTime*5f);
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
