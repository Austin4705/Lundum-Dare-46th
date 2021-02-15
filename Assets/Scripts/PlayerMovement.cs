using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float moveSpeed = 1f;

    public float deltaX = 19f;

    public float deltaY = 8f;

    private void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (InputControl.control.current_mode != InputMode.Main)
        {
            rb.velocity = Vector2.zero;
            return;
        }

        float moveLR = Input.GetAxis("Horizontal");
        float moveFB = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveLR, moveFB);
        //print(movement);
        rb.velocity = movement * moveSpeed;

        if (Math.Abs(transform.position.x) >= deltaX)
        {
            transform.position = new Vector3(transform.position.x < 0 ? -deltaX + 0.1f : deltaX - 0.1f,
                transform.position.y, transform.position.z);
        }

        if (Math.Abs(transform.position.y) >= deltaY)
        {
            transform.position = new Vector3(transform.position.x,transform.position.y < 0 ? -deltaY + 0.1f : deltaY - 0.1f,
                 transform.position.z);
        }
    }
}

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlayerMovement : MonoBehaviour
// {
//     public float speed = 10f;
//     public Rigidbody2D rb;
//
//     Vector2 movement;
//
//     void Awake()
//     {
//         rb = GetComponent<Rigidbody2D>();
//     }
//
//     void Update()
//     {
//         //Vector2 forcex = movex;
//         // movex = (new Vector2(Input.GetAxis("Horizontal")*speed,0);
//         print(Input.GetAxis("Horizontal"));
//         print(Input.GetAxis("Vertical"));
//
//         print(new Vector2(Input.GetAxis("Horizontal") * speed, 0));
//         print(new Vector2(0, Input.GetAxis("Vertical") * speed));
//
//         rb.AddForce(new Vector2(Input.GetAxis("Horizontal") * speed, 0));
//         rb.AddForce(new Vector2(0, Input.GetAxis("Vertical") * speed));
//     }
// }