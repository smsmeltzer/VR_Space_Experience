using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayTutorialButton : XRGrabInteractable
{
    [SerializeField] private VideoPlayer VideoPlayer;
    private bool isGrabbed = false;

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        transform.position += new Vector3(0, -.01f, 0);
        isGrabbed = true;
        GetComponent<AudioSource>().Play();
        if (VideoPlayer != null)
        {
            VideoPlayer.Play();
        }
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        transform.position = Vector3.zero;
        base.OnSelectExited(args);
        isGrabbed = false;
    }
}
