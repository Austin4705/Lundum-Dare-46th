using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public interface HomingWatcher
{
    void onDestroy();
}

public class EnemyIntroScript : MonoBehaviour
{
    public float endYCoord;

    public float seconds = 1f;

    public EnemySpawner spawner = null;

    private float _currenttime = 0;

    private float delta_y;

    public HomingWatcher watcher;

    public float health = 60f;
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        moveShip();
    }

    void moveShip()
    {
        endYCoord = Random.Range(2, 12);
        var current_y = transform.position.y;
        delta_y = endYCoord - current_y;
    }

    void Update()
    {
        _currenttime += Time.deltaTime;


        if (health <= 0)
        {
            spawner.enemies.Remove(gameObject);
            if (watcher != null)
            {
                watcher.onDestroy();
                watcher = null;
            }

            Destroy(gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
            //spawn explosion
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy Bullet") return;
        if (other.gameObject.tag == "Bullet")
        {
            health -= other.gameObject.GetComponent<Damage>().damage;
            if (watcher != null)
            {
                watcher.onDestroy();
                watcher = null;
            }
        }
    }
}