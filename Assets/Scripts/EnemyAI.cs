using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float deltaX = 21f;

    public float direction = 1f;

    public Rigidbody2D rb;

    public float flySpeed = 5f;

    public float shoot_interval = 1f;

    public GameObject bullet;

    private float timer = 0;
    private float timeout = 3f;

    private void Start()
    {
        rb.velocity = new Vector2(flySpeed*direction, 0);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        timeout += Time.deltaTime;
        if (Math.Abs(transform.position.x) >= deltaX)
        {
            transform.position = new Vector3(transform.position.x < 0 ? -deltaX+0.1f: deltaX-0.1f, transform.position.y, transform.position.z);
            direction *= -1f;
            rb.velocity = new Vector2(flySpeed*direction, 0);
            timeout = 0f;
        }

        if (timer >= shoot_interval)
        {
            Shoot();
            timer = 0f;
        }
    }

    void Shoot()
    {
        Instantiate(bullet, transform.position, transform.rotation);
    }
}
