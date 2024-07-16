using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Fabric
{
    public static GameObject CreateEnemy(GameObject enemyPrefab, Vector3 spawnPosition)
    {
        return Object.Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
