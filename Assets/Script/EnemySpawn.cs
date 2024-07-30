using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnRadius = 8;
    public float timeBetweenSpawn = 1;

    public float timeTilSpawn = 0;

    public GameObject enemyPrefab;

    void Update()
    {
        // Timer
        timeTilSpawn -= Time.deltaTime; //FIX form  = to -=

        if (timeTilSpawn < 0)
        {
            Spawn();
            timeTilSpawn = timeBetweenSpawn;
        }
    }

    void Spawn()
    {
        // Random Spawn Position
        Vector2 randDir = Random.insideUnitCircle.normalized;
        Vector2 spawnPos = randDir * spawnRadius;

        // Spawn
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}