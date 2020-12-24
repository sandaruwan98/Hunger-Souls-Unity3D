using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    private bool run;
    private bool walk;
    private bool attack1;
    private bool attack2;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
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



        if (attack1)
        {
            animator.SetTrigger("Attack_1");
        }

        if (attack2)
        {
            animator.SetTrigger("Attack_2");
        }


       
       

        if (walk)
        {
            animator.SetTrigger("Walk");
        }
        else
        {
            animator.ResetTrigger("Walk");
            animator.SetTrigger("Idle");
        }
    }
}
