using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponManager : MonoBehaviour
{

    public int selectedweapon = 0;
    // Start is called before the first frame update
    void Start()
    {
        selectWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        int previousselectedweapon = selectedweapon;
        bool run = Input.GetButton("run");
        if (Input.GetAxis("Mouse ScrollWheel") > 0f && !run)
        {
            if (selectedweapon >= transform.childCount - 1)
                selectedweapon = 0;
            else
            selectedweapon++;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f && !run)
        {
            if (selectedweapon <= 0)

                selectedweapon = transform.childCount - 1;
            else
                selectedweapon--;
        }
        
        if (previousselectedweapon != selectedweapon && !PlayerManger.instance.reloading)
            selectWeapon();
    }

    void selectWeapon()
    {
        int i = 0;

        foreach(Transform weapon in transform)
        {
            if (i == selectedweapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);

            i++;
        }
    }
}
