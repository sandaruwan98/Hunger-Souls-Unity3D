﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gun : MonoBehaviour
{
    public float bulletdamage = 15f;
    public float range = 100f;
  
    public float FireRate = 2f;
    public float FireSpeed = 2f;
    public float FireSound = 2f; 

    public Camera fpscam;
    public Animator animator;
    public Animator animstab;
    public ParticleSystem mf;
    public ParticleSystem flame;
    public ParticleSystem pt;
    public ParticleSystem dst;
    public ParticleSystem smoke;

    public GameObject Bloodimpact;
    public GameObject Dirtimpact;
    public GameObject waterimpact;
    public GameObject woodimpact;
    public GameObject concreteimpact;
    public GameObject glassimpact;
    public GameObject metalimpact;
    public GameObject rockimpact;
    
    public Animation anim;
    public TextMesh tmBullet;
    public TextMesh tmTotalBullet;
    public List<AudioSource> sounds;
    public GameObject crosshair;


    private int bullets;
    public int reloadtime = 150;
    public int bcount = 10;
    public int totalBullts = 150;
    private float nextTimetofire = 0f;
    private float nextTimetofireSound = 0f;
    private int x;
    private bool run = false;
    private bool shootcheck = false;
    



    // Start is called before the first frame update
    void Start()
    {
        bullets = bcount;
        x = 0;
    }

    private void OnDisable()
    {
        anim.CrossFade("fire");
    }

    // Update is called once per frame
    void Update()
    {
        StabEnemyCheck();
        if (x > 0)
        {
            x--;
        }
        shootcheck = Input.GetButton("Fire1") && x <= 0 && (!run);

        if (shootcheck && Time.time >= nextTimetofireSound  && bullets > 0 && totalBullts > 0)// shoot sound
        {
            nextTimetofireSound = Time.time + 1f / FireSound;
            sounds[0].Play();
        }
            


        if (shootcheck && Time.time >= nextTimetofire) //shoot-----------
        {
            bullets--;
            nextTimetofire = Time.time + 1f/FireRate;
            if(bullets > 0 && totalBullts>0)
            {
                anim["fire"].speed = FireSpeed;
                anim.CrossFade("fire");
              
                MfPlay();
                shoot();
            }
            else
            {
                x = reloadtime;
                totalBullts -= (bcount - bullets);
                if(totalBullts > bcount)
                {
                    bullets = bcount;
                }
                else
                {
                    bullets = totalBullts;
                }
                
                anim.CrossFade("reload");
                sounds[1].Play();
            }

            DisplayBulletCount();
        }
        
        Reload();
        runAnimation();
       
       // if (Input.GetButtonUp("Fire1"))
        //    sounds[0].Stop();
        


    }// end of update ------------------------------------------------------

   
    void shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range))
        {
            
            Target target = hit.transform.GetComponent<Target>();

            if (target != null)
            {
                target.TakeDamage(bulletdamage);
               // target.animator.SetBool("hit", true);//-----------------------------------------------------
               
            //    target.animator.SetBool("hit", false);
            }
            
            impactPLAY("ENEMY",Bloodimpact);
            impactPLAY("head", Bloodimpact);
            impactPLAY("terrain",Dirtimpact);
            impactPLAY("water", waterimpact);
            impactPLAY("wood", woodimpact);
            impactPLAY("glass", glassimpact);
            impactPLAY("concrete", concreteimpact);
            impactPLAY("metal", metalimpact);
            impactPLAY("rock", rockimpact);

            void impactPLAY(string tag, GameObject obj)
            {
                if (hit.transform.tag == tag)
                {
                    GameObject imapact = Instantiate(obj, hit.point, Quaternion.LookRotation(hit.normal));
                    Destroy(imapact,5f);


                }
            }

            
            //if (hit.rigidbody != null)
            //{
            //    hit.rigidbody.AddForce(-hit.normal * force);
            //}
        }

    } // end of shoot --------------------------------------------------------------

    void DisplayBulletCount()
    {
        tmBullet.text = bullets.ToString();
        tmTotalBullet.text = totalBullts.ToString();
       // tmBullet.SetText(bullets.ToString());
       // tmTotalBullet.SetText(totalBullts.ToString());

    }

    
    void runAnimation()
    {
        

        if (Input.GetButtonUp("run"))
        {
            animator.SetBool("run", false);
            run = false;
            crosshair.SetActive(true);
            
        }

        if (Input.GetButtonDown("run"))
        {
            animator.SetBool("run", true);
            run = true;
            crosshair.SetActive(false);
        }

        if (Input.GetAxis("Vertical") != 0f || Input.GetAxis("Horizontal") != 0f)
        {
            animator.SetBool("walk", true);
        }
        else
        {
            animator.SetBool("walk", false);
        }
    }

    void StabEnemyCheck()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
           
            animstab.SetBool("stab", true);
        }
        else
        {
            animstab.SetBool("stab", false);
        }
    }
    
    void MfPlay()
    {
        
         mf.Play();
         flame.Play();
         pt.Play();
         dst.Play();
         smoke.Play();
    }

    void Reload()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            x = reloadtime;
            totalBullts -= (bcount - bullets);
            if (totalBullts > bcount)
            {
                bullets = bcount;
            }
            else
            {
                bullets = totalBullts;
            }
            anim.CrossFade("reload");
            sounds[1].Play();
            DisplayBulletCount();
        }
       
    }


}//end of class ----------------------------------------------------------