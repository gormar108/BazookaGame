using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float walkSpeed;
    public float sprintSpeed;
    public float currentMoveSpeed;
    public float jumpHeight;
    public bool sprinting;
    
    Vector3 moveDirection;

    float horizInput;
    float vertInput;

    public Transform playerBody;
    public Transform groundCheck;
    public Transform groundCheck1;
    public Transform groundCheck2;
    public Transform groundCheck3;
    public Transform groundCheck4;
    public Transform groundCheck5;
    public Transform groundCheck6;
    public Transform groundCheck7;
    public Transform groundCheck8;

    Rigidbody rb;

    public float groundDistance;
    public LayerMask thisIsGround;
    public bool grounded;

    public float dragOnGround;
    public float speedInAirMultiplier;

    public float fixedJumpCooldown;
    public bool readyToJump;


    [SerializeField] float speedx;
    [SerializeField] float speedz;
    [SerializeField] float totalSpeed;
    
    public float gravityScale = 5f;

    CollisionHandler clsnScript;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        ResetJump();
        clsnScript = GetComponent<CollisionHandler>();
    }

    void Update()
    {
        GroundCheck();
        GetInput();
        LiveSpeedInEditor();
        CheckSprint();
    }

    void FixedUpdate()
    {
        MovePlayer();
        rb.AddForce(Physics.gravity * (gravityScale - 1) * rb.mass);
    }

    void GroundCheck()
    {
        if (Physics.Raycast(groundCheck.position, Vector3.down, groundDistance, thisIsGround) || Physics.Raycast(groundCheck1.position, Vector3.down, groundDistance, thisIsGround) || Physics.Raycast(groundCheck2.position, Vector3.down, groundDistance, thisIsGround) || Physics.Raycast(groundCheck3.position, Vector3.down, groundDistance, thisIsGround) || Physics.Raycast(groundCheck4.position, Vector3.down, groundDistance, thisIsGround) || Physics.Raycast(groundCheck5.position, Vector3.down, groundDistance, thisIsGround) || Physics.Raycast(groundCheck6.position, Vector3.down, groundDistance, thisIsGround) || Physics.Raycast(groundCheck7.position, Vector3.down, groundDistance, thisIsGround) || Physics.Raycast(groundCheck8.position, Vector3.down, groundDistance, thisIsGround))
            { grounded = true;}
        else { grounded = false;}
    }

    void GetInput()
    {
        //Regular movement
        horizInput = Input.GetAxisRaw("Horizontal");
        vertInput = Input.GetAxisRaw("Vertical");

        //Jumping
        if (Input.GetKey(KeyCode.Space) && readyToJump && grounded)
        {
            readyToJump = false;
            Jump();
            Invoke(nameof(ResetJump), fixedJumpCooldown);
        }
    }

    void MovePlayer()
    {
        moveDirection = playerBody.forward * vertInput + playerBody.right * horizInput;

        if (grounded)
        {
            float dragx = -dragOnGround * rb.velocity.x;
            float dragz = -dragOnGround * rb.velocity.z;
            rb.AddForce(new Vector3(dragx, 0f, dragz));

            rb.AddForce(moveDirection.normalized * currentMoveSpeed, ForceMode.Acceleration);
        }
        else
        {
            rb.AddForce(moveDirection.normalized * currentMoveSpeed * speedInAirMultiplier, ForceMode.Acceleration);
        }

    }

    void LiveSpeedInEditor()
    {
        speedx = rb.velocity.x;
        speedz = rb.velocity.z;

        //Perform Pythagoras' Theorem on speeds to get total speed regardless of individual axes
        totalSpeed = Mathf.Sqrt((speedx * speedx) + (speedz * speedz));
    }

    void CheckSprint()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.LeftControl))
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                sprinting = true;
            }
        }
        else
        {
            sprinting = false;
        }

        if (clsnScript.touchingWall)
        {
            sprinting = false;
        }

        if (sprinting)
        {
            currentMoveSpeed = sprintSpeed;
            speedInAirMultiplier = 0.19f;
        }
        else
        {
            currentMoveSpeed = walkSpeed;
            speedInAirMultiplier = 0.1f;
        }
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpHeight, ForceMode.Impulse);
    }

    void ResetJump()
    {
        readyToJump = true;
    }
}