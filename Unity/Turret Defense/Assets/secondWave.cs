using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class secondWave : MonoBehaviour
{
    EnemySpawn FirstSpawn;

    private float nextCallingTime = 0.0f;
    private float period = 0.1f;
    public Transform SecSwaner;
    public bool StartToSpawn = false;
    PlayerAssets MoneyAccumulate;

    public GameObject[] enemies;
    public float spawnTime = 5f;

    public int MaxEnemies = 5;
    private int CountEnmies = 0;
    
    void Spawn()
    {
        Instantiate(enemies[UnityEngine.Random.Range(0, enemies.Length - 1)], SecSwaner.position, SecSwaner.rotation);
        CountEnmies++;
    }

    //void CheckStatus()
    //{
    //    if (StartToSpawn == true)
    //    {
    //        InvokeRepeating("Spawn", spawnTime, spawnTime);
    //    }
    //}

    // Start is called before the first frame update
    void Start()
    {
        MoneyAccumulate = FindObjectOfType<PlayerAssets>();
        FirstSpawn = FindObjectOfType<EnemySpawn>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (MoneyAccumulate.moneyLeft >= 1000)
        {
            StartToSpawn = true;
        }
        
        if (CountEnmies == MaxEnemies)
        {
            CancelInvoke();
            
        }

        if (Time.deltaTime > nextCallingTime&&StartToSpawn==true&&FirstSpawn.IsAnewWave==true)
        {
            nextCallingTime += period;
            InvokeRepeating("Spawn", spawnTime, spawnTime);
        }
        if (CountEnmies == MaxEnemies)
        {
            CancelInvoke();
        }
    }
}
