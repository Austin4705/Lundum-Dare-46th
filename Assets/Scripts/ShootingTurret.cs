using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingTurret : MonoBehaviour {

    // Start is called before the first frame update
    public Transform firePointturret;
    public GameObject bulletPrefab;
    public EnemySpawner spawner;
    public float FireRate = 10;

    public float lastfired;
    public float railgunchargetime;
    public float railguncurretncharge;
    public bool active = true;
    public bool railgun = false;
    public float timetoshoot;
    public float canShoot => Time.time - lastfired / (1 / FireRate);
    public bool shoot;

    // Update is called once per frame
    void Update () {
        timetoshoot = (Time.time - lastfired) * FireRate;
        if (InputControl.control.current_mode != InputMode.Main || !active) return;
        if (!railgun){
            shoot = false;
        }
        if (Input.GetButton ("Fire2") && !railgun) {
            if (Time.time - lastfired > 1 / FireRate) {
                lastfired = Time.time;
                Shoot ();
                shoot = true;

            }

        }

        if (railgun) {
            if ((Time.time - lastfired) > 1 / FireRate) {

                if (Input.GetKey ("e")) {
                    railguncurretncharge += Time.deltaTime;
                } else {
                    railguncurretncharge = 0;
                }
                if (railguncurretncharge > 0) {
                    //play anamation and sound here
                }

                if (railguncurretncharge > railgunchargetime) {
                    //Destroy (fire);
                    Shoot ();
                    print ("railgun activated");
                    railguncurretncharge = 0f;
                    lastfired = Time.time;
                }
            }
        }

    }

    void Shoot () {
        var obj = Instantiate (bulletPrefab, firePointturret.position, firePointturret.rotation);
        // obj.GetComponent<homingmissle>().spawner = spawner;
        // obj.GetComponent<homingmissle>().SelectTarget();
    }
}