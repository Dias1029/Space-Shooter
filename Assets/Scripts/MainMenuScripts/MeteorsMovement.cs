using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorsMovement : MonoBehaviour
{
    public bool moveRight;
    
    [SerializeField] private float speed_MIN = 4f, speed_MAX = 12f;
    [SerializeField] private bool move_X;

    private float speedOnX, speedOnY;
    private float rotateSpeed;
    private float rotateSpeed_MIN = 20f, rotateSpeed_MAX = 30f;
    private float rotate_Z;
    private Vector3 tempPosition;

    private void Awake()
    {
        speedOnY = Random.Range(speed_MIN, speed_MAX);
        speedOnX = speedOnY;

        rotateSpeed = Random.Range(rotateSpeed_MIN, rotateSpeed_MAX);

        if (Random.Range(0, 2) > 2)
            move_X = true;
        if (Random.Range(0, 2) > 2)
            speedOnX *= -1f;

        if (Random.Range(0, 2) > 2)
            rotateSpeed *= -1f;
    }

    private void Start()
    {
        if (moveRight)
        {
            speedOnX *= -1f;
        }
    }

    private void Update()
    {
        HandleMovement();
        HandleRotation();
    }

    void HandleMovement()
    {
        tempPosition = transform.position;
        tempPosition.x -= speedOnX * Time.deltaTime;
        transform.position = tempPosition;

        /*tempPosition = transform.position;
        tempPosition.y -= speedOnY * Time.deltaTime;
        transform.position = tempPosition;*/

        if (!move_X)
            return;

        /*tempPosition = transform.position;
        tempPosition.x += speedOnX * Time.deltaTime;
        transform.position = tempPosition;*/

        tempPosition = transform.position;
        tempPosition.y += speedOnY * Time.deltaTime;
        transform.position = tempPosition;
    }

    void HandleRotation()
    {
        rotate_Z += rotateSpeed * Time.deltaTime;
        transform.rotation = Quaternion.AngleAxis(rotate_Z, Vector3.forward);
    }
}
