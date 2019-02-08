using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    private Transform Enemy;
    [SerializeField]
    private Transform SpawnPos;
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
        Instantiate(Enemy,SpawnPos.position,SpawnPos.rotation);
    }
    void Start()
    {
        Instantiate(Enemy, SpawnPos.position, SpawnPos.rotation);
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
