using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] meteors;
    [SerializeField] private float minX, maxX;
    [SerializeField] private float spawnRate_Min = 4f, spawnRate_Max = 10f;
    [SerializeField] private int spawnMeteors_Min, spawnMeteors_Max;

    private int randomSpawnNumber;
    private Vector3 randomSpawnPosition;

    private void Start()
    {
        Invoke("Spawn", Random.Range(spawnRate_Min, spawnRate_Max));
    }

    void Spawn()
    {
        randomSpawnNumber = Random.Range(spawnMeteors_Min, spawnMeteors_Max);

        for (int i = 0; i < randomSpawnNumber; i++)
        {
            randomSpawnPosition = new Vector3(Random.Range(minX, maxX), transform.position.y, 0f);
            Instantiate(meteors[Random.Range(0, meteors.Length)], randomSpawnPosition, Quaternion.identity);
        }

        Invoke("Spawn", Random.Range(spawnRate_Min, spawnRate_Max));
    }
}
