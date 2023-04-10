using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 5f;
    public bool isEnemy;
    public bool explode;
    public ParticleSystem boom;
    public Transform boomPoint;

    public void Damaged(float amount)
    {
        health -= amount;
        if(health<=0)
        {
            if(explode)
            {
                Instantiate(boom, boomPoint.position, boomPoint.rotation);
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
