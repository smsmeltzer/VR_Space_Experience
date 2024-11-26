using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField] private GameObject fuelGauge;
    public int fuel;
    public TextMeshProUGUI collectibleGauge;
    public int collectibles;

    void Start()
    {
        fuel = 100;
        collectibles = 0;
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

    public void collectItem()
    {
        collectibles++;
        collectibleGauge.text = collectibles.ToString();
    }
}
