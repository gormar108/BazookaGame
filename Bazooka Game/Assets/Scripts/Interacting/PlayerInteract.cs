using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private float distance = 5f; 
    [SerializeField] private LayerMask mask;
    [SerializeField] GameObject canvasText;
    [SerializeField] TextMeshProUGUI textlabel;

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
                Interactable interactable = hitinfo.collider.GetComponent<Interactable>();
                //Debug.Log(interactable.promptMessage);
                canvasText.active = true;
                textlabel.text = "Press E to " + interactable.promptMessage;
                hitinfo.collider.GetComponent<Outline>().enabled = true;
                if(Input.GetKeyDown(KeyCode.E))
                {
                    interactable.BaseInteract();
                }
            }

        }
        else
        {
            canvasText.active = false;
            
            hitinfo.collider.GetComponent<Outline>().enabled = false;            
        }
    }
}
