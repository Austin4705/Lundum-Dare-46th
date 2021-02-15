﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSound : MonoBehaviour
{
	private AudioSource sound;
	//private bool canPlaySound = true;
    public Weapon weapon;
    // Start is called before the first frame update
    void Start()
    {
    	sound = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(weapon.shoot == true)
        {
        	sound.Play();

        }
    }
}
