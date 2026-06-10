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
        StartCoroutine(SpawnPowerUpsDelay());
    }

    public void SpawnPowerUp()
    {
      
            Transform spawnpointRandom = PowerUpsSpawnPoints[Random.Range(0, PowerUpsSpawnPoints.Length)];
            Instantiate(PowerUpPrefab[Random.Range(0, PowerUpPrefab.Length)], spawnpointRandom.position, Quaternion.identity);

            StartCoroutine(SpawnPowerUpsDelay());

    }

    IEnumerator SpawnPowerUpsDelay()
    {
        
        yield return new WaitForSeconds(10);
        SpawnPowerUp();
        
    }
}