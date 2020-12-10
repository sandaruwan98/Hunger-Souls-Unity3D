using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public float lookRadius = 10f;
    Transform target;
    NavMeshAgent agent;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        target = PlayerManger.instance.player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);


        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            float speed = agent.velocity.magnitude / agent.speed;
            anim.SetBool("attack", false);
            anim.SetFloat("speed", speed);

            if (distance <= agent.stoppingDistance)
            {
                FaceTarget();
                attack();
            }
        }
    }

    private void attack()
    {
        anim.SetBool("attack", true);
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookrotation = Quaternion.LookRotation( new Vector3( direction.x, 0, direction.z) );
        transform.rotation =  Quaternion.Slerp(transform.rotation , lookrotation,Time.deltaTime*5f);
    }
}
