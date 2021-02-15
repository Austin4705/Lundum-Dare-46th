using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleMovement : MonoBehaviour
{



    public float Firemode = 1;
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        if (InputControl.control.current_mode != InputMode.Main) return;
        if(Input.GetKeyDown("r")){
            Firemode = Firemode + 1;
        }
        if(Firemode >= 4){
            Firemode = 1;
        }
    }

}
