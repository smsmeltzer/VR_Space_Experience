using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class JoystickVelocity : MonoBehaviour
{
    public InputActionProperty velocityProperty;

    public Vector3 Velocity { get; private set; } = Vector3.zero;
    public JoystickController[] joystickControllers = new JoystickController[2];

    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform xrOrigin;
    [SerializeField] private PlayerData playerData;

    private Quaternion angularVelocity;
    private Quaternion angularAcceleration;

    private Matrix4x4 swap;

    private AudioSource AudioSource;

    void Start()
    {
        //rb = GameObject.Find("XR Origin").GetComponent<Rigidbody>();
        //joystickController = GameObject.Find("Joystick").GetComponent<JoystickController>();
        rb.velocity = Vector3.zero;
        swap = Matrix4x4.zero;
        swap.SetRow(0, new Vector4(0.0f, 0.0f, 1.0f, 0.0f));
        swap.SetRow(2, new Vector4(-1.0f, 0.0f, 0.0f, 0.0f));
        angularVelocity = Quaternion.identity;
        angularAcceleration = Quaternion.identity;

        AudioSource = GetComponent<AudioSource>();  
}
    void Update()
    {
        if (!playerData.isGrabbing)
        {
            foreach (JoystickController joystickController in joystickControllers)
            {

                if (joystickController.positionController)
                {
                    if (playerData.difficulty == PlayerData.Difficulty.Hard)
                    {
                        rb.velocity += (joystickController.currPos - joystickController.startPos).normalized * (5.0f * Time.deltaTime * (joystickController.currPos - joystickController.startPos).magnitude);
                    }
                    else if (playerData.difficulty == PlayerData.Difficulty.Medium)
                    {
                        rb.velocity = (joystickController.currPos - joystickController.startPos).normalized * (5.0f * Time.deltaTime * (joystickController.currPos - joystickController.startPos).magnitude);
                    }

                    if (joystickController.rotationController)
                    {
                        //Quaternion deltaQuat = joystickController.currRot * Quaternion.Inverse(joystickController.startRot);
                        Vector3 delvec = joystickController.currRot.eulerAngles - joystickController.startRot.eulerAngles;
                        rb.angularVelocity = delvec * ((3.14f / 180) * 0.03f);
                    }

                }
                else if (joystickController.rotationController)
                {
                    angularVelocity = Quaternion.Euler(swap * (xrOrigin.worldToLocalMatrix * ((joystickController.currPos - joystickController.startPos).normalized * (1.0f * Time.deltaTime * (joystickController.currPos - joystickController.startPos).magnitude))));
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
        }
        Velocity = velocityProperty.action.ReadValue<Vector3>();
        
        
    }
}
