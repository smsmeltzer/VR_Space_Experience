using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class FuelGaugeBehavior : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI percentageText;
    public GameObject[] display;

    // Update is called once per frame
    public void UpdateDisplay(int num)
    {
        percentageText.text = num + "%";
        if (num > 75 && num <= 100)
        {
            foreach (GameObject obj in display)
            {
                obj.SetActive(true);
            }
        }
        else if (num > 50 && num <= 75)
        {
            display[0].SetActive(true);
            display[1].SetActive(true);
            display[2].SetActive(true);
            display[3].SetActive(false);
        }
        else if (num > 25 && num <= 50)
        {
            display[0].SetActive(true);
            display[1].SetActive(true);
            display[2].SetActive(false);
            display[3].SetActive(false);
        }
        else if (num > 0 && num <= 25)
        {
            display[0].SetActive(true);
            display[1].SetActive(false);
            display[2].SetActive(false);
            display[3].SetActive(false);
        }
        else
        {
            foreach (GameObject obj in display)
            {
                obj.SetActive(false);
            }
        }
    }
}
