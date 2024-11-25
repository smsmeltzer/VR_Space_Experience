using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField] private GameObject fuelGauge;
    public int fuel;

    void Start()
    {
        fuel = 100;
    }

    void Update()
    {
        
    }

    public void Refuel()
    {
        fuel = 100;
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
        return true;
    }

    public bool HasFuel()
    {
        return fuel > 0;
    }
}
