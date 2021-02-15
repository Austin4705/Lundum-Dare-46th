using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
    public Image health_bar;

    public Image sheild_bar;

    public Image railgun_bar;

    public Text fireMode;

    public Text ammo;

    public ShootingTurret railgun;

    public CycleMovement cycle;
    public float railgunchargedisplay;
    public MissleShoot shoot;
    public string mode = "Mirror Mouse";
    // Update is called once per frame
    void Update () {
        if(railgun.timetoshoot < 1){
        railgunchargedisplay = railgun.timetoshoot;
        }
        if(railgun.timetoshoot >= 1){
            railgunchargedisplay = 1;
            //put sound effect railgun ready here

        }
        health_bar.fillAmount = DamageControler.Controler.health / 100f;
        sheild_bar.fillAmount = DamageControler.Controler.shield / 200f;
        railgun_bar.fillAmount = railgunchargedisplay;


        if (cycle.Firemode == 1) {
            mode = "Mirror Mouse";
  
        }
        if (cycle.Firemode == 2) {
            mode = "Forward";

        }
        if (cycle.Firemode == 3) {
            mode = "Auto Aim";

        }

    fireMode.text = $"Mode: {mode}";
    ammo.text = $"Missiles: {shoot.ammocount}";
}
}