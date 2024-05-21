using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementPointToPoint : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    [SerializeField] private float speed = 8f;

    private int currentIndex;
    private Vector3 targetPos;
    [SerializeField] private bool randomMovement;

    private void Start()
    {
        SetTargetPosition();
    }

    private void Update()
    {
        Move();
    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPos) < 0.1f)
        {
            SetTargetPosition();
        }
    }

    void SetTargetPosition()
    {
        if (randomMovement)
            SelectRandomMovement();
        else
            SelectPointToPointMovement();
    }

    void SelectRandomMovement()
    {
        while (points[currentIndex].position == targetPos)
        {
            currentIndex = UnityEngine.Random.Range(0, points.Length);
        }

        targetPos = points[currentIndex].position;
    }

    void SelectPointToPointMovement()
    {
        if (currentIndex == points.Length)
            currentIndex = 0;

        targetPos = points[currentIndex].position;

        currentIndex++;
    }
}
