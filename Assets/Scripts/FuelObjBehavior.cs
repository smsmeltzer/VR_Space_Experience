using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FuelObjBehavior : XRSimpleInteractable
{
    [SerializeField] private FuelStationBehavior FuelStationBehavior;
    [SerializeField] private GameObject SpawnLocation;
    private PlayerData playerData;

    // Start is called before the first frame update
    void Start()
    {
        playerData = GameObject.Find("XR Origin").GetComponent<PlayerData>();
    }
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        playerData.Refuel();
        FuelStationBehavior.Respawn(this.gameObject);
        this.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        playerData.Refuel();
        FuelStationBehavior.Respawn(this.gameObject);
        this.gameObject.SetActive(false);
    }

}
