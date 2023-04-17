using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private float distance = 5f; 
    [SerializeField] private LayerMask mask;
    void Start()
    {
        cam = GetComponent<Movement>().PlayerCam;
    }

    // Update is called once per frame
    void Update()
    {
        
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitinfo;
        if(Physics.Raycast(ray, out hitinfo, distance, mask))
        {
            if(hitinfo.collider.GetComponent<Interactable>() != null)
            {
                Debug.Log(hitinfo.collider.GetComponent<Interactable>().promptMessage);
                

            }

        }
    }
}
