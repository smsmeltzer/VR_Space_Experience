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
        if (PlayerData.difficulty != PlayerData.Difficulty.Hard)
        {
            PlayerData.difficulty = PlayerData.difficulty + 1;
            DifficultyDisplay.text = PlayerData.difficulty.ToString();
        }
    }

    public void decreaseDifficulty()
    {
        if (PlayerData.difficulty != PlayerData.Difficulty.Easy)
        {
            PlayerData.difficulty = PlayerData.difficulty - 1;
            DifficultyDisplay.text = PlayerData.difficulty.ToString();
        }
    }
}
