using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class JoystickController : XRGrabInteractable
{
    // Start is called before the first frame update
    public Vector3 startPos;
    public Vector3 currPos;
    public Quaternion startRot;
    public Quaternion currRot;
    public bool grabbed;
    [SerializeField] private Transform reference;

    public bool positionController;
    public bool rotationController;
    protected override void Awake()
    {
        base.Awake();
        //reference = GameObject.Find("Left Joystick").GetComponent<Transform>();
        startPos = reference.position;
        currPos = reference.position;
        grabbed = false;
        startRot = reference.rotation;
        currRot = reference.rotation;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //currPos = transform.localPosition;
        if (grabbed)
        {
            Move();
        } else
        {
            startPos = reference.position;
            transform.position = startPos;
            currPos = startPos;

            startRot = reference.rotation;
            transform.rotation = startRot; 
            currRot = startRot;
        }

    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        grabbed = true;
    }

   

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        grabbed = false;
        //transform.localPosition = startPos;
        base.OnSelectExited(args);
    }

    private void Move()
    {
        currPos = transform.position;
        startPos = reference.position;

        currRot = transform.rotation;
        startRot = reference.rotation;
    }
}
