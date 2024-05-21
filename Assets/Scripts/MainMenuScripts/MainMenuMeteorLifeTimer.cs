using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMeteorLifeTimer : MonoBehaviour
{
    [SerializeField] private float timer = 13f;

    private void OnEnable()
    {
        Invoke("Deactivate", timer);
    }

    private void OnDisable()
    {
        CancelInvoke("Deactivate");
    }

    void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
