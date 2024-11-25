using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ControllerInputs : MonoBehaviour
{
    public InputActionProperty velocityProperty;
    public InputActionProperty positionProperty;
    public InputActionProperty rotationProperty;
    public InputActionProperty primaryButton; // X or A 
    public InputActionProperty secondaryButton; // Y or B
    public InputActionProperty thumbstickProperty;

    public Vector3 Velocity;
    public Vector3 Position;
    public Quaternion Rotation;
    public Vector2 Thumbstick;

    public bool primaryPressed;   
    public bool secondaryPressed;    

    public XRBaseController controller;

    
    /*
    void Awake()
    {
        // Ensure XRController is assigned
        if (controller == null)
            controller = GetComponent<XRBaseController>();

        
    }*/

    void Update()
    {
        Velocity = velocityProperty.action.ReadValue<Vector3>();
        Position = positionProperty.action.ReadValue<Vector3>();
        Rotation = rotationProperty.action.ReadValue<Quaternion>();

        Thumbstick = thumbstickProperty.action.ReadValue<Vector2>();

        primaryPressed = primaryButton.action.IsPressed();
        secondaryPressed = secondaryButton.action.IsPressed();
    }

    override public string ToString()
    {
        return "V: " + Velocity.ToString() + 
            "\nPos: " + Position.ToString() + 
            "\nRot: " + Rotation.ToString() + 
            "\nThumb: " + Thumbstick.ToString() + 
            "\nPrimary: " + primaryPressed.ToString() + 
            "\nSecondary: " + secondaryPressed.ToString();
    }
}
