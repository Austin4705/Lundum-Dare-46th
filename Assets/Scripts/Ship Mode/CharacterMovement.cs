using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float sprintmutliplier;
    public float speed;
    float sprintspeed;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(Input.GetButton("Sprint") && (Input.GetKey("w") || Input.GetKey("s") || Input.GetKey("d") || Input.GetKey("a")))
        {
        	anim.SetFloat("Speed", 2.0f);
        }

        if(!Input.GetButton("Sprint") && (Input.GetKey("w") || Input.GetKey("s") || Input.GetKey("d") || Input.GetKey("a")))
        {
        	anim.SetFloat("Speed", 1.0f);
        }

        if(!Input.GetButton("Sprint") && !(Input.GetKey("w") || Input.GetKey("s") || Input.GetKey("d") || Input.GetKey("a")))
        {
        	anim.SetFloat("Speed", 0.0f);
        }


        if (InputControl.control.current_mode != InputMode.Ship) return;
        var x = 0f;
        var y = 0f;
        if (Input.GetButton("Sprint"))
        {
            sprintspeed = speed * sprintmutliplier;
        }
        if (!Input.GetButton("Sprint"))
        {
            sprintspeed = speed;
        }
     //   print(sprintspeed);
        if (Input.GetKey("w"))
        {
            y += sprintspeed;
        }

        if (Input.GetKey("s"))
        {
            y -= sprintspeed;
        }

        if (Input.GetKey("d"))
        {
            x += sprintspeed;
        }

        if (Input.GetKey("a"))
        {
            x -= sprintspeed;
        }
        
        rb.velocity = new Vector2(x, y);
        transform.up = new Vector3(x, y);
    }
}
