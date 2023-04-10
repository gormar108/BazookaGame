using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenScript : MonoBehaviour
{
    Rigidbody rb;
    bool canSpin;
    public bool possibleSpin;
    public float damage;
    public ParticleSystem spark;
    public ParticleSystem blood;
   
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
            Target target = other.transform.GetComponent<Target>();
            if(target != null)
            {
                target.Damaged(damage);
                if(target.isEnemy) 
                {
                    blood.Play();
                }
            }
            else
            {
                spark.Play();
            }
            canSpin = false;
            rb.freezeRotation = true;
            rb.isKinematic = true;
            GetComponent<BoxCollider>().enabled = false;
            gameObject.transform.parent = other.transform;
            StartCoroutine(Despawn());
        }
    }

    IEnumerator Despawn()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

    void Spin()
    {
        if(possibleSpin==true)
        {
            transform.Rotate(0f, 5f, 0f, Space.Self);
        }
    }
}
