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

    private float timeBetweenWaves = 3f;
    private float timer;
    public GameObject WinPanel;
    [SerializeField] public Text UIenemyLeft;
    [SerializeField] public Text UI_WaveDisplay;

    public GameObject NextWave;
    public Transform SpawnPos;
    public ButtonBlocker index;




    public Wave[] Waves;



    public float TimeBetweenEnemies = 2f;

    private int _totalEnemiesInCurrentWave;

    public int _enemiesInWaveLeft;

    private int _spawnedEnemies;



    private int _currentWave;

    private int _totalWaves;

    IEnumerator waveCountDown()
    {
        timer = timeBetweenWaves;

        while (timeBetweenWaves >= 0)
        {
            NextWave.GetComponent<Text>().text = "Next Wave : " + timer.ToString();
            yield return new WaitForSeconds(1);
            timer--;
            if (timer <= 0)
            {
                timer = 0;
            }
        }
    }

    void Start()

    {

        _currentWave = -1;

        _totalWaves = Waves.Length - 1;


        StartNextWave();


    }



    void StartNextWave()

    {

        _currentWave++;


        if (_currentWave > _totalWaves)

        {

            return;

        }


        _totalEnemiesInCurrentWave = Waves[_currentWave].EnemiesPerWave;
        _enemiesInWaveLeft = Waves[_currentWave].EnemiesPerWave;

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
        int currentDisplayWave = _currentWave + 1;

        if (_currentWave >= _totalWaves)
        {
            _currentWave = _totalWaves;
            NextWave.SetActive(false);

            if (_enemiesInWaveLeft == 0 && _spawnedEnemies == _totalEnemiesInCurrentWave)
            {
                WinPanel.SetActive(true);
            }
        }
        UI_WaveDisplay.text = "Waves: " + currentDisplayWave + " / " + Waves.Length;
        UIenemyLeft.text = "Enemies Left: " + _enemiesInWaveLeft;


    }



    public void EnemyDefeated()

    {

        _enemiesInWaveLeft--;


        if (_enemiesInWaveLeft == 0 && _spawnedEnemies == _totalEnemiesInCurrentWave)

        {

            Invoke("StartNextWave", timeBetweenWaves);
            StartCoroutine(waveCountDown());
        }

    }

}
