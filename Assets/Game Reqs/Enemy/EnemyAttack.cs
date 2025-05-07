using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    PlayerHealth target;
    [SerializeField] float Damage =40f;
    
    
    

    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }

    public void AttackHitEvent()
    {
        Debug.Log("Attack hit called");

        if(target == null) { return; }

        DisplayDamage displayDamage = target.GetComponent<DisplayDamage>();
        if(displayDamage != null)
        {
            displayDamage.ControlImpactCanvas();
        }
        target.PlayerDamage(Damage);
    }
}
