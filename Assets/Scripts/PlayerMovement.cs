using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
     public float horizontalSpeed = 1.5F;
     public float verticalSpeed = 1.5F;

    public float rotationSpeed = 1.5f;
    public float movementSpeed = 0.001f;


    float rzo = 0f;
    float h = 0f;
    float v = 0f;


    Rigidbody rb;


    void playerRotation()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            rzo = rotationSpeed * 0.15f;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            rzo = rotationSpeed * -0.15f;
        }
        else
        {
            rzo = 0;
        }
    }
    void playerMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * movementSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += -transform.right * movementSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += -transform.forward * movementSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * movementSpeed;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position += transform.up * movementSpeed;
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            transform.position += -transform.up * movementSpeed;
        }
        if (Input.GetKey(KeyCode.Tab))
        {
            if(Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
    void mouseRotation()
    {
        h = horizontalSpeed * Input.GetAxis("Mouse X");
        v = verticalSpeed * Input.GetAxis("Mouse Y");
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

 
    void Update()
    {
        mouseRotation();
        playerMovement();
        playerRotation();
        transform.Rotate(-v, h, rzo);
    }
}
