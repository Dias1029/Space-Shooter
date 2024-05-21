using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSpaceshipMovement : MonoBehaviour
{
    [SerializeField] private float speed_MIN = 5f, speed_MAX = 10f; 
    
    private float moveSpeed;
    private Vector3 tempPosition;
    private bool moveVertical, moveHorizontal;

    private void Update()
    {
        MoveHorizontal();
        MoveVertical();
    }

    void MoveHorizontal()
    {
        if (!moveHorizontal)
            return;

        tempPosition = transform.position;
        tempPosition.x += moveSpeed * Time.deltaTime;
        transform.position = tempPosition;
    }

    void MoveVertical()
    {
        if (!moveVertical)
            return;

        tempPosition = transform.position;
        tempPosition.y += moveSpeed * Time.deltaTime;
        transform.position = tempPosition;
    }

    public void UpdateMovement(bool moveVer, bool moveHor, bool moveNegative)
    {
        moveHorizontal = moveHor;
        moveVertical = moveVer;

        moveSpeed = Random.Range(speed_MIN, speed_MAX);

        if (moveNegative)
            moveSpeed *= -1f;

        if (moveHorizontal && moveNegative)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }

        if (moveVertical && moveNegative)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, -90f);
        }

        if (moveVertical && !moveNegative)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        }
    }
}
