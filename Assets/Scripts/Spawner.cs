using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject lowEnemy;
    [SerializeField] private float spawnTime;
    [SerializeField] private float spawnDelay;
    //private static int enemies;
    [SerializeField] private GameObject[] counterEnemies;
    void Start()
    {
        //enemies = 0;
        InvokeRepeating ("SpawnEnemy", spawnTime, spawnDelay);
    }
    void FixedUpdate()
    {   
        counterEnemies = GameObject.FindGameObjectsWithTag("LowEnemy");
        
        if (counterEnemies.Length >= 3)
            CancelInvoke("SpawnEnemy");
        else
            InvokeRepeating("SpawnEnemy", spawnTime, spawnDelay);
    }
    public void SpawnEnemy ()
    {
        Instantiate(lowEnemy, transform.position, transform.rotation);
        //enemies++;
    }
    
    
}
