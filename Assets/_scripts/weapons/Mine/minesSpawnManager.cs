using System;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class minesSpawnManager : MonoBehaviour
{
    public static minesSpawnManager instance; //this
    public GameObject minesPrefab;
    public bool canSpawn;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawn)
        {
            SpawnMines();
        }
    }

    async UniTask SpawnMines()
    {
        canSpawn = false;
        await UniTask.Delay(TimeSpan.FromSeconds(5));
        Instantiate(minesPrefab, transform.position, Quaternion.identity);
        canSpawn = true;
    }
}