using System;
using System.Collections;
using System.Collections.Generic;
using Ship_Mode;
using UnityEngine;

public class Health : MonoBehaviour, FireWatcher
{
    public ShootingTurret Turret;

    public FireManager Manager;

    public string location_name;

    public float damage = 10f;
    
    public bool active = true;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Enemy Bullet"))
        {
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        var should_break = DamageControler.Controler.TakeDamage(active ? damage : 2*damage);
        if (should_break && active)
        {
            active = false;
            Turret.active = active;
            Fire();
        }
    }

    private void Fire()
    {
        var fire = Manager.SpawnFire(location_name);
        fire.GetComponent<FireScript>().watcher = this;
        DamageControler.Controler.shield += 50f;
    }

    private void Update()
    {
        // Turret.gameObject.SetActive(active);
    }

    public void onDestruction()
    {
        active = true;
        Turret.active = active;
    }
}
