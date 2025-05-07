using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class AmmoPickup : MonoBehaviour
{

    [SerializeField] int PlusAmmo = 5;
    [SerializeField] AmmoType ammoType;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            FindObjectOfType<Ammo>().IncreaseAmmoCount(ammoType, PlusAmmo);
            Destroy(gameObject);
        }
    }
}

