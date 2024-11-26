using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField] private GameObject fuelGauge;
    public int fuel;

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
