using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenScript : MonoBehaviour
{
    Rigidbody rb;
    bool canSpin;
   
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        canSpin = true;
    }

    
    void Update()
    {
        if(canSpin)
        {
            Spin();
        }
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag!="Player")
        {
        canSpin = false;
        rb.freezeRotation = true;
        rb.isKinematic = true;
        GetComponent<BoxCollider>().enabled = false;
        }
    }

    void Spin()
    {
        transform.Rotate(0f, 5f, 0f, Space.Self);
    }
}
