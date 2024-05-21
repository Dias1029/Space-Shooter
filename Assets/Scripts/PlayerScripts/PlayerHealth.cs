using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHP = 100f;
    [SerializeField] private GameObject explosionEffect;
    [SerializeField] private GameObject damageEffect;
    
    
    private float playerHP;
    private Item item;
    private Slider playerHPSlider;

    private void Awake()
    {
        playerHPSlider = GameObject.FindWithTag(TagManager.PLAYER_HEALTH_TAG).GetComponent<Slider>();
        playerHP = maxHP;
        playerHPSlider.minValue = 0;
        playerHPSlider.maxValue = playerHP;
        playerHPSlider.value = playerHP;
    }

    public void TakeDamage(float damage)
    {
        playerHP -= damage;
        playerHPSlider.value = playerHP;

        if (playerHP <= 0)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
            SoundManager.Instance.DestroySound();
            GameOverUIController.Instance.GameOverCanvasOpen();
            Destroy(gameObject);
        }
        else
        {
            Instantiate(damageEffect, transform.position, Quaternion.identity);
            SoundManager.Instance.DamageSound();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagManager.METEOR_TAG))
        {
            TakeDamage(Random.Range(20, 40));
        }
        if (collision.CompareTag(TagManager.ITEMS_TAG))
        {
            item = collision.GetComponent<Item>();

            if (item.type == ItemType.Health)
            {
                playerHP += item.health;

                if (playerHP > maxHP)
                    playerHP = maxHP;

                playerHPSlider.value = playerHP;

                Destroy(item.gameObject);
            }
        }
    }
}
