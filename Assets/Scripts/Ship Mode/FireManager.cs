using System;
using System.Collections;
using System.Collections.Generic;
using Ship_Mode;
using UnityEngine;

public class FireManager : MonoBehaviour
{
    public Location[] locations;

    public GameObject FirePrefab;

    public List<GameObject> fires;

    public GameObject SpawnFire(string location_name)
    {
        Location right_location = null;
        foreach (var location in locations)
        {
            if (location_name == location.name)
            {
                right_location = location;
            }
        }

        var fire = Instantiate(FirePrefab, right_location.spawn_point, Quaternion.identity);
        right_location.burning = true;
        
        fires.Add(fire);
        return fire;
    }
}
