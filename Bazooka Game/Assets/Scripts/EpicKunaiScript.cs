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

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag!="Player")
        {
        rb.freezeRotation = true;
        rb.isKinematic = true;
        GetComponent<BoxCollider>().enabled = false;
        StartCoroutine(Despawn());
        }
    }
    IEnumerator Despawn()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
