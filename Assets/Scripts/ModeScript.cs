using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeScript : MonoBehaviour
{
    public Camera main_camera;

    public Camera ship_camera;

    public Camera minimap;
    
    // Start is called before the first frame update
    void Start()
    {
        main_camera.enabled = true;
        ship_camera.enabled = false;
        ResetMinimap();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            UpdateCamera();
            InputControl.control.current_mode =
                InputControl.control.current_mode == InputMode.Main ? InputMode.Ship : InputMode.Main;
        }
    }

    private void UpdateCamera()
    {
        main_camera.enabled = !main_camera.enabled;
        ship_camera.enabled = !ship_camera.enabled;
        ResetMinimap();
    }

    private void ResetMinimap()
    {
        minimap.enabled = false;
        minimap.enabled = true;
    }
}
