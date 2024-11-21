using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class JoystickController : XRGrabInteractable
{
    // Start is called before the first frame update
    public Vector3 startPos;
    public Vector3 currPos;
    protected override void Awake()
    {
        base.Awake();
        startPos = transform.position;
        currPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        currPos = transform.position;

    }
}
