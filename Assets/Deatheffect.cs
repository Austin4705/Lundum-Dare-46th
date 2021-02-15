using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Deatheffect : MonoBehaviour
{
	private AudioSource sound;
	//private bool canPlaySound = true;
    public DamageControler damage;
    public bool gameover = false;
    // Start is called before the first frame update
    void Start()
    {
    	sound = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameover == false){
            gameover = damage.deathnoise;
        }
        if(gameover == true)
        {
        	sound.Play();
         SceneManager.LoadScene("Menu");
        }
    }
}
