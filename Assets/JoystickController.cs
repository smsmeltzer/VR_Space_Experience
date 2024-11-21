using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class JoystickController : XRGrabInteractable
{
    // Start is called before the first frame update
    public Vector3 startPos;
    public Vector3 currPos;
    public bool grabbed;
    protected override void Awake()
    {
        base.Awake();
        startPos = transform.localPosition;
        //currPos = transform.localPosition;
        grabbed = false;
    }

    // Update is called once per frame
    void Update()
    {
        //currPos = transform.localPosition;
        if (grabbed)
        {
            Move();
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
        transform.localPosition = startPos;
        base.OnSelectExited(args);
    }

    private void Move()
    {
        
    }
}
