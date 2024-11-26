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
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform xrOrigin;
    [SerializeField] private PlayerData playerData;

    private Quaternion angularVelocity;
    private Quaternion angularAcceleration;
    private Matrix4x4 swap;

    void Start()
    {
        rb.velocity = Vector3.zero;
        angularVelocity = Quaternion.identity;
        angularAcceleration = Quaternion.identity;

        swap = Matrix4x4.zero;
        swap.SetRow(1, new Vector4(0.0f, 1.0f, 0.0f, 0.0f));
    }
    void Update()
    {
        Velocity = velocityProperty.action.ReadValue<Vector3>();
        // rb.velocity += (Vector3.forward / 100.0f);


        angularVelocity = Quaternion.Euler(swap * ( (RightController.Thumbstick.normalized * (1.0f * Time.deltaTime * RightController.Thumbstick.magnitude))));
        angularAcceleration *= angularVelocity;
        rb.rotation *= angularAcceleration;

        if (playerData.difficulty == PlayerData.Difficulty.Hard)
        {
            rb.rotation *= angularAcceleration;
        }
        else if (playerData.difficulty == PlayerData.Difficulty.Medium)
        {
            rb.rotation *= angularVelocity;
        }

        

    }
}
