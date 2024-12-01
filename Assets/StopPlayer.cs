using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPlayer : MonoBehaviour
{
    [SerializeField] ControllerInputs right;
    [SerializeField] ControllerInputs left;
    public float HoldTime = 3.0f;

    private bool pressed = false;
    private float timer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (right.secondaryPressed && left.secondaryPressed) {
            PlayerData.StopPlayerMovement();
            GetComponent<JoystickVelocity>().ResetJoystickMovement();
            pressed = true;
        }

        if (pressed)
        {
            timer += Time.deltaTime;

            if (timer > HoldTime)
            {
                SoftReset();
                timer = 0.0f;
                pressed = false;
            }
        }
    }

    public void SoftReset()
    {
        PlayerData.ResetPlayerLocation();
        PlayerData.ResetPlayerMovement();
    }
}
