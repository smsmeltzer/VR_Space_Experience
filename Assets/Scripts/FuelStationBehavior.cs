using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit;

public class FuelStationBehavior : MonoBehaviour
{
    public float respawnTime = 20;

    private bool CanRespawn = true;
    private AudioSource AudioSource;

    private Queue<GameObject> RespawnQueue = new Queue<GameObject>();

    private void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (CanRespawn && RespawnQueue.Count > 0)
        {
            StartCoroutine(RespawnFuel(RespawnQueue.Dequeue()));
        }
    }
    public void Respawn(GameObject obj)
    {
        RespawnQueue.Enqueue(obj);
        AudioSource.Play();
    }

    private IEnumerator RespawnFuel(GameObject obj)
    {
        CanRespawn = false;
        yield return new WaitForSeconds(respawnTime);
        obj.GetComponent<XRGrabInteractable>().enabled = true;
        obj.SetActive(true);
        CanRespawn = true;
    }
}
