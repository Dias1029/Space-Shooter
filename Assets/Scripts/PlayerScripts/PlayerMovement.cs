using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private float playerSpeed = 30f;

    private Rigidbody2D rb;
    private Item item;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        rb.velocity = new Vector3(joystick.Horizontal * playerSpeed, joystick.Vertical * playerSpeed, 0);
            /*if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                rb.AddForce(transform.up * playerSpeed);
            }

            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                rb.AddForce(-transform.up * playerSpeed);
            }

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                rb.AddForce(transform.right * playerSpeed);
            }

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                rb.AddForce(-transform.right * playerSpeed);
            }*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagManager.ITEMS_TAG))
        {
            item = collision.GetComponent<Item>();
            float minSpeed = 5f;

            if (item.type == ItemType.SpeedDebuff)
            {
                playerSpeed -= 10;

                if (playerSpeed <= minSpeed)
                    playerSpeed = minSpeed;

                Destroy(item.gameObject);
            }
        }
    }
}
