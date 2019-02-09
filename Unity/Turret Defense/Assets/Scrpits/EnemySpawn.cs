using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private Transform [] enemies;
    [SerializeField] private Transform SpawnPos;
    [SerializeField]
    private float spawningTime = 4f;
    private float spwanCountdown = 2f;
    private int waveNumber = 0;
    
    // Start is called before the first frame update

        IEnumerator WaveSpawner()
    {
        for(int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(1f); 
            
        }
        waveNumber++;
    }
    void SpawnEnemy()
    {
        Transform enemy = enemies[Random.Range(0, enemies.Length)];
        Instantiate(enemy.gameObject,SpawnPos.position,SpawnPos.rotation);
    }
    void Start()
    {
        Transform enemy = enemies[Random.Range(0, enemies.Length)];
        Instantiate(enemy.gameObject, SpawnPos.position, SpawnPos.rotation);
       
    }

    // Update is called once per frame
    void Update()
    {
        if (spwanCountdown <= 0f)
        {
            StartCoroutine(WaveSpawner());
            spwanCountdown = spawningTime;
        }
        spwanCountdown -= Time.deltaTime;
    }
}
