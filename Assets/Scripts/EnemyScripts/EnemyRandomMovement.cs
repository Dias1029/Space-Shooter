using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandomMovement : MonoBehaviour
{
    [SerializeField] private int minX, maxX, minY, maxY;
    [SerializeField] private float speed;

    private Vector3 targetPos;

    private void Start()
    {
        SetTargetPosition();
    }

    private void Update()
    {
        Move();
    }

    void SetTargetPosition()
    {
        targetPos = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0f);
    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPos) < 0.1f)
            SetTargetPosition();
    }
}
