using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class ControllerVelocity : MonoBehaviour
{
    public InputActionProperty velocityProperty;

    public Vector3 Velocity { get; private set; } = Vector3.zero;

    [SerializeField] private ControllerInputs LeftController;
    [SerializeField] private ControllerInputs RightController;
    public Rigidbody rb;

    void Start()
    {
        rb = GameObject.Find("XR Origin").GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
    }
    void Update()
    {
        Velocity = velocityProperty.action.ReadValue<Vector3>();
        // rb.velocity += (Vector3.forward / 100.0f);

        rb.velocity += (new Vector3(LeftController.Thumbstick[0], LeftController.Thumbstick[1], 0.0f)).normalized * 1.0f;

    }
}
