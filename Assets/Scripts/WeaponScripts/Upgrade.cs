using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    [SerializeField] private Pooling[] weapons;

    public void WeaponActivation(int weaponIndex)
    {
        weapons[weaponIndex].enabled = true; 
    }
}
