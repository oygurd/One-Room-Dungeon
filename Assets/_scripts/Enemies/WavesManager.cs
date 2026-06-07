using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class WavesManager : MonoBehaviour
{
    [Header("Wave Settings")] public int currentWave;
    public float timeBetweenWaves = 5;

    [Header("Enemies")] public GameObject basicEnemyPrefab;


    [Header("Spawn points")] public Transform[] spawnPoints;

    private int enemiesAlive = 0;
    private bool waveInProgress = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(StartNextWave());
    }

    IEnumerator StartNextWave()
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        currentWave++;
        waveInProgress = true;
    }

    public void SpawnWave()
    {
        waveInProgress = true;
        List<GameObject> enemiesToSpawn = GetWaveComposition();

        foreach (GameObject enemyprefab in enemiesToSpawn)
        {
            Transform spawnpoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(basicEnemyPrefab, spawnpoint.position, Quaternion.identity);
            enemiesAlive++;
        }
    }

    List<GameObject> GetWaveComposition()
    {
        List<GameObject> list = new List<GameObject>();
        int count = 3 + (currentWave * 2);

        for (int i = 0; i < count; i++)
        {
            if (currentWave >= 3 && Random.value < 0.2f)
                list.Add(basicEnemyPrefab);
        }

        return list;
    }
}


