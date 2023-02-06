using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 100f;
    public float jumpHeight = 100f;

    Vector3 moveDirection;

    float horizInput;
    float vertInput;

    public Transform playerBody;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    void Update()
    {
        GetInput();
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void GetInput()
    {
        horizInput = Input.GetAxisRaw("Horizontal");
        vertInput = Input.GetAxisRaw("Vertical");
    }

    void MovePlayer()
    {
        moveDirection = playerBody.forward * vertInput + playerBody.right * horizInput;

        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }
}
