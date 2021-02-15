using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform firePointleft;
    public Transform firePointright;
    public GameObject bulletPrefab;
    public float FireRate = 10;
    public bool shoot;
    public float lastfired;

    // Update is called once per frame
    void Update()
    {
                if (InputControl.control.current_mode != InputMode.Main) return;
        if (Input.GetButton("Fire1"))
        {
            shoot = false;
            if (Time.time - lastfired > 1 / FireRate)
            {
                lastfired = Time.time;
                Shoot();
                shoot = true;

            }
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePointleft.position, firePointleft.rotation);
        Instantiate(bulletPrefab, firePointright.position, firePointright.rotation);

    }
}