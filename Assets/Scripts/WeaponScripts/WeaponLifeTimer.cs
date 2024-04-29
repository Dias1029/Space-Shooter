using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLifeTimer : MonoBehaviour
{
    [SerializeField] private float lifeTimer = 3f;

    private void OnEnable()
    {
        Invoke("DeactivateWeapon", lifeTimer);
    }

    private void OnDisable()
    {
        CancelInvoke("DeactivateWeapon");
    }

    void DeactivateWeapon()
    {
        if (gameObject.activeInHierarchy)
            gameObject.SetActive(false);
    }
}
