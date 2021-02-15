using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageControler : MonoBehaviour {
    public float shield = 200f;
    public float health = 100f;
    public float shieldlastframe = 100;
    public float healthlastfame = 100;
    // public Shieldbar shieldbar;
    private float lasthit;
    public static DamageControler Controler;
    public float regenPerSec = 5f;
    public bool playerhit = false;
    public bool shieloffline = false;
    public bool shieldonline = false;
    public bool deathnoise = false;
    public bool playshield = false;
    private void Start () {
        Controler = this;
        lasthit = Time.time;
    }

    public bool TakeDamage (float damage) {
        shield -= damage;
        lasthit = Time.time;
        if (shield <= 0) {
            shield = 0;
            health -= damage / 2;
        }
        return shield <= 0;
    }

    private void Update () {
        playerhit = false;
        shieloffline = false;
        shieldonline = false;
        deathnoise = false;
        playshield = false;
        if (Time.time - lasthit > 2 && shield < 100) {
            shield += regenPerSec * Time.deltaTime;
        }
        if (shieldlastframe > shield || healthlastfame > health) {
            playerhit = true;
        }
        if (shieldlastframe != shield && shield == 0) {
            shieloffline = true;
        }
        if (shieldlastframe != shield && shieldlastframe == 0) {
            shieldonline = true;
        }
        if (health <= 0){
            deathnoise = true;
            //command to switch scenes
        }
        if (shieldlastframe != shield){
            playshield = true;
        }
        shieldlastframe = shield;
        healthlastfame = health;

    }
}