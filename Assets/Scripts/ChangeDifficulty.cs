using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeDifficulty : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI DifficultyDisplay;
    private PlayerData PlayerData;
    // Start is called before the first frame update
    void Start()
    {
        PlayerData = GameObject.Find("XR Origin").GetComponent<PlayerData>();
        DifficultyDisplay.text = PlayerData.difficulty.ToString();
    }
    public void increaseDifficulty()
    {
        PlayerData.difficulty = PlayerData.Difficulty.Hard;
        DifficultyDisplay.text = PlayerData.difficulty.ToString();
    }

    public void decreaseDifficulty()
    {
        PlayerData.difficulty = PlayerData.Difficulty.Medium;
        DifficultyDisplay.text = PlayerData.difficulty.ToString();
    }
}
