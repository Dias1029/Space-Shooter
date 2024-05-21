using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    [SerializeField] private float minSpeed, maxSpeed;
    [SerializeField] private float rotationSpeed_Max = 50f, rotationSpeed_Min = 15f;

    private float speedX, speedY;
    private bool moveX, moveY = true;
    private float rotationSpeed;
    private Vector3 tempMovement;
    private float rotationZ;

    private void Awake()
    {
        rotationSpeed = Random.Range(rotationSpeed_Min, rotationSpeed_Max);

        speedX = Random.Range(minSpeed, maxSpeed);
        speedY = speedX;

        if (Random.Range(0, 2) > 0)
            speedX *= -1f;
        if (Random.Range(0, 2) > 0)
            rotationSpeed *= -1f;
        if (Random.Range(0, 2) > 0)
            moveX = true;
    }

    private void Update()
    {
        HandleMovementX();
        HandleMovementY();
        HandleRotation();
    }

    private void HandleMovementX()
    {
        if (!moveX)
            return;

        tempMovement = transform.position;
        tempMovement.x += speedX * Time.deltaTime;
        transform.position = tempMovement;
    }

    private void HandleMovementY()
    {
        if (!moveY)
            return;

        tempMovement = transform.position;
        tempMovement.y -=speedY * Time.deltaTime;
        transform.position = tempMovement;
    }

    private void HandleRotation()
    {
        rotationZ += rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.AngleAxis(rotationZ, Vector3.forward);
    }

}
