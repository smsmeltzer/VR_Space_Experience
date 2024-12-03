using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField] private FuelGaugeBehavior fuelGauge;
    public int fuel = 100;
    public bool isGrabbing = false;
    public TextMeshProUGUI collectibleGauge;
    [SerializeField] private GameObject collectiblesParent;
    [HideInInspector] public int collectibles = 0;
    private int totalCollectibles;

    public enum Difficulty
    {
        Medium,
        Hard
    }
    public Difficulty difficulty;

    private void OnEnable()
    {
        fuel = PlayerPrefs.GetInt("fuel");
        collectibles= PlayerPrefs.GetInt("collectibles");
        Enum.TryParse(PlayerPrefs.GetString("difficulty"), out difficulty);
        totalCollectibles = collectiblesParent?.transform.childCount ?? 1; //sets totalCollectibles to 1 if childCount is collectiblesParent is unassigned
    }
    private void Update()
    {
        fuelGauge.UpdateDisplay(fuel);

    }
    public void Refuel()
    {
        fuel = 100;
        fuelGauge.UpdateDisplay(fuel);
    }

    public bool useFuel(int amount)
    {
        if (fuel != 0)
        {
            fuel -= amount;
        }
        if (fuel < 0)
        {
            fuel = 0;
            return false;
        }
        fuelGauge.UpdateDisplay(fuel);
        return true;
    }

    public bool HasFuel()
    {
        return fuel > 0;
    }

    // Triggered in XRGrabInteractable component of collectible prefabs
    public void collectItem()
    {
        collectibles++;
        collectibleGauge.text = collectibles.ToString();
        if (collectibles >= totalCollectibles && collectibles > 1)
        {
            collectibleGauge.text = "Complete!";
            // Play win audio message here
        }
    }

    public void resetCollection()
    {
        collectibles = 0;
        collectibleGauge.text = collectibles.ToString();
    }

    static public void ResetPlayerMovement()
    {
        Rigidbody rb  = GameObject.Find("XR Origin").GetComponent<Rigidbody>();
        GameObject.Find("XR Origin").GetComponentInChildren<JoystickVelocity>().ResetJoystickMovement();

        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.rotation = Quaternion.identity;

    }

    static public void StopPlayerMovement()
    {
        Rigidbody rb = GameObject.Find("XR Origin").GetComponent<Rigidbody>();
        GameObject.Find("XR Origin").GetComponentInChildren<JoystickVelocity>().ResetJoystickMovement();

        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    static public void ResetPlayerLocation()
    {
        GameObject player = GameObject.Find("XR Origin");
        GameObject spawn = GameObject.Find("SpawnLocation");
        player.transform.position = spawn.transform.position;
        player.transform.rotation = spawn.transform.rotation;
    }

    static public void ResetPlayerData()
    {
        PlayerData player = GameObject.Find("XR Origin").GetComponent<PlayerData>();
        player.Refuel();
        player.resetCollection();
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt("fuel", fuel);
        PlayerPrefs.SetInt("collectibles", collectibles);
        PlayerPrefs.SetString("difficulty", difficulty.ToString());
    }
}
