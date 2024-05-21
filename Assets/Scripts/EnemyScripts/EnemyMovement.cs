using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private bool moveX;
    [SerializeField] private bool moveY;
    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private float hMoveThreshold = 8f;
    [SerializeField] private float vMoveThreshold = 10f;

    private float minX;
    private float maxX;

    private float minY;
    private float maxY;

    private Vector3 tempMovementHorizontal;
    private Vector3 tempMovementVertical;

    private bool moveLeft;
    private bool moveUp = false;

    private void Start()
    {
        minX = transform.position.x - hMoveThreshold;
        maxX = transform.position.x + hMoveThreshold;

        maxY = transform.position.y;
        minY = transform.position.y - vMoveThreshold;

        if (Random.Range(0, 2) > 0)
            moveLeft = true;
    }

    private void Update()
    {
        HandleEnemyHorizontalMovement();
        HandleEnemyVerticalMovement();
    }

    void HandleEnemyHorizontalMovement()
    {
        if (!moveX)
            return;

        if (moveLeft)
        {
            tempMovementHorizontal = transform.position;
            tempMovementHorizontal.x -= moveSpeed * Time.deltaTime;
            transform.position = tempMovementHorizontal;

            if (tempMovementHorizontal.x < minX)
                moveLeft = false;
        }
        else
        {
            tempMovementHorizontal = transform.position;
            tempMovementHorizontal.x += moveSpeed * Time.deltaTime;
            transform.position = tempMovementHorizontal;

            if (tempMovementHorizontal.x > maxX)
                moveLeft = true;
        }
    }

    void HandleEnemyVerticalMovement()
    {
        if (!moveY)
            return;

        if (moveUp)
        {
            tempMovementVertical = transform.position;
            tempMovementVertical.y += moveSpeed * Time.deltaTime;
            transform.position = tempMovementVertical;

            if (tempMovementVertical.y > maxY)
                moveUp = false;
        }
        else 
        {
            tempMovementVertical = transform.position;
            tempMovementVertical.y -= moveSpeed * Time.deltaTime;
            transform.position = tempMovementVertical;

            if (tempMovementVertical.y < minY)
                moveUp = true;
        }
    }
}
