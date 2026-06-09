using System.Collections;
using NUnit.Framework.Interfaces;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public Transform[] PowerUpsSpawnPoints;

    public GameObject[] PowerUpPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    

    IEnumerator SpawnPowerUpsDelay()
    {
        foreach (Transform spawnPoint in PowerUpsSpawnPoints)
        {
            Transform spawnpointRandom = PowerUpsSpawnPoints[Random.Range(0, PowerUpsSpawnPoints.Length)];
            Instantiate(PowerUpPrefab[Random.Range(0, PowerUpPrefab.Length)], spawnPoint.position, Quaternion.identity);
        }

        yield return new WaitForSeconds(10);
    }
}