using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public Animator animator;

    public float health = 50f;
    public bool die = false;

   
    
    public void TakeDamage(float amount)
    {
        
        health -= amount;
        if(amount >= 25f && health <= 0f)
        {
            die = true;
            animator.SetBool("diehead", true);
        }
        if (health <= 0f && amount < 25f)
        {
            Die();
        }
    }

    void Die()
    {
        die = true;
        animator.SetBool("die", true);
        // Destroy(gameObject);
    }
}
