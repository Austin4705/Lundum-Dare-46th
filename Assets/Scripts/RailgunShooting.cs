using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailgunShooting : MonoBehaviour
{

    // Start is called before the first frame update
    public Transform firePointturret;
    public GameObject bulletPrefab;
    //public EnemySpawner spawner;
    public float FireRate = 10;

    public float lastfired;

    // Update is called once per frame
    void Update()
    {
        if (InputControl.control.current_mode != InputMode.Main) return;
        if (Input.GetKeyDown("x"))
        {
            if (Time.time - lastfired > 1 / FireRate)
            {
                lastfired = Time.time;
                Shoot();
            }
        }
    }

    void Shoot()
    {
        var obj = Instantiate(bulletPrefab, firePointturret.position, firePointturret.rotation);
        //obj.GetComponent<homingmissle>().spawner = spawner;
    }
}
 