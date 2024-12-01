using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.tag == "Player")
        {
            Rigidbody rb = obj.GetComponent<Rigidbody>();   
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;  
            rb.rotation = Quaternion.identity;  
        }
    }
}
