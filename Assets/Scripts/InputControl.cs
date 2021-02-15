using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public enum InputMode
{
    Main = 0,
    Ship = 1
}
public class InputControl : MonoBehaviour
{
    public InputMode current_mode;

    public static InputControl control;

    private void Start()
    {
        control = this;
    }
}

