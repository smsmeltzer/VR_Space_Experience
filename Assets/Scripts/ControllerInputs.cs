using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ControllerInputs : MonoBehaviour
{
    public InputActionProperty velocityProperty;
    public InputActionProperty positionProperty;
    public InputActionProperty rotationProperty;
    public InputActionProperty primaryButton; // X or A 
    public InputActionProperty secondaryButton; // Y or B
    public InputActionProperty thumbstickProperty;

    public Vector3 Velocity = Vector3.zero;
    public Vector3 Position = Vector3.zero;
    public Vector3 Rotation = Vector3.zero;
    public Vector2 Thumbstick = Vector2.zero;

    public bool primaryPressed = false;   
    public bool secondaryPressed = false;    

    public XRBaseController controller;

    void Update()
    {
        Velocity = velocityProperty.action.ReadValue<Vector3>();
        Position = positionProperty.action.ReadValue<Vector3>();
        Rotation = rotationProperty.action.ReadValue<Vector3>();
        Thumbstick = thumbstickProperty.action.ReadValue<Vector2>();

        primaryPressed = primaryButton.action.ReadValue<bool>();
        secondaryPressed = secondaryButton.action.ReadValue<bool>();
    }
}
