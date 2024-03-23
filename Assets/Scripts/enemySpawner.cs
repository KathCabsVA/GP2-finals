using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoint;

    public float spawnInterval;
    public bool shouldSpawn;

    private Coroutine spawnCorotine;

    private void Start()
    {
        spawnCorotine = StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while(shouldSpawn)
        {
            int randomSpawnPoint = Random.Range(0, spawnPoint.Length);

            GameObject newEnemy = Instantiate(enemyPrefab, spawnPoint[randomSpawnPoint].position, Quaternion.identity);

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    //this is getting called in PlayerScript to stop spawning whenever an enemy collided with the player
    public void StopSpawning()
    {
        shouldSpawn = false;
        Debug.Log("stop spawning");
    }
    //this is getting called in button script whenever the player choose the "YES" button make the spawner start again
    public void RestartSpawning()
    {
        shouldSpawn = true;
        Debug.Log("Restart spawning");
        // Restart the coroutine
        spawnCorotine = StartCoroutine(SpawnEnemies());
    }
}
    