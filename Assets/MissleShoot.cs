using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleShoot : MonoBehaviour
{
    // Start is called before the first frame update


    public Transform misslepointleft;

    //public Transform misslepointleft1;
    public Transform misslepointright;

    //public Transform misslepointright1;
    public GameObject bulletPrefab;

    public AudioSource source;
    public float RechargeRate = 5;
    public float ammocount;
    public float lastfired;
    public bool shoot;
    void start()
    {
        ammocount = 4;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
                            if (InputControl.control.current_mode != InputMode.Main) return;
            if (ammocount > 0)
            {
                Shoot();
                ammocount = ammocount - 1;
            }
        }
        shoot = false;
        if (Time.time - lastfired > 1 / RechargeRate)
        {
            //lastfired = Time.time;             
            if (ammocount < 2)
            {
                ammocount = ammocount + 1;
                lastfired = Time.time;
            }

            if (ammocount >= 2)
            {
                lastfired = Time.time;
            }
        }
    }

    void Shoot()
    {
        if (ammocount == 1)
        {
            Instantiate(bulletPrefab, misslepointleft.position, misslepointleft.rotation);
            source.Play();
        }

        if (ammocount == 2)
        {
            Instantiate(bulletPrefab, misslepointright.position, misslepointright.rotation);
            source.Play();
        }
        shoot = true;
    }
}