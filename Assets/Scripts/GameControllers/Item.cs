using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Rocket1,
    Rocket2,
    Rocket3,
    Damage,
    Health,
    SpeedDebuff
}

public class Item : MonoBehaviour
{
    public ItemType type;

    [SerializeField] private float speed = 5f;

    private Vector3 tempPosition;
    private float minHP = 10f;
    private float maxHP = 40f;

    public float health;

    private void Start()
    {
        health = Random.Range(minHP, maxHP);
    }

    private void Update()
    {
        tempPosition = transform.position;
        tempPosition.y -= speed * Time.deltaTime;
        transform.position = tempPosition;
    }

    private void OnDisable()
    {
        SoundManager.Instance.PickUpSound();
    }
}
