using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class CubeMovement : MonoBehaviour
{
    public float zlastpos;
    float t;
    Rigidbody rb;
    public float speed=6f;
    public float swipemove = 8f;
    UnityEngine.Vector3 pointa = new UnityEngine.Vector3();
    UnityEngine.Vector3 pointb = new UnityEngine.Vector3();
    bool movementlockforward = false;
    bool movementlockbackward = false;
    bool movementlockright = false;
    bool movementlockleft = false;
    public Animator playeranimation;
    public Animator kinganimation;

    public GameObject king;
    public GameObject player;
    Transform kingtransform;
    Transform playertransform;
    // Start is called before the first frame update
    void Start()
    {
         rb = GetComponent<Rigidbody>();
        pointa = transform.position;
        pointb = transform.position;

        kingtransform = king.GetComponent<Transform>();
        playertransform = player.GetComponent<Transform>();

    }

    void Movement()
    {

        if (pointb == pointa)
        {
            playeranimation.SetBool("Laufen", false);
            kinganimation.SetBool("Laufen", false);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            pointa = transform.position;
            UnityEngine.Vector3 temp = transform.position + new UnityEngine.Vector3(0f, 0f, 3f);
            pointb = temp;
            t = 0f;
            playeranimation.SetBool("Laufen", true);
            kinganimation.SetBool("Laufen", true);
            kingtransform.rotation = new UnityEngine.Quaternion(0f, 0f, 0f, 0f);
            playertransform.rotation = new UnityEngine.Quaternion(0f, 0f, 0f, 0f);

        }
         if (Input.GetKey(KeyCode.LeftArrow))
        {
            pointa = transform.position;
            UnityEngine.Vector3 temp = transform.position + new UnityEngine.Vector3(-swipemove, 0f, 0f);
            pointb = temp;
            if (pointb.x <= -4.5f)
            {
                pointb.x = -4.5f;
            }
            t = 0f;
            playeranimation.SetBool("Laufen", true);
            kinganimation.SetBool("Laufen", true);
            kingtransform.rotation = UnityEngine.Quaternion.Euler(0f, -90f, 0f);
            playertransform.rotation = UnityEngine.Quaternion.Euler(0f, -90f, 0f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            pointa = transform.position;
            UnityEngine.Vector3 temp = transform.position + new UnityEngine.Vector3(swipemove, 0f, 0f);
            pointb = temp;
            if (pointb.x >= 4.5f)
            {
                pointb.x = 4.5f;
            }
            t = 0f;
            playeranimation.SetBool("Laufen", true);
            kinganimation.SetBool("Laufen", true);
            kingtransform.rotation = UnityEngine.Quaternion.Euler(0f, 90f, 0f);
            playertransform.rotation = UnityEngine.Quaternion.Euler(0f, 90f, 0f);

        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            pointa = transform.position;
            UnityEngine.Vector3 temp = transform.position + new UnityEngine.Vector3(0f, 0f, -3f);
            pointb = temp;
            t = 0f;
            playeranimation.SetBool("Laufen", true);
            kinganimation.SetBool("Laufen", true);
            kingtransform.rotation = UnityEngine.Quaternion.Euler(0f, 180f, 0f);
            playertransform.rotation = UnityEngine.Quaternion.Euler(0f, 180f, 0f);

        }

    }


    // Update is called once per frame
    void Update()
    {


        if (t >= 1f)
        {
            // sets the points to a 0.5 Number
            pointa = new UnityEngine.Vector3((float)(Math.Round(transform.position.x * 2, MidpointRounding.AwayFromZero) / 2), (float)Math.Round(transform.position.y * 2, MidpointRounding.AwayFromZero) / 2, (float)Math.Round(transform.position.z * 2, MidpointRounding.AwayFromZero) / 2);
            pointb = new UnityEngine.Vector3((float)(Math.Round(transform.position.x * 2, MidpointRounding.AwayFromZero) / 2), (float)Math.Round(transform.position.y * 2, MidpointRounding.AwayFromZero) / 2, (float)Math.Round(transform.position.z * 2, MidpointRounding.AwayFromZero) / 2);
            t = 0f;
        }
        Movement();

    }
    private void FixedUpdate()
    {
        t += Time.deltaTime * speed;
        Raycastwalldetection();
        rb.MovePosition(UnityEngine.Vector3.Lerp(pointa, pointb, Easing.OutQuad(t)));

    }

        void Raycastwalldetection()
        {
        if (movementlockforward == true)
        {
            pointb = new UnityEngine.Vector3(pointb.x, transform.position.y, transform.position.z - 0.5f);
        }
        if (movementlockbackward == true)
        {
            pointb = new UnityEngine.Vector3(pointb.x, transform.position.y, transform.position.z + 0.5f);
        }
        if (movementlockright == true)
        {
            pointb = new UnityEngine.Vector3(pointb.x - 0.25f, transform.position.y, transform.position.z);
        }
        if (movementlockleft == true)
        {
            pointb = new UnityEngine.Vector3(pointb.x + 0.25f, transform.position.y, transform.position.z);
        }
        // Raycast forwards
        RaycastHit hit;
            if (Physics.Raycast(transform.position + new UnityEngine.Vector3(0f,0.5f,0f), transform.TransformDirection(UnityEngine.Vector3.forward), out hit, 0.5f))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(UnityEngine.Vector3.forward) * 0.5f, UnityEngine.Color.red);
                //Debug.Log("Raycast hit!");
                if (hit.collider.gameObject.tag == "wall")
                {
                    movementlockforward = true;
                }
            }
            else
            {
                Debug.DrawRay(transform.position + new UnityEngine.Vector3(0f, 0.5f, 0f), transform.TransformDirection(UnityEngine.Vector3.forward) * 0.5f, UnityEngine.Color.red);
               //Debug.Log("Raycast NOT hit!");
                movementlockforward = false;
            }
            // Raycast backwards
       

            RaycastHit hit2;
            if (Physics.Raycast(transform.position + new UnityEngine.Vector3(0f, 0.5f, 0f), transform.TransformDirection(UnityEngine.Vector3.back), out hit2, 0.5f))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(UnityEngine.Vector3.back) * 0.5f, UnityEngine.Color.red);
                //Debug.Log("Raycast hit!");
                if (hit2.collider.gameObject.tag == "wall")
                {
                    movementlockbackward = true;
                }
            }
            else
            {
                Debug.DrawRay(transform.position + new UnityEngine.Vector3(0f, 0.5f, 0f), transform.TransformDirection(UnityEngine.Vector3.back) * 0.5f, UnityEngine.Color.red);
                //Debug.Log("Raycast NOT hit!");
                movementlockbackward = false;
            }



            // Raycast right
            RaycastHit hit3;
            if (Physics.Raycast(transform.position + new UnityEngine.Vector3(0f, 0.5f, 0f), transform.TransformDirection(UnityEngine.Vector3.right), out hit3, 0.5f))
            {
            Debug.DrawRay(transform.position, transform.TransformDirection(UnityEngine.Vector3.right) * 0.5f, UnityEngine.Color.red);
            //Debug.Log("Raycast hit!");
            if (hit3.collider.gameObject.tag == "wall")
            {
                movementlockright = true;
            }
            }
            else
            {
            Debug.DrawRay(transform.position + new UnityEngine.Vector3(0f, 0.5f, 0f), transform.TransformDirection(UnityEngine.Vector3.right) * 0.5f, UnityEngine.Color.red);
            //Debug.Log("Raycast NOT hit!");
            movementlockright = false;
         }


        RaycastHit hit4;
        if (Physics.Raycast(transform.position + new UnityEngine.Vector3(0f, 0.5f, 0f), transform.TransformDirection(UnityEngine.Vector3.left), out hit4, 0.5f))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(UnityEngine.Vector3.left) * 0.5f, UnityEngine.Color.red);
            //Debug.Log("Raycast hit!");
            if (hit4.collider.gameObject.tag == "wall")
            {
                movementlockleft = true;
            }
        }
        else
        {
            Debug.DrawRay(transform.position + new UnityEngine.Vector3(0f, 0.5f, 0f), transform.TransformDirection(UnityEngine.Vector3.left) * 0.5f, UnityEngine.Color.red);
            //Debug.Log("Raycast NOT hit!");
            movementlockleft = false;
        }


    }

    }

