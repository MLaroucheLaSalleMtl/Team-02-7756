using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

[System.Serializable]

public class Wave

{

    public int EnemiesPerWave;

    public GameObject Enemy;

}


public class EnemySpawn : MonoBehaviour
{
   // secondWave numberOfenemies;

    private bool countdownNextWave = false;
    PowerUp_DeleteAll NewCode;
    GameManager code; 
    private float timeBetweenWaves = 4f;
    public float timer;
    [SerializeField] public Text UIenemyLeft;
    [SerializeField] public Text UI_WaveDisplay;

    public GameObject NextWave;
    public Transform SpawnPos;

   // public bool IsAnewWave = false;
     
   // public ParticleSystem money;
    
    public Wave[] Waves;



    public float TimeBetweenEnemies = 2f;

    public int _totalEnemiesInCurrentWave;

    public int _enemiesInWaveLeft;

   public int _spawnedEnemies;



    private int _currentWave;

    private int _totalWaves;

     void WaveCount()
    {
       // timer = timeBetweenWaves;
        timer--;
        NextWave.GetComponent<Text>().text = timer.ToString();
        if (timer <= 1)
        {
            timer = 1;
           
        }

    }

    

    void Start()

    {
      //  numberOfenemies = FindObjectOfType<secondWave>();
        countdownNextWave = false;
        code = GameObject.Find("GameManager").GetComponent<GameManager>();
        NewCode = FindObjectOfType<PowerUp_DeleteAll>();
        _currentWave = -1;

        _totalWaves = Waves.Length - 1;


        StartNextWave();

        
    }



    void StartNextWave()

    {
       // IsAnewWave = true;
        _currentWave++;


        if (_currentWave > _totalWaves)

        {

            return;

        }

        
        _totalEnemiesInCurrentWave = Waves[_currentWave].EnemiesPerWave;
        _enemiesInWaveLeft = Waves[_currentWave].EnemiesPerWave 
            /*+ numberOfenemies.MaxEnemies*/;

        //_enemiesInWaveLeft = 0;

        _spawnedEnemies = 0;



        StartCoroutine(SpawnEnemies());

    }


    IEnumerator SpawnEnemies()

    {

        GameObject enemy = Waves[_currentWave].Enemy;

        while (_spawnedEnemies < _totalEnemiesInCurrentWave)

        {

            _spawnedEnemies++;
            Instantiate(enemy, SpawnPos.position, SpawnPos.rotation);

            yield return new WaitForSeconds(TimeBetweenEnemies);

        }

        yield return null;

    }

    void Update()
    {
        if (countdownNextWave == true)
        {
            NextWave.GetComponent<Text>().text = timer.ToString("F0");
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                countdownNextWave = false;
                timer = 0f;
            }
        }
        if (_enemiesInWaveLeft <= 0)
        {
            _enemiesInWaveLeft = 0;
        }
       
        int currentDisplayWave = _currentWave + 1;

        if (_currentWave >= _totalWaves)
        {
            _currentWave = _totalWaves;
            NextWave.SetActive(false);

            if (_enemiesInWaveLeft == 0 && _spawnedEnemies == _totalEnemiesInCurrentWave)
            {
                code.winGame();
                //int index = SceneManager.GetActiveScene().buildIndex;
                //PlayerPrefs.GetInt("levelPassed", index);

            }
        }
        UI_WaveDisplay.text = currentDisplayWave + " / " + Waves.Length;
        UIenemyLeft.text = _enemiesInWaveLeft.ToString();


    }



    public void EnemyDefeated()

    {

        _enemiesInWaveLeft--;
        

        if (_enemiesInWaveLeft == 0 && _spawnedEnemies == _totalEnemiesInCurrentWave )
        {
                     
                 Invoke("StartNextWave", timeBetweenWaves);
            timer = timeBetweenWaves;
            countdownNextWave = true;
          //  InvokeRepeating("WaveCount", 0, 1f);
           
            //StartCoroutine(waveCountDown());
        }

    }

}
