using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shieldbar : MonoBehaviour
{
    void update()
    {
        
 
    }
    public Slider slider;
    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    // Start is called before the first frame update
    public void SetHealth(float health)
    {
        slider.value = health;
    }
}