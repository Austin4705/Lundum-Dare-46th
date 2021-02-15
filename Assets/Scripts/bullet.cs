using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class bullet : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;

    public float timer = 5f;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * speed;
    }
    void Update()
    {
    	if(transform.position.y < -10)
    	{
    		Destroy(gameObject);
    	}

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
	        Destroy(gameObject);
        }
    }


    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
	    if (other.gameObject.tag == "Ship") return;
	    Destroy(gameObject);
    }
}
