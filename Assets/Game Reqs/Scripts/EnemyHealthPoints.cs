using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyHealthPoints : MonoBehaviour
{
    [SerializeField] float hitpoint = 10f;
    [SerializeField] float DestroyDelay = 10f;
    GameObject ZombieMesh;
    ZobieLimitController zobmieLimitController;

    [SerializeField] bool Boss = false;
    [SerializeField] TextMeshProUGUI BossHealthDisplay ; 
    
    
    void Start()
    {
        if(BossHealthDisplay != null)
        {BossHealthDisplay.enabled = false;}
        ZombieMesh = GameObject.FindWithTag("ZombieMesh");
        zobmieLimitController = FindObjectOfType<ZobieLimitController>();    
    }

    public void TakeDamage(float Damage)
{
    BroadcastMessage("EnemyDamageTaken");
    hitpoint = hitpoint - Damage;

    if (BossHealthDisplay != null)
    {
        if(Boss)
        {
            
            BossHealthDisplay.enabled = true;
            float BossHealth = hitpoint;
            BossHealthDisplay.text = ("BossHealth- " + BossHealth.ToString());
        }
        
    }
    if (hitpoint < 0)
        {
            zobmieLimitController.ZombieLimitDecreaser();
            
            StartCoroutine(DestroyObject());
        }
}

    IEnumerator DestroyObject()
    {
        GetComponent<EnemyAI>().enabled = false;
        GetComponent<Animator>().SetTrigger("Dead");
        GetComponent<CapsuleCollider>().enabled = false;
        yield return new WaitForSeconds(DestroyDelay);
        ZombieMesh.SetActive(false) ;
    }
}

