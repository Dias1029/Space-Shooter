using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgrade : MonoBehaviour
{
    [SerializeField] private Upgrade weaponUpgrade;

    private Item item;
    
    void DestroyItem(Item item)
    {
        if (item.type != ItemType.Health)
            Destroy(item.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagManager.ITEMS_TAG))
        {
            item = collision.GetComponent<Item>();

            if (item.type == ItemType.Rocket1)
            {
                weaponUpgrade.WeaponActivation(0);
                GamePlayUI.Instance.ActivateButtonVisual(1);
            }

            DestroyItem(item);
        }

        if (collision.CompareTag(TagManager.ITEMS_TAG))
        {
            item = collision.GetComponent<Item>();

            if (item.type == ItemType.Rocket2)
            {
                weaponUpgrade.WeaponActivation(1);
                GamePlayUI.Instance.ActivateButtonVisual(2);
            }

            DestroyItem(item);
        }

        if (collision.CompareTag(TagManager.ITEMS_TAG))
        {
            item = collision.GetComponent<Item>();

            if (item.type == ItemType.Rocket3)
            {
                weaponUpgrade.WeaponActivation(2);
                GamePlayUI.Instance.ActivateButtonVisual(3);
            }

            DestroyItem(item);
        }
    }
}
