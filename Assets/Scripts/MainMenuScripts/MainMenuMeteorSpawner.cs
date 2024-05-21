using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MainMenuMeteorSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] meteors;
    [SerializeField] private bool moveRight;

    private List<GameObject> spawnedMeteorsList = new List<GameObject>();
    private float spawnTime_MIN = 3f, spawnTime_MAX = 5f;
    private float spawnTimer;
    private Vector3 spawnPosition;
    private float minY = -5f, maxY = 5f;
    private int spawnNumber = 0;
    private int activeMeteors;

    private void Start()
    {
        spawnTimer = Time.time + Random.Range(spawnTime_MIN, spawnTime_MAX);
        CreateInitialNumberOfMeteors(35);
    }

    private void Update()
    {
        /*if (Time.time > spawnTimer)
        {
            SpawnMeteors();
        }*/

        if (Time.time > spawnTimer)
        {
            SpawnMeteorsFromPool();
        }
    }

    private void SpawnMeteors()
    {

        spawnNumber = Random.Range(1, 8);

        for (int i = 0; i < spawnNumber; i++)
        {
            spawnPosition = new Vector3(transform.position.x, Random.Range(minY, maxY), 0f);
            GameObject newMeteor = Instantiate(meteors[Random.Range(0, meteors.Length)], spawnPosition, Quaternion.identity);
            
            if (moveRight)
                newMeteor.GetComponent<MeteorsMovement>().moveRight = true;

            newMeteor.transform.SetParent(transform);
        }

        spawnTimer = Time.time + Random.Range(spawnTime_MIN, spawnTime_MAX);
    }

    // Pooling
    void CreateInitialNumberOfMeteors(int spawnNumber)
    {
        for(int i = 0; i < spawnNumber; i++)
        {
            GameObject newMeteor = Instantiate(meteors[Random.Range(0, meteors.Length)]);
            newMeteor.transform.SetParent(transform);
            newMeteor.SetActive(false);
            spawnedMeteorsList.Add(newMeteor);
        }
    }

    void SpawnMeteorsFromPool()
    {
        spawnNumber = Random.Range(1, 8);
        activeMeteors = 0;

        for(int i = 0; i < spawnedMeteorsList.Count; i++)
        {
            if (!spawnedMeteorsList[i].activeInHierarchy)
            {
                spawnPosition = new Vector3(transform.position.x, Random.Range(minY, maxY), 0f);
                spawnedMeteorsList[i].SetActive(true);
                spawnedMeteorsList[i].transform.position = spawnPosition;

                //GameObject newMeteor = Instantiate(meteors[Random.Range(0, meteors.Length)], spawnPosition, Quaternion.identity);

                if (moveRight)
                    spawnedMeteorsList[i].GetComponent<MeteorsMovement>().moveRight = true;
                
                activeMeteors++;
                if (activeMeteors == spawnNumber)
                    break;
            }
        }
        
        spawnTimer = Time.time + Random.Range(spawnTime_MIN, spawnTime_MAX);
    }
}
