using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpawnPosition
{
    Right,
    Left,
    Top, 
    Bottom
}

public class MainMenuSpaceshipSpawner : MonoBehaviour
{
    public SpawnPosition spawnPosition;

    [SerializeField] private GameObject[] spaceships;
    [SerializeField] private float spawnTime_MIN = 5f, spawnTime_MAX = 10f;
    [SerializeField] private float minY = -5f, maxY = 5f;
    [SerializeField] private float minX = -9f, maxX = 9f;

    private List<GameObject> spawnedShips = new List<GameObject>();
    private float spawnTimer;
    private bool shipSpawned;
    private Vector3 spawnPos;

    private void Update()
    {
        if (Time.time > spawnTimer)
            SpawnShip();
    }

    void SpawnShip()
    {
        shipSpawned = false;

        for (int i = 0; i < spawnedShips.Count; i++)
        {
            if (!spawnedShips[i].activeInHierarchy)
            {
                ActivateShip(spawnedShips[i], false);
                shipSpawned = true;
            }
        }

        if (!shipSpawned)
        {
            GameObject newShip = Instantiate(spaceships[Random.Range(0, spaceships.Length)]);
            ActivateShip(newShip, true);
        }

        spawnTimer = Time.time + Random.Range(spawnTime_MIN, spawnTime_MAX);
    }

    void ActivateShip(GameObject ship, bool addToList)
    {
        ship.SetActive(true);
        ship.transform.SetParent(transform);

        if (spawnPosition == SpawnPosition.Top)
        {
            spawnPos = new Vector3(Random.Range(minX, maxX), transform.position.y, 0f);
            ship.transform.position = spawnPos;
            ship.GetComponent<MainMenuSpaceshipMovement>().UpdateMovement(true, false, true);
        }

        else if (spawnPosition == SpawnPosition.Bottom)
        {
            spawnPos = new Vector3(Random.Range(minX, maxX), transform.position.y, 0f);
            ship.transform.position = spawnPos;
            ship.GetComponent<MainMenuSpaceshipMovement>().UpdateMovement(true, false, false);
        }

        else if (spawnPosition == SpawnPosition.Left)
        {
            spawnPos = new Vector3(transform.position.x, Random.Range(minY, maxY), 0f);
            ship.transform.position = spawnPos;
            ship.GetComponent<MainMenuSpaceshipMovement>().UpdateMovement(false, true, false);
        }

        else if (spawnPosition == SpawnPosition.Right)
        {
            spawnPos = new Vector3(transform.position.x, Random.Range(minY, maxY), 0f);
            ship.transform.position = spawnPos;
            ship.GetComponent<MainMenuSpaceshipMovement>().UpdateMovement(false, true, true);
        }

        if (addToList) 
            spawnedShips.Add(ship);
    }
}
