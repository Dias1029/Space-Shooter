using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance;

    [SerializeField] private GameObject[] enemies;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float waitingForSpawnTime = 3f;

    private List<GameObject> spawnedEnemies = new List<GameObject>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        StartCoroutine(SpawnWave(waitingForSpawnTime));
    }

    void SpawnNewWave()
    {
        if (spawnedEnemies.Count > 0)
            return;

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            int randomIndex = Random.Range(0, enemies.Length);
            GameObject enemy = Instantiate(enemies[randomIndex], spawnPoints[i].position, Quaternion.Euler(0, 0, -90));

            spawnedEnemies.Add(enemy);
        }

        GamePlayUI.Instance.UpdateInfo(0);
    }

    IEnumerator SpawnWave(float waitingTime)
    {
        yield return new WaitForSeconds(waitingTime);
        SpawnNewWave();
    }

    public void CheckSpawn(GameObject shipToRemove)
    {
        spawnedEnemies.Remove(shipToRemove);

        if (spawnedEnemies.Count == 0)
        {
            StartCoroutine(SpawnWave(waitingForSpawnTime));
        }
    }
}
