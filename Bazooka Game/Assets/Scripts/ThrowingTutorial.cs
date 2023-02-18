using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ThrowingTutorial : MonoBehaviour
{
    Animator animator;
    [Header("References")]
    public Transform cam;
    public Transform attackPoint;
    public GameObject objectToThrow;
    public GameObject slot1Script;

    [Header("Settings")]
    public int totalThrows;
    public float throwCooldown;
    public bool isNotEquipped = true;
    int isNotEquippedHash;

    [Header("Throwing")]
    public KeyCode throwKey = KeyCode.Mouse0;
    public float throwForce;
    public float throwUpwardForce;

    bool readyToThrow;

    private void Start()
    {
        animator = GetComponent<Animator>();
        readyToThrow = true;
        isNotEquippedHash = Animator.StringToHash("isSheathed");

    }

    private void Update()
    {
        Sheathed();
        if(!isNotEquipped)
        {
            if(Input.GetKeyDown(throwKey) && readyToThrow && totalThrows > 0)
        {
            Throw();
        }
        }
    }


    private void Throw()
    {
        readyToThrow = false;

        // instantiate object to throw
        GameObject projectile = Instantiate(objectToThrow, attackPoint.position, cam.rotation);

        // get rigidbody component
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        // calculate direction
        Vector3 forceDirection = cam.transform.forward;

        RaycastHit hit;

        if(Physics.Raycast(cam.position, cam.forward, out hit, 500f))
        {
            forceDirection = (hit.point - attackPoint.position).normalized;
        }

        // add force
        Vector3 forceToAdd = forceDirection * throwForce + transform.up * throwUpwardForce;

        projectileRb.AddForce(forceToAdd, ForceMode.Impulse);

        totalThrows--;

        // implement throwCooldown
        Invoke(nameof(ResetThrow), throwCooldown);
    }

   
    void Sheathed()
    {
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            isNotEquipped = !isNotEquipped;
            slot1Script.GetComponent<EpicSwordScript>().isSheathed = true;

        }
        if(isNotEquipped)
        {
            animator.SetBool(isNotEquippedHash, true);
        }
        else
        {
            animator.SetBool(isNotEquippedHash, false);
        }
        
    }
    

    private void ResetThrow()
    {
        readyToThrow = true;
    }
}