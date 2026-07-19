using System;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class WavesManager : MonoBehaviour
{
    
    public static WavesManager Instance { get; private set; }
    [Header("Wave Settings")] public int currentWave;
    public float timeBetweenWaves;

    [Header("Enemies")] public GameObject basicEnemyPrefab;
    public GameObject RangedEnemyPrefab;
    public GameObject laserGatingEnemyPrefab;
    public List<GameObject> livingEnemies = new List<GameObject>();
    [Header("Spawn points")] public Transform[] spawnPoints;

    [SerializeField] public int enemiesAlive = 0;
    private bool waveInProgress = false;
    
    //enemies SO
    public EnemiesStatsSO BasicEnemySO;
    private void Awake()
    {
        Instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(StartNextWave());
    }

    public IEnumerator StartNextWave()
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        currentWave++;
        waveInProgress = true;
        SpawnWave();

        BasicEnemySO.health++;
    }

    public void SpawnWave()
    {
        waveInProgress = true;
        livingEnemies.Clear();
        List<GameObject> enemiesToSpawn = GetWaveComposition();

        foreach (GameObject enemyprefab in enemiesToSpawn)
        {
            Transform spawnpoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            GameObject spawnedEnemy = Instantiate(enemyprefab, spawnpoint.position, Quaternion.Euler(0, 0, 0));
            livingEnemies.Add(spawnedEnemy);
            enemiesAlive++;
        }

        // StartCoroutine(StartNextWave());
    }

    List<GameObject> GetWaveComposition()
    {
        List<GameObject> list = new List<GameObject>();
        int count = 3 + (currentWave * 2);

        for (int i = 0; i < count; i++)
        {
            if (currentWave >= 2 && Random.value < 0.2f)
                list.Add(laserGatingEnemyPrefab);
            else if (currentWave >= 2 && Random.value < 0.3f)
                list.Add(RangedEnemyPrefab);
            else
                list.Add(basicEnemyPrefab);
        }

        return list;
    }
    
    public void OnEnemyDied(GameObject enemy)
    {
        enemiesAlive --;
        livingEnemies.Remove(enemy);

        if (enemiesAlive <= 0 && waveInProgress)
        {
            waveInProgress = false;
            //tartCoroutine(StartNextWave());
            UpgradesManager.instance.ShowUpgradeScreen();
        }
    }
}