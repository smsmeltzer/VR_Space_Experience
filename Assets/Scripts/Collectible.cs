using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;


public class Collectible : MonoBehaviour
{

    public Vector3 initialAngularVelocity = new Vector3(0.5f, 1f, 0.33f); // Define angular velocity in the Inspector

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.angularVelocity = initialAngularVelocity;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Triggered in XRGrabInteractable component of collectible prefabs
    public void OnCollected()
    {
        Object.Destroy(this.gameObject);
    }
}