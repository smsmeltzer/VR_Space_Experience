using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ResetButton : XRGrabInteractable
{
    private bool isGrabbed = false;
    private float timer = 0.0f;

    private void Start()
    {
    }
    private void Update()
    {
        if (isGrabbed)
        {
            timer += Time.deltaTime;

            if (timer > 3.0f)
            {
                transform.position = Vector3.zero;

                ResetPlayer();
            }
        }
    }
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        isGrabbed = true;
        transform.position += new Vector3(0, -.01f, 0);
        
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        isGrabbed = false;
        transform.position = Vector3.zero;
    }

    public void ResetPlayer()
    {
    }
}
