using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour
{

    public Animator animator;
    public Camera cam;
    private float zoom = 60;
    private float zoomSpeed = 65f;
    private float next = 0f;
    private bool aim = false;
    public GameObject crosshair;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            animator.SetBool("aim", true);
            aim = true;
            crosshair.SetActive(false);


        }
        if (Input.GetButtonUp("Fire2"))
        {
           
            animator.SetBool("aim", false);
            aim = false;
            crosshair.SetActive(true);
        

        }

        if (aim)
        {
            cam.fieldOfView = zoom;
            zoomMinus(48);
        }
        else
        {
            cam.fieldOfView = zoom;
            zoomPlus(60);
        }

        
       

        
    }

    void zoomPlus(float f)
    {
        if(Time.time >= next && zoom <= f)
        {
            next = Time.time + 1f / zoomSpeed;
            zoom++;
        }
    }

    void zoomMinus(float f)
    {
        if (Time.time >= next && zoom >= f)
        {
            next = Time.time + 1f / zoomSpeed;
            zoom--;
        }
    }

    void runCrossHair()
    {
        if (Input.GetButtonDown("run"))
        {
            crosshair.SetActive(false);
        }
        if (Input.GetButtonUp("run"))
        {
            crosshair.SetActive(true);
        }
    }
}
