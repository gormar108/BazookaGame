using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingBarrel : Interactable
{
    public ParticleSystem boom;
    public Transform boomPoint;
    public float waitTime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void Interact()
    {
        //Debug.Log("Interacted with me" + gameObject.name);
        StartCoroutine(IgniteTime());
        
    }
    IEnumerator IgniteTime()
    {
        yield return new WaitForSeconds(waitTime);
        Instantiate(boom, boomPoint.position, boomPoint.rotation);
        Destroy(gameObject);
    }
}
