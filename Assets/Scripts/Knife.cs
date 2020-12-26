using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    private bool run;
    private bool walk;
    private bool attack1;
    private bool attack2;
    private bool isAttacking = false;
    public float attackCoolDown = -1f;
    public float attackTime = 1f;
    public Animator animator;
    public BloodEffect BloodEffect;
    public AudioSource audioSource;
    public AudioClip attckclip1;
    public AudioClip attckclip2;
    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
        
    }

    private void OnEnable()
    {
        //animator.SetTrigger("Idle");
    }


    // Update is called once per frame
    void Update()
    {
        run = Input.GetButton("run");
        walk = Input.GetAxis("Vertical") != 0f || Input.GetAxis("Horizontal") != 0f;
        attack1 = Input.GetButton("Fire1");
        attack2 = Input.GetButton("Fire2");



        

        if (isAttacking)
        {
            attackCoolDown -= Time.deltaTime;
        }

        isAttacking = attackCoolDown > 0 ;


        if (attack1 && !isAttacking)
        {
            isAttacking = true;
            attackCoolDown = attackTime;
            animator.SetTrigger("Attack_1");
            audioSource.clip = attckclip1;
            audioSource.PlayOneShot(audioSource.clip);
        }

        if (attack2 && !isAttacking)
        {
            isAttacking = true;
            attackCoolDown = attackTime;
            animator.SetTrigger("Attack_2");
            audioSource.clip = attckclip2;
            audioSource.PlayOneShot(audioSource.clip);
        }


       
       

        if (walk)
        {
            animator.SetTrigger("Walk");
        }
        else
        {
            //animator.ResetTrigger("Walk");
            animator.SetTrigger("Idle");
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "ENEMY")
        {
            
            if(isAttacking)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit))
                {
                    //Debug.Log("Point of contact: " + hit.point);
                    BloodEffect.BloodImpact(hit);
                }
                other.gameObject.GetComponent<EnemyStat>().Die();
                
            }
        }
    }
}
