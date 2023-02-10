using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EpicKunaiScript : MonoBehaviour
{
    Rigidbody rb;
   
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
    }

    void OnCollisionEnter(Collision other)
    {
        rb.freezeRotation = true;
        rb.isKinematic = true;
        GetComponent<BoxCollider>().enabled = false;
    }
}
