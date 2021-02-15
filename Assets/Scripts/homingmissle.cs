using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class homingmissle : MonoBehaviour, HomingWatcher
{
    public Transform target;
    public EnemySpawner spawner;
    public Rigidbody2D rb;
    public float speed = 1f;
    public int retargets = 1;

    private void Start()
    {
        spawner = EnemySpawner.spawner;
        SelectTarget();
    }

    public void SelectTarget()
    {
        if (spawner == null)
        {
            Destroy(gameObject);
        }
        var obj = spawner.nearest(transform.position);
        if (obj == null || obj.transform == null)
        {
            Destroy(gameObject);
            return;
        }
        target = obj.transform;
        obj.GetComponent<EnemyIntroScript>().watcher = this;
    }

    public void FixedUpdate()
    {
        if (target != null)
        {
            var angle = (target.transform.position - transform.position).normalized;
            rb.velocity = angle * speed;
        }
    }

    // public void Update()
    // {
    //     if (target == null)
    //     {
    //         SelectTarget();
    //     }
    // }

    public void onDestroy()
    {
        if (gameObject == null)
        {
            return;
        }
        if (retargets <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            retargets -= 1;
            SelectTarget();
        }
    }
}
