using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayTutorialButton : XRSimpleInteractable
{
    [SerializeField] private VideoPlayer VideoPlayer;
    public bool onCollisionStart = false;

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        transform.position += new Vector3(0, -.01f, 0);
        GetComponent<AudioSource>().Play();
        if (VideoPlayer != null)
        {
            VideoPlayer.Play();
        }
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        transform.position -= new Vector3(0, -.01f, 0);
        base.OnSelectExited(args);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (onCollisionStart && (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Hands"))
        {
            VideoPlayer.Play();
        }
    }
}
