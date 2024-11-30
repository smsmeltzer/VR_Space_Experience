using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField] private GameObject fuelGauge;
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
        difficulty = Difficulty.Hard;
        collectibles = 0;
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
