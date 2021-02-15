using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldonline : MonoBehaviour
{
	private AudioSource sound;
	//private bool canPlaySound = true;
    public DamageControler damage;
    // Start is called before the first frame update
    void Start()
    {
    	sound = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(damage.shieldonline == true)
        {
        	sound.Play();

        }
    }
}
