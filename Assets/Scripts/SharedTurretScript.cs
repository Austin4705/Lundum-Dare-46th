using System;
using UnityEngine;
using UnityEngine.Animations;

public class SharedTurretScript : MonoBehaviour
{
    [SerializeField]
    public TurretMovement[] turrets;

    [SerializeField]
    public CycleMovement Movement;

    public void Aim()
    {
        var distance = float.MaxValue;
        Vector2? obj = null;
        foreach(var turret in turrets)
        {
            var turret_distance = turret.mirrormouse();
            if (turret_distance.magnitude < distance)
            {
                distance = turret_distance.magnitude;
                obj = turret_distance;
            }
        }

        if (obj == null) return;
        
        foreach (var turret in turrets)
        {
            turret.PointInVector(obj.Value);
        }
    }

    void Update()
    {
        if (InputControl.control.current_mode != InputMode.Main) return;
        if (Movement.Firemode == 1)
        {
            Aim();
        }
    }
}