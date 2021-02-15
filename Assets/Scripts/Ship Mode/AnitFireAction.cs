using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnitFireAction : MonoBehaviour
{
    public FireManager manager;

    private float time_held = 0f;
    // Update is called once per frame
    void Update()
    {
        foreach (var fire in manager.fires)
        {
            if (fire == null) continue;
            if (Vector2.Distance(transform.position, fire.transform.position) > 3) continue;
            var mouse_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector2.Distance(mouse_position, fire.transform.position) > 1) continue;

            if (Input.GetButton("Fire1"))
            {
                time_held += Time.deltaTime;
            }
            else
            {
                time_held = 0;
            }

            if (time_held >= 1f)
            {
                Destroy(fire);
                time_held = 0f;
                break;
            }
        }
    }
}
