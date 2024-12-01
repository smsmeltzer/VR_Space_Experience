using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraRotation : MonoBehaviour
{
    public InputActionProperty headRotation;
    public GameObject PlayerModel;

    private Quaternion Rotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotation = headRotation.action.ReadValue<Quaternion>();
        PlayerModel.transform.rotation = Quaternion.Euler(0, Rotation.y, 0);
    }
}
