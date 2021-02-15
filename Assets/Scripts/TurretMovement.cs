using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretMovement : MonoBehaviour
{
    //float CycleMovement.Firemode firemode;
    //float CycleMovement Firemode;
    public CycleMovement x;

    //public Vector2 ForewardDirrection = new Vector2(0, 90);
    // Update is called once per frame
    void Update()
    {
        if (InputControl.control.current_mode != InputMode.Main) return;
        //facemouse();
        if (x.Firemode == 0)
        {
            facemouse();
            //print("facemouse");
        }

        if (x.Firemode == 1)
        {
            mirrormouse();
            //print("mirrormouse");
        }

        if (x.Firemode == 2)
        {
            faceforeward();
            //print("faceforeward");
        }

        if (x.Firemode == 3)
        {
            autoshoot();
            //print("autoshoot");
        }

        //print(x.Firemode);
        //print(CycleMovement.Firemode);
    }

    void facemouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y
        );

        transform.up = direction;
        //print(direction);
    }

    public Vector2 mirrormouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = new Vector2(
            mousePosition.x,
            mousePosition.y);
        Vector2 delta = direction - new Vector2(transform.position.x, transform.position.y);
        return delta;
    }

    public void PointInVector(Vector2 direction)
    {
        transform.up = direction.normalized;
    }

    void faceforeward()
    {
        transform.up = new Vector2(0, 1);
    }

    void autoshoot()
    {
        float distanceToClosestEnemy = Mathf.Infinity;
        Enemy closestEnemy = null;
        Enemy[] allEnemies = GameObject.FindObjectsOfType<Enemy>();

        foreach (Enemy currentEnemy in allEnemies)
        {
            float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToEnemy < distanceToClosestEnemy)
            {
                distanceToClosestEnemy = distanceToEnemy;
                closestEnemy = currentEnemy;
            }
        }

        transform.up = new Vector2(
            closestEnemy.transform.position.x - transform.position.x,
            closestEnemy.transform.position.y - transform.position.y
        );
        Debug.DrawLine(this.transform.position, closestEnemy.transform.position);
    }
}