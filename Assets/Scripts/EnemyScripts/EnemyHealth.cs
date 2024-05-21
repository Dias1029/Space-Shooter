using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private GameObject hpBar;
    [SerializeField] private GameObject hit;
    [SerializeField] private GameObject destroy;
    [SerializeField] private float hp = 100f;

    private Vector3 hpScale;
    private ItemDrop itemDrop;

    private void Awake()
    {
        itemDrop = GetComponent<ItemDrop>();
    }

    public void TakeDamage(float damage, float resist)
    {
        if (!gameObject)
            return;

        damage -= resist;
        hp -= damage;

        if (hp <= 0)
        {
            hp = 0;
            Instantiate(destroy, transform.position, Quaternion.identity);

            if (gameObject.CompareTag(TagManager.ENEMY_TAG))
            {
                GamePlayUI.Instance.UpdateInfo(1);
                EnemySpawner.Instance.CheckSpawn(gameObject);
            }
            else if (gameObject.CompareTag(TagManager.METEOR_TAG))
            {
                GamePlayUI.Instance.UpdateInfo(2);
            }

            SoundManager.Instance.DestroySound();
            itemDrop.SpawnItem();
            Destroy(gameObject);
        }
        else
        {
            Instantiate(hit, transform.position, Quaternion.identity);
            SoundManager.Instance.DamageSound();
        }
        UpdateVisual();
    }

    void UpdateVisual()
    {
        if (!hpBar)
            return;

        hpScale = hpBar.transform.localScale;
        hpScale.x = hp / 100f;
        hpBar.transform.localScale = hpScale;
    }
}
