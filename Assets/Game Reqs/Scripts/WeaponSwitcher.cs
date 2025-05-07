using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{

    [SerializeField] int currentWeapon=0;
    
    void Start()
    {
             
    }
    void Update()
    {
        int PreviousWeapon = currentWeapon;

        ProcessKeyInput();
        ProcessScrollWheel();

        if(PreviousWeapon != currentWeapon)
        {
            SetWeaponActive();
        }
        
    }

    private void ProcessScrollWheel()
    {
        if(Input.GetAxis("Mouse ScrollWheel")<0)
        {
            if(currentWeapon >= transform.childCount - 1)
            {
                currentWeapon = 0;

            }
            else
            {
                currentWeapon++;
            }
        }

        if(Input.GetAxis("Mouse ScrollWheel")>0)
        {
            if(currentWeapon <0)
            {
                currentWeapon = transform.childCount - 1;

            }
            else
            {
                currentWeapon--;
            }
        }
    }

    private void ProcessKeyInput()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeapon = 0;
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeapon = 1;
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentWeapon = 2;
        }
        
    }

    void SetWeaponActive()
    {
        int WeaponIndex = 0;
       foreach(Transform weapons in transform)
       {
            if(WeaponIndex == currentWeapon)
            {
                weapons.gameObject.SetActive(true);
            }
            else
            {
                weapons.gameObject.SetActive(false);
            }
            WeaponIndex++;
       }
    }

}
