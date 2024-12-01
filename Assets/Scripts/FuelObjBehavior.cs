using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FuelObjBehavior : XRGrabInteractable
{
    [SerializeField] private FuelStationBehavior FuelStationBehavior;
    [SerializeField] private GameObject SpawnLocation;
    private PlayerData playerData;

    private Rigidbody rb;
    private XRGrabInteractable interactable;
    private AudioSource audioSource;
    private Vector3 pos;
    private bool isGrabbed = false;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        rb = GetComponent<Rigidbody>();
        interactable = GetComponent<XRGrabInteractable>();
        audioSource = GetComponent<AudioSource>();
        playerData = GameObject.Find("XR Origin").GetComponent<PlayerData>();
    }

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        isGrabbed = true;
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        isGrabbed = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.tag == "Player" && isGrabbed)
        {
            playerData.Refuel();
            transform.position = pos;
            transform.rotation = Quaternion.identity;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            interactable.enabled = false;
            this.gameObject.SetActive(false);
            FuelStationBehavior.Respawn(this.gameObject);
        }
    }
}
