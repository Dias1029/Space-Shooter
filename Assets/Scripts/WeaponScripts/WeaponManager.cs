using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private GameObject[] weapons;
    [SerializeField] private Transform[] weaponSpawnPoints;
    [SerializeField] private float shootTimerRate = 0.2f;

    private float shootTimer;
    private bool playerCanShoot;

    private void Update()
    {
        if (Time.time > shootTimer)
            playerCanShoot = true;   

        HandlePlayerShooting();
    }

    void HandlePlayerShooting()
    {
        if (!playerCanShoot) // can not shoot
            return;

        if (Input.GetKeyDown(KeyCode.J)) // laser
        {
            Instantiate(weapons[0], weaponSpawnPoints[0].position, Quaternion.identity);

            Instantiate(weapons[0], weaponSpawnPoints[1].position, Quaternion.identity);

            ResetShootingRate();
        }

        if (Input.GetKeyDown(KeyCode.K)) // rocket 1
        {
            Instantiate(weapons[1], weaponSpawnPoints[2].position, Quaternion.identity);

            ResetShootingRate();
        }

        if (Input.GetKeyDown(KeyCode.L)) // rocket 2
        {
            Instantiate(weapons[2], weaponSpawnPoints[2].position, Quaternion.identity);

            ResetShootingRate();
        }

        if (Input.GetKeyDown(KeyCode.O)) // rocket 3
        {
            Instantiate(weapons[3], weaponSpawnPoints[2].position, Quaternion.identity);

            ResetShootingRate();
        }
    }

    void ResetShootingRate()
    {
        playerCanShoot = false;
        shootTimer = Time.time + shootTimerRate;
    }
}
