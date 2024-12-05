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
    public int collectibles = 0;

    public enum Difficulty
    {
        Medium,
        Hard
    }
    public static Difficulty difficulty;

    private void OnEnable()
    {
        fuel = PlayerPrefs.GetInt("fuel");
        collectibles= PlayerPrefs.GetInt("collectibles");
        Enum.TryParse(PlayerPrefs.GetString("difficulty"), out difficulty);
        ResetCollection();
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

    public void CollectItem()
    {
        collectibles++;
        collectibleGauge.text = collectibles.ToString() + "/6";
    }

    public void ResetCollection()
    {
        collectibles = 0;
        collectibleGauge.text = collectibles.ToString() + "/6";
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
        player.ResetCollection();
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt("fuel", fuel);
        PlayerPrefs.SetInt("collectibles", collectibles);
        PlayerPrefs.SetString("difficulty", difficulty.ToString());
    }
}
