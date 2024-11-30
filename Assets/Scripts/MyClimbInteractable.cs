using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MyClimbInteractable : ClimbInteractable
{
    private ControllerInputs ControllerInputs;
    private Rigidbody rb;
    private PlayerData PlayerData;

    protected override void Awake()
    {
        base.Awake();
        rb = GameObject.Find("XR Origin").GetComponent<Rigidbody>();
        PlayerData = GameObject.Find("XR Origin").GetComponent<PlayerData>();
    }
    
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        ControllerInputs = args.interactorObject.transform.GetComponent<ControllerInputs>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.rotation = Quaternion.identity;
        PlayerData.isGrabbing = true;
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        Vector3 v = ControllerInputs ? ControllerInputs.Velocity : Vector3.zero;
        rb.velocity = -v;
        PlayerData.isGrabbing = false;
        base.OnSelectExited(args);
    }
}
