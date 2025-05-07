using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] int Bandages = 5;
    [SerializeField] float RestoringHealth = 10f;
    [SerializeField] float RecoverTime = 10f;
    [SerializeField] float SpeedWhileHealing;
    [SerializeField] TextMeshProUGUI HealthUI;
    [SerializeField] TextMeshProUGUI BandageUI;

    float DefaultMoveSpeed;
    float DefautSprintSpeed;
    Weapon weapon;
    WeaponSwitcher weaponSwitcher;
    WeaponZoom weaponZoom;
    
    FirstPersonController firstPersonController;


    bool NotRecovering = true;
    
    void Start()
    {
        weapon = GetComponentInChildren<Weapon>();
        weaponSwitcher = GetComponentInChildren<WeaponSwitcher>();
        firstPersonController = GetComponent<StarterAssets.FirstPersonController>();
        weaponZoom = GetComponentInChildren<WeaponZoom>();
        DefaultMoveSpeed = (float) GetComponent<StarterAssets.FirstPersonController>().MoveSpeed;
        DefautSprintSpeed = (float) GetComponent<StarterAssets.FirstPersonController>().SprintSpeed;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H) && NotRecovering == true)
        {
            if(Bandages >0)
            {
                StartCoroutine(HealthRecover());
            }
        }

        HealthDisplayer();
    }

    void HealthDisplayer()
    {
        
        HealthUI.text =("Health - "+  health.ToString());
        BandageUI.text = ("Bandage - "+  Bandages.ToString());

    }

    IEnumerator HealthRecover()
    {
        if(health <=110)
        {

            ScriptController(false , SpeedWhileHealing , SpeedWhileHealing);
            health += RestoringHealth;
            Bandages--;

            if(health>110 && health<120)
            {
                health = 120;
            }

            yield return new WaitForSeconds(RecoverTime);
            ScriptController(true , DefaultMoveSpeed , DefautSprintSpeed);
        }
    }

    private void ScriptController(bool ScriptWorkController, float SpeedWhileHeal , float SprintSpeedControl)
    {
        NotRecovering = ScriptWorkController;
        weapon.enabled = ScriptWorkController;
        weaponSwitcher.enabled = ScriptWorkController;
        weaponZoom.enabled = ScriptWorkController;
        firstPersonController.MoveSpeed = SpeedWhileHeal;
        firstPersonController.SprintSpeed = SprintSpeedControl;
        
    }

    public void PlayerDamage(float Damage)
    {
        health =health -  Damage;
        if (health <= 0)
        {
            GetComponent<DeathHandler>().HandleDeath();

        }
    }

     
}
