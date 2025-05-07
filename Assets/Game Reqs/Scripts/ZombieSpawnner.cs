using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ZombieSpawnner : MonoBehaviour
{
    [SerializeField] GameObject ZombiePrefab ; 
    GameObject ZombieParent;
    [SerializeField] float SpawnDelay = 1.5f;
    [SerializeField] int NoOfZombiesToSpawn =5;
    [SerializeField]Vector3 Position;
    Quaternion Rotation;

    void Start()
    {
        
        ZombieParent = GameObject.Find("Zombie spawner"); 

    if (ZombieParent != null)
    {
        StartCoroutine(StartSpawning());
    }
   
    }

    IEnumerator StartSpawning()
    {
        for (int i = 0; i < NoOfZombiesToSpawn; i++)
        {
            yield return StartCoroutine(SpawnDelayer());
        }
    }


    void SpawnZombies(GameObject Prefab ,Vector3 Position , Quaternion Rotation)
    {
        GameObject SpawnedZombie =Instantiate(Prefab,Position,Rotation);
    }   

    IEnumerator SpawnDelayer()
    {
        SpawnZombies(ZombiePrefab , Position , Rotation);
        yield return new WaitForSeconds(SpawnDelay);
    }
}
