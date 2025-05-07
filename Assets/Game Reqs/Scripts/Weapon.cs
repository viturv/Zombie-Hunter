using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Weapon : MonoBehaviour
{
    [SerializeField] float IsOperatableDelay = 10f;
    [SerializeField] Camera fpCamera;
   
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 2f;
   
    [SerializeField] ParticleSystem MuzzleFlash;
    [SerializeField] GameObject HitEffect;
   
    [SerializeField] Ammo AmmoSlot;
    [SerializeField] AmmoType ammoType;
   
    [SerializeField] float FireDelay =.1f;
    [SerializeField] int AmmoLeftInMag ;
    [SerializeField] int MagSize = 6;
    [SerializeField] float ReloadTime = 2.5f; 
    bool Reloading = false;

    [SerializeField] TextMeshProUGUI ReloadingUI;
    
    [SerializeField] TextMeshProUGUI AmmoCountUI;
    [SerializeField] TextMeshProUGUI ReloadedAmmo;


    bool CanShoot = false;
    void OnEnable()
    {
        AmmoLeftInMag = MagSize;
        ReloadingUI.enabled = false;
        StartCoroutine(ResetCanShoot());
    }

    IEnumerator ResetCanShoot()
    {
        yield return new WaitForSeconds(IsOperatableDelay);
        CanShoot = true;
    }

    void Update()
    {
        
        DisplayAmmo();

        if (Input.GetButtonDown("Fire1") && CanShoot== true)
        {   
            if (Reloading == false)
            {
                StartCoroutine(Shoot());   
            }
            
        }   
    }

    void DisplayAmmo()
    {
        int CurrentAmmoCount = AmmoSlot.GetCurrentAmmoCount(ammoType);
        AmmoCountUI.text = ("Ammo - " + CurrentAmmoCount.ToString());

    }

    IEnumerator Shoot()
    {
        CanShoot = false;
        if(AmmoSlot.GetCurrentAmmoCount(ammoType) > 0)
        {  
            ProcessRayCast(); 
            PlayMuzzleEffect();
            
            AmmoLeftInMag --;
            ReloadedAmmo.text = ("Loaded - " + AmmoLeftInMag.ToString());

            if(AmmoLeftInMag == 0 )
            {
                StartCoroutine(Reload());
                AmmoLeftInMag=MagSize;
                AmmoSlot.DecreaseAmmoCount(ammoType, MagSize);
            }
            
            
        }
        yield return new WaitForSeconds(FireDelay);
        CanShoot = true;
    }

    void PlayMuzzleEffect()
    {

        MuzzleFlash.Play();
    }

    void ProcessRayCast()
{ 
    RaycastHit hit;
    if (Physics.Raycast(fpCamera.transform.position, fpCamera.transform.forward, out hit, range))
    {
        CreateHitImpact(hit);
        
        EnemyHealthPoints target = hit.transform.GetComponent<EnemyHealthPoints>();
        if (target != null)
        {
            target.TakeDamage(damage);
        }
        else
        {
            Debug.Log("Target is null. Check the object you are hitting.");
        }
    }
}

    void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact =  Instantiate(HitEffect,hit.point , Quaternion.LookRotation(hit.normal));
        Destroy(impact , 0.1f);
    }
    IEnumerator Reload()
    {
        Reloading = true;
        ReloadingUI.enabled = true;
        yield return new WaitForSeconds(ReloadTime);
        
        ReloadingUI.enabled = false;
        Reloading = false;
        
    }
}
