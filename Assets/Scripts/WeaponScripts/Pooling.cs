using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Pooling : MonoBehaviour
{
    [SerializeField] private GameObject weapon;
    [SerializeField] private GameObject weaponHolder;
    [SerializeField] private KeyCode shootKey;
    [SerializeField] private Transform weaponSpawnPoint;
    [SerializeField] private float shootWaiting = 0.2f;
    [SerializeField] private bool isEnemy;
    [SerializeField] private Button buttons;

    [SerializeField] private List<GameObject> weaponPool = new List<GameObject>();
    private bool weaponSpawned;
    private float shootTimer;
    private bool canShoot;

    private void Awake()
    {
        if (isEnemy)
        {
            weaponHolder = GameObject.FindWithTag(TagManager.ENEMY_WEAPON_HOLDER_TAG);
        }
        else
        {
            weaponHolder = GameObject.FindWithTag(TagManager.PLAYER_WEAPON_HOLDER_TAG);
        }
    }

    private void Update()
    {
        if (Time.time > shootTimer)
        {
            canShoot = true;
        }

        HandlePlayerShooting();
        HandleEnemyShooting();
    }

    void HandlePlayerShooting()
    {
        if (!canShoot || isEnemy)
            return;
        /*if (Input.GetKeyDown(shootKey))
        {
            GetFromPool();
            ResetShooting();
        }*/
    }

    public void OnClickShoot()
    {
        GetFromPool();
        ResetShooting();
    }

    void GetFromPool()
    {
        for (int i = 0; i < weaponPool.Count; i++)
        {
            if (!weaponPool[i].activeInHierarchy)
            {
                weaponPool[i].transform.position = weaponSpawnPoint.position;
                weaponPool[i].SetActive(true);

                weaponSpawned = true;

                break;
            }
            else
            {
                weaponSpawned = false;
            }
        }

        if (!weaponSpawned)
        {
            GameObject g = Instantiate(weapon, weaponSpawnPoint.position, Quaternion.identity);

            weaponPool.Add(g);

            g.transform.SetParent(weaponHolder.transform);

            weaponSpawned = true;
        }
    }

    void ResetShooting()
    {
        canShoot = false;

        if (isEnemy)
            shootTimer = Time.time + Random.Range(shootTimer, (shootWaiting = 1f));
        else
            shootTimer = Time.time + shootWaiting;
    }

    void HandleEnemyShooting()
    {

    }
}
