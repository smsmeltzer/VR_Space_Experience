using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class ResetButton : XRSimpleInteractable
{
    public float HoldTime = 5.0f;
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

            if (timer > HoldTime)
            {
                transform.position -= new Vector3(0, -.01f, 0);
                ResetPlayer();
            }
        }
    }
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        isGrabbed = true;
        transform.position += new Vector3(0, -.01f, 0);
        GetComponent<AudioSource>().Play();
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        isGrabbed = false;
        transform.position -= new Vector3(0, -.01f, 0);

    }

    public void ResetPlayer()
    {
        PlayerData.ResetPlayerLocation();
        PlayerData.ResetPlayerMovement();
        PlayerData.ResetPlayerData();
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}
