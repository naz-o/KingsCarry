using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed;
    private Transform target;
    public bool execute = false;

     void OnTriggerExit(Collider other)
    {
        //GetComponent<LookatObjects>().enabled = true;
        execute = true;
    }
    private void Update()
    {
        if (!execute)
        {
            return;
        }
        if (GameObject.FindWithTag("Player") == null)
        {
            return;
        }

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        Vector3 offset = GameObject.FindWithTag("enemy").GetComponent<Transform>().position;
        offset.y = -0.3f;
        
        GameObject.FindWithTag("enemy").GetComponent<Transform>().position = offset;

    }
}

