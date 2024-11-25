using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VRConsole : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private ControllerInputs LInput;
    [SerializeField] private ControllerInputs RInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "L:\n" + LInput.ToString();
        text.text += '\n';
        text.text += "R:\n" + RInput.ToString(); 
    }

}
