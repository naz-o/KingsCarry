using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookatObjects : MonoBehaviour
{

    public Transform objectToFollow;
    public bool doUnparent = true;
    public bool doLookAtObject = true;
    public bool invertLookAt = true;

    private Transform tr;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    void LateUpdate()
    {
        if (doLookAtObject)
        {
            if (GameObject.FindWithTag("Player") == null)
            {
                return;
            }
            Vector3 v = GameObject.FindWithTag("Player").GetComponent<Transform>().position;
        
            v.y = tr.position.y;
            tr.LookAt(v);
            if (invertLookAt)
                tr.Rotate(Vector3.up * 180, Space.Self);
        }

    }
}