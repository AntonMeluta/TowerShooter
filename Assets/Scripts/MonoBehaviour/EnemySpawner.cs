using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float intervalCurrent;
    private int countSpawnEnemyCurrent;
    private int counterKills;  
    private int countWave;

    [SerializeField]
    private int countSpawnAverage = 4;
    [SerializeField]
    private GameSettings gameSettings;
    [SerializeField]
    private PoolObject poolEnemies;
    [SerializeField]
    private float intervalSpawnAverage = 3;
    [SerializeField]
    private Transform[] allTransformsSpawn;

    private void OnEnable()
    {
        EventsBroker.OnPlayerToWar += StartingSpawnProcess;
        EventsBroker.OnPlayerKill += CheckNextWave;
    }

    private void OnDisable()
    {
        EventsBroker.OnPlayerToWar -= StartingSpawnProcess;
        EventsBroker.OnPlayerKill -= CheckNextWave;
    }

    private void Start()
    {
        counterKills = 0;
        countWave = 1;
        SetIntervalSpawn();
        SetCountSpawn();
    }

    private void SetCountSpawn()
    {
        switch (gameSettings.DifficultyGame)
        {
            case DifficultyGame.easy:
                countSpawnEnemyCurrent = countSpawnAverage - 2;
                break;
            case DifficultyGame.middle:
                countSpawnEnemyCurrent = countSpawnAverage;
                break;
            case DifficultyGame.hard:
                countSpawnEnemyCurrent = countSpawnAverage + 2;
                break;
            default:
                break;
        }
    }

    private void CheckNextWave()
    {
        counterKills++;
        if (counterKills >= countSpawnEnemyCurrent)
        {
            counterKills = 0;
            countWave++;
            Invoke("NewWaveWithDelay", 2.1f);     
        }
    }

    private void NewWaveWithDelay()
    {
        StartingSpawnProcess();
    }

    private void SetIntervalSpawn()
    {
        switch (gameSettings.DifficultyGame)
        {
            case DifficultyGame.easy:
                intervalCurrent = intervalSpawnAverage + 1;
                break;
            case DifficultyGame.middle:
                intervalCurrent = intervalSpawnAverage;
                break;
            case DifficultyGame.hard:
                intervalCurrent = intervalSpawnAverage - 1;
                break;
            default:
                break;
        }
    }
    
    private void StartingSpawnProcess()
    {
        EventsBroker.NewWaveEvent(countWave);

        for (int i = 0; i < countSpawnEnemyCurrent; i++)
        {
            GameObject enemy = poolEnemies.GetPooledObject();
            enemy.transform.position = allTransformsSpawn[i].position;
            enemy.SetActive(true);
        }
    }

}
