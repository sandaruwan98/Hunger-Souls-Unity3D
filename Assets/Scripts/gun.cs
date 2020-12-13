using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gun : MonoBehaviour
{
    public int bulletdamage = 10;
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
    public float reloadtime = 3;
    public int bcount = 10;
    public int totalBullts = 150;

    private float nextTimetofire = 0f;
    private float nextTimetofireSound = 0f;
    public float reloadCooldown;
    private bool run = false;
    private bool shootcheck = false;
    



    // Start is called before the first frame update
    void Start()
    {
        bullets = bcount;
        reloadCooldown = 0f;
    }

    private void OnDisable()
    {
        anim.CrossFade("fire");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (reloadCooldown > 0)
        {
            reloadCooldown-=Time.deltaTime;
        }
        shootcheck = Input.GetButton("Fire1") && reloadCooldown <= 0f && (!run);

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
                //anim.CrossFade("fire");
                anim.Play("fire");
                MfPlay();
                shoot();
            }
            else
            {
                reloadCooldown = reloadtime;
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
        if(Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range))
        {
            
            EnemyStat zombie = hit.transform.GetComponent<EnemyStat>();

            if (zombie != null)
            {
                //check if headshot or not
                if(hit.collider is BoxCollider)
                {
                    //if headshot die immediate
                    zombie.Die();
                }
                else
                {
                    zombie.TakeDamage(bulletdamage);
                }

                
               // target.animator.SetBool("hit", true);
            }
            
            impactPLAY("ENEMY",Bloodimpact);           
            impactPLAY("concrete", concreteimpact);
            impactPLAY("metal", metalimpact);
          
            void impactPLAY(string tag, GameObject obj)
            {
                if (hit.transform.tag == tag)
                {
                    GameObject imapact = Instantiate(obj, hit.point, Quaternion.LookRotation(hit.normal));
                    Destroy(imapact,5f);
                }
            }
        }
    } 
   
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
            reloadCooldown = reloadtime;
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
