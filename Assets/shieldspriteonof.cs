using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldspriteonof : MonoBehaviour {
        public DamageControler damage;
        public float displaytime;
        public float lastfired;
        public bool isshown;
        // Start is called before the first frame update
        void Start () {

        }

        // Update is called once per frame
        void Update () {
            if (damage.playshield == true) {
                //show
gameObject.GetComponent<Renderer>().enabled = true;

                isshown = true;
            }
            if (Time.time - lastfired > 1 / displaytime) {
                lastfired = Time.time;
                //hide
gameObject.GetComponent<Renderer>().enabled = false;

                isshown = false;
            }
        }
}