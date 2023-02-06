using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float Xsens;
    public float Ysens;

    public Transform playerBody;

    float rotX;
    float rotY;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        LookAround();
    }

    private void LookAround()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * Xsens;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * Ysens;

        rotY += mouseX;
        rotX -= mouseY;

        rotX = Mathf.Clamp(rotX, -90f, 90f);
        
        transform.rotation = Quaternion.Euler(rotX, rotY, 0);
        playerBody.rotation = Quaternion.Euler (0, rotY, 0);
    }
}
