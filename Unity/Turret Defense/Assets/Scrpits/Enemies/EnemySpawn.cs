using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawn : MonoBehaviour
{

    [SerializeField] private Transform [] enemies;
    [SerializeField] private Transform SpawnPos;
    [SerializeField] private Image healthbar;
    //public float starthealth = 100f;
    //private float Currenthealth;
    private float spawningTime = 4f;
    private float spwanCountdown = 2f;
    private int waveNumber = 0;
    [SerializeField] private int CountEnemy;
    [SerializeField] private int CurrentEnemy;
    public GameObject GameOverPanel;
    [SerializeField] private Text UIenemyLeft;
    private int MaxEnemyLv1 = 10;
    public int enemyLeft;
 
    

    // Start is called before the first frame update

        IEnumerator WaveSpawner()
    {
        for(int i = 0; i < waveNumber; i++)
        {
            if (CountEnemy < MaxEnemyLv1)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(1f);
            }
        }
        waveNumber++;
    }

    //Tianfang march 2nd
    //public void TakeDamage(float damage)
    //{
    //    //enemy take damage as float damage
    //    Currenthealth -= damage;
    //    healthbar.fillAmount = Currenthealth/starthealth;
    //    if (Currenthealth<=0)
    //    {
    //        Destroy(gameObject);
    //        Destroy(healthbar);
    //        enemyLeft--;
    //    }
    //}

    void SpawnEnemy()
    {
        
        Transform enemy = enemies[Random.Range(0, enemies.Length)];
        Instantiate(enemy.gameObject,SpawnPos.position,SpawnPos.rotation);
        CountEnemy++;
       // healthbar.transform.SetParent(healthbar.transform, false);
    }
    void Start()
    {
        enemyLeft = MaxEnemyLv1;
        Transform enemy = enemies[Random.Range(0, enemies.Length)];
        Instantiate(enemy.gameObject, SpawnPos.position, SpawnPos.rotation);
       // Currenthealth = starthealth;
    }

    // Update is called once per frame
    void Update()
    {
        UIenemyLeft.text = "Enemies Left: " + enemyLeft;
        GameObject[] enemyAlive = GameObject.FindGameObjectsWithTag("Enemy");
        CurrentEnemy = enemyAlive.Length;
        
        if (spwanCountdown <= 0f)
        {
            StartCoroutine(WaveSpawner());
            spwanCountdown = spawningTime;
        }
        spwanCountdown -= Time.deltaTime;

        if (CountEnemy==MaxEnemyLv1&&CurrentEnemy==0)
        {
            GameOverPanel.SetActive(true);
        }
        //tianfang march 2nd
        //    healthbar.transform.position = Camera.main.WorldToScreenPoint(Vector3.up * 1) + transform.position;
    }
}
