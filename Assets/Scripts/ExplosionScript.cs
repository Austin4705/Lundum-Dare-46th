using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    public int frame_count = 0;
    public bool sound;
    private void Update()
    {
        sound = true;
        frame_count += 1;
        if (frame_count >= 46)
        {
            Destroy(gameObject);
            sound = false;
        }
    }
}
