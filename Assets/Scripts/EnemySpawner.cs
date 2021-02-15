using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
	public GameObject enemy;
	float randX;
    public GameObject player;
	Vector2 whereToSpawm;
	public float spawnRate = 2f;
	float nextSpawn = 0.0f;

	private Vector3 _base_location;

	public static EnemySpawner spawner;
    // Start is called before the first frame update
    private void Start()
    {
	    _base_location = player.transform.position;
	    spawner = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextSpawn && enemies.Count < 25)
        {
        	nextSpawn = Time.time + spawnRate;
        	randX = Random.Range (_base_location.x - 17.5f, _base_location.x + 17.5f);
        	whereToSpawm = new Vector2(randX, transform.position.y);
        	var new_thing = Instantiate (enemy, whereToSpawm, transform.rotation);
            new_thing.GetComponent<EnemyIntroScript>().spawner = this;
            enemies.Add(new_thing);
        }

        //spawnRate = 100.0f / (ScoreScript.scoreValue + 20);
    }
    
    public List<GameObject> enemies = new List<GameObject>();

    public GameObject nearest(Vector2 point)
    {
	     GameObject obj = null;
	     float distance = float.PositiveInfinity;
	     foreach (var enemy in enemies)
	     {
		     if (enemy.GetComponent<EnemyIntroScript>().watcher != null)
		     {
			     continue;
		     }
		     var cur_distance = Vector3.Distance(enemy.transform.position, point);
		     if (cur_distance < distance)
		     {
			     obj = enemy;
			     distance = cur_distance;
		     }
	     }

	     return obj;
    }
}
