using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonJoystick : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private ControllerInputs controller;
   

    // Update is called once per frame
    void Update()
    {
        if (controller.primaryPressed)
        {
            transform.position = controller.Position;
        }
    }
}
