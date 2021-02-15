using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindClosestEnemy : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
       // FindEnemy();
    }
    void FindEnemy(){
        		float distanceToClosestEnemy = Mathf.Infinity;
		Enemy closestEnemy = null;
		Enemy[] allEnemies = GameObject.FindObjectsOfType<Enemy>();

		foreach (Enemy currentEnemy in allEnemies) {
			float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
			if (distanceToEnemy < distanceToClosestEnemy) {
				distanceToClosestEnemy = distanceToEnemy;
				closestEnemy = currentEnemy;
			}
        }
            Debug.DrawLine (this.transform.position, closestEnemy.transform.position);
    }
}
