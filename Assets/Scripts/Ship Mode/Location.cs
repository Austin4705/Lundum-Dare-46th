
using System;
using UnityEngine;

namespace Ship_Mode
{
    public class Location: MonoBehaviour
    {
        public string name = "";
        public Vector2 spawn_point;

        private void Start()
        {
            spawn_point = transform.position;
        }

        public bool burning = false;
    }
}