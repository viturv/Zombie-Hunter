using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZobieLimitController : MonoBehaviour
{

    [SerializeField] int ZombieKillLimit;

    public void ZombieLimitDecreaser()
    {
        ZombieKillLimit = ZombieKillLimit - 1;
        if(ZombieKillLimit == 0)
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex + 1);

        }
    }
    

}
