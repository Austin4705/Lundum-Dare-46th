using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailgunMovement : MonoBehaviour {
    public float speed = 5f;
   // public float railgunrotation = (transform.rotation.eulerAngles.z);
    public float maxrotateleft;
    public float maxrotateright;
  //  public float rotation = transform.rotation.eulerAngles.z;
    // Update is called once per frame
    void Update ()
    {
        if (InputControl.control.current_mode != InputMode.Main) return;
        if (Input.GetKey("z")) {
            //print("z");
            RotateLeft();
        }

        if (Input.GetKey("c")) {
            //print("c");
            RotateRight();
        }
        if(transform.rotation.eulerAngles.z > maxrotateleft && transform.rotation.eulerAngles.z < maxrotateright)
       {
           if(transform.rotation.eulerAngles.z < 180){
               transform.Rotate (Vector3.back);
           }
           if(transform.rotation.eulerAngles.z > 180){
               transform.Rotate (Vector3.forward);
           }
       }
       
       
       // print(transform.rotation.eulerAngles.z);
        


    }

     
    void RotateLeft(){
        if(transform.rotation.eulerAngles.z > maxrotateleft && transform.rotation.eulerAngles.z < maxrotateright){    
        }
        else{
             transform.Rotate (Vector3.forward);
        }
   
    }
    void RotateRight(){
        if(transform.rotation.eulerAngles.z > maxrotateleft && transform.rotation.eulerAngles.z < maxrotateright){
        }
            else{
            transform.Rotate (Vector3.back); 
            }
    }
}