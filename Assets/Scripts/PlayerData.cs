using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField] private FuelGaugeBehavior fuelGauge;
    public int fuel;
    public bool isGrabbing = false;
    public TextMeshProUGUI collectibleGauge;
    public int collectibles;

    public enum Difficulty
    {
        Easy,
        Medium,
        Hard
    }
    public Difficulty difficulty;

    void Start()
    {
        fuel = 100;
        collectibles = 0;
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

    public void collectItem()
    {
        collectibles++;
        collectibleGauge.text = collectibles.ToString();
    }
}
