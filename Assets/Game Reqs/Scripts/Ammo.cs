using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;


    [System.Serializable]
    public class AmmoSlot
    {
        public AmmoType ammoType;
        public int AmmoAmount;
    }

    public int GetCurrentAmmoCount(AmmoType ammoType)
    {
        return GetAmmoSlot(ammoType).AmmoAmount;
    }

    public void DecreaseAmmoCount(AmmoType ammoType , int AmmoToReload)
    {
        GetAmmoSlot(ammoType).AmmoAmount = GetAmmoSlot(ammoType).AmmoAmount - AmmoToReload;
    }
    public void IncreaseAmmoCount(AmmoType ammoType, int ammoAmount )
    {
        GetAmmoSlot(ammoType).AmmoAmount += ammoAmount;
    }
    

    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach (AmmoSlot slot in ammoSlots)
        {
            if (slot.ammoType == ammoType)
            {
                return slot;
            }
        }
        return null;
    }




}
