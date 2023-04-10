using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    public float radius = 10f;
    public float force = 1200f;
    void Start()
    {
        
    }

    void Update()
    {
        Explode();
    }

    public void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach(Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if(rb!=null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }
        StartCoroutine(Despawn());
    }
    IEnumerator Despawn()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
