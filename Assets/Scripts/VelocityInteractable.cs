using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class VelocityInteractable : XRGrabInteractable
{
    [SerializeField] private ControllerInputs ControllerInputs;
    private CharacterController controller;
    private Rigidbody rb;
    private bool climbActive = false;

    protected override void Awake()
    {
        base.Awake();
        controller = GameObject.Find("XR Origin").GetComponent<CharacterController>();
        rb = GameObject.Find("XR Origin").GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if (climbActive) {
            Climb();
        }
    }   
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        ControllerInputs = args.interactorObject.transform.GetComponent<ControllerInputs>();
        rb.velocity = Vector3.zero;
        climbActive = true;
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        climbActive = false;
        ApplyForceOnRelease();
        base.OnSelectExited(args);
        ControllerInputs = null;
    }

    private void Climb()
    {
        Vector3 v = ControllerInputs ? ControllerInputs.Velocity : Vector3.zero;
        controller.Move(controller.transform.rotation * -v * Time.fixedDeltaTime);
    }

    private void ApplyForceOnRelease()
    {
        Vector3 v = ControllerInputs ? ControllerInputs.Velocity : Vector3.zero;
        rb.velocity = -v;
    }
}

