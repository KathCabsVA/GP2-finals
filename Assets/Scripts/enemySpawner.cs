using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoint;

    public float spawnInterval;
    public bool shouldSpawn = false;

    private Coroutine spawnCoroutine;

    private void Awake()
    {
        StartSpawn();
    }

    IEnumerator SpawnEnemies()
    {
        while (shouldSpawn)
        {
            int randomSpawnPoint = Random.Range(0, spawnPoint.Length);

            GameObject newEnemy = Instantiate(enemyPrefab, spawnPoint[randomSpawnPoint].position, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
    //this is getting called in button script whenever the player choose the "YES" button make the spawner start again
    public void StartSpawn()
    {
        shouldSpawn = true;
        // Restart the coroutine
        spawnCoroutine = StartCoroutine(SpawnEnemies());
    }
}
