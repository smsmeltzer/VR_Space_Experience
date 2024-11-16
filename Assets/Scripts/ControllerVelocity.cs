using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class ControllerVelocity : MonoBehaviour
{
    public InputActionProperty velocityProperty;

    public Vector3 Velocity { get; private set; } = Vector3.zero;

    void Start()
    {
        
    }
    void Update()
    {
        Velocity = velocityProperty.action.ReadValue<Vector3>();
    }
}
