using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoints; // Три точки спавна
    public GameObject enemyPrefab;  // Префаб врага
    public float minSpawnTime;      // Минимальное время между спавнами
    public float maxSpawnTime;      // Максимальное время между спавнами

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            float spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(spawnTime);

            Vector3 spawnPosition = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
            Fabric.CreateEnemy(enemyPrefab, spawnPosition);
        }
    }
}
