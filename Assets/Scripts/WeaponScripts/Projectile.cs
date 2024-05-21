using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    [SerializeField] private AudioClip spawnSound;
    [SerializeField] private AudioClip destroySound;
    [SerializeField] private GameObject boomFX;

    public float minDamage = 5f;
    public float maxDamage = 6f;

    private float weaponDamage;

    private void Start()
    {
        weaponDamage = (int)Random.Range(minDamage, maxDamage);
    }

    private void OnEnable()
    {
        if (spawnSound)
            AudioSource.PlayClipAtPoint(spawnSound, new Vector3(0f, 6f, 0f));
    }

    private void Update()
    {
        transform.Translate(0f, speed * Time.deltaTime, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagManager.PLAYER_TAG))
            collision.GetComponent<PlayerHealth>().TakeDamage(weaponDamage);

        if (collision.CompareTag(TagManager.ENEMY_TAG) || collision.CompareTag(TagManager.METEOR_TAG))
        {
            if ((gameObject.GetComponent<SpriteRenderer>() && gameObject.GetComponent<SpriteRenderer>().flipY == true) || !collision.GetComponent<EnemyHealth>())
                return;
            collision.GetComponent<EnemyHealth>().TakeDamage(weaponDamage, 0f);
        }

        if (!collision.CompareTag(TagManager.NONTAGGED) && !collision.CompareTag(TagManager.ITEMS_TAG))
            gameObject.SetActive(false);
    }
}
