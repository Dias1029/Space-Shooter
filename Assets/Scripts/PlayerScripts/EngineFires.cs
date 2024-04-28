using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineFires : MonoBehaviour
{
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private ParticleSystem[] engineFires;
    [SerializeField] private int enginePower = 3;

    private void Update()
    {
        HandleEngineFire();
    }

    void HandleEngineFire()
    {
        if (joystick.Vertical > 0) // Up
        {
            Emit(2, enginePower);
            Emit(3, enginePower);
        }

        if (joystick.Vertical < 0) // Down
        {
            Emit(4, enginePower);
            Emit(5, enginePower);
        }

        if (joystick.Horizontal > 0) // Right
        {
            Emit(1, enginePower);
        }

        if (joystick.Horizontal < 0) // Left
        {
            Emit(0, enginePower);
        }
    }

    void Emit(int engineIndex, int enginePower)
    {
        engineFires[engineIndex].Emit(enginePower);
    }
}
