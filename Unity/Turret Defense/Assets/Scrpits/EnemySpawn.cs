using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private Transform [] enemies;
    [SerializeField] private Transform SpawnPos;
    [SerializeField] private Image healthbar;
    public float starthealth = 100;
    private float health;
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

    //Tianfang march 2nd
    public void TakeDamage(float damage)
    {
        //enemy take damage as float damage
        health -= damage;
        healthbar.fillAmount = health/starthealth;
        if (health<=0)
        {
            Destroy(gameObject);
            Destroy(healthbar);
        }
    }

    void SpawnEnemy()
    {
        Transform enemy = enemies[Random.Range(0, enemies.Length)];
        Instantiate(enemy.gameObject,SpawnPos.position,SpawnPos.rotation);
        healthbar.transform.SetParent(healthbar.transform, false);
    }
    void Start()
    {
        Transform enemy = enemies[Random.Range(0, enemies.Length)];
        Instantiate(enemy.gameObject, SpawnPos.position, SpawnPos.rotation);
        health = starthealth;
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
        //tianfang march 2nd
        healthbar.transform.position = Camera.main.WorldToScreenPoint(Vector3.up * 1) + transform.position;
    }
}
