using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioSource sound = gameObject.GetComponent<AudioSource>();
        sound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
