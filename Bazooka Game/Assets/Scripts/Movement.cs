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

    Rigidbody rb;

    public float groundDistance;
    public LayerMask thisIsGround;
    public bool grounded;
    public float groundDrag;
    public float airDrag;

    public float fixedJumpCooldown;
    public bool readyToJump;
    public float canJump;
    public float fixedCoyoteTime;
    public float airMultiplier;

    [SerializeField] float speedx;
    [SerializeField] float speedz;
    

    public float gravityScale = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        ResetJump();
    }

    void Update()
    {
        canJump -= Time.deltaTime;
        if (Physics.Raycast(groundCheck.position, Vector3.down, groundDistance, thisIsGround) || Physics.Raycast(groundCheck1.position, Vector3.down, groundDistance, thisIsGround) || Physics.Raycast(groundCheck2.position, Vector3.down, groundDistance, thisIsGround) || Physics.Raycast(groundCheck3.position, Vector3.down, groundDistance, thisIsGround) || Physics.Raycast(groundCheck4.position, Vector3.down, groundDistance, thisIsGround) || Physics.Raycast(groundCheck5.position, Vector3.down, groundDistance, thisIsGround) || Physics.Raycast(groundCheck6.position, Vector3.down, groundDistance, thisIsGround) || Physics.Raycast(groundCheck7.position, Vector3.down, groundDistance, thisIsGround))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
        if (grounded)
        {
            canJump = fixedCoyoteTime;
        }
        AddDrag();
        GetInput();
        SpeedControl();
        LiveSpeedInEditor();
    }
    void LiveSpeedInEditor()
    {
        speedx = rb.velocity.x;
        speedz = rb.velocity.z;
    }

    void FixedUpdate()
    {
        MovePlayer();
        rb.AddForce(Physics.gravity * (gravityScale - 1) * rb.mass);
    }

    void GetInput()
    {
        //Regular movement
        horizInput = Input.GetAxisRaw("Horizontal");
        vertInput = Input.GetAxisRaw("Vertical");

        //Jumping
        if (Input.GetKey(KeyCode.Space) && canJump > 0f && readyToJump)
        {
            readyToJump = false;
            canJump = 0f;
            Jump();
            Invoke(nameof(ResetJump), fixedJumpCooldown);
        }
        CheckSprint();
    }

    void MovePlayer()
    {
        moveDirection = playerBody.forward * vertInput + playerBody.right * horizInput;
//sussy
        if (grounded)
        {
            rb.AddForce(moveDirection.normalized * currentMoveSpeed * 10f, ForceMode.Force);
        }
        else if (!grounded)
        {
            rb.AddForce(moveDirection.normalized * currentMoveSpeed * 10f * airMultiplier, ForceMode.Force);
        }
    }

    void CheckSprint()
    {
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.W))
        {
            currentMoveSpeed = sprintSpeed;
            airMultiplier = 0.3f;
        }
        else
        {
            currentMoveSpeed = walkSpeed;
            airMultiplier = 0.1f;
        }
    }

    void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if (flatVel.magnitude > currentMoveSpeed)
        {
            Vector3 maxVel = flatVel.normalized * currentMoveSpeed;
            rb.velocity = new Vector3(maxVel.x, rb.velocity.y, maxVel.z);
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
    void AddDrag()
    {
        //if (grounded) {rb.drag = groundDrag;}
        //else {rb.drag = airDrag;}

        if (!readyToJump) {rb.drag = airDrag;}
        else if (canJump <= 0f) {rb.drag = airDrag;}
        else {rb.drag = groundDrag;}
    }
}
