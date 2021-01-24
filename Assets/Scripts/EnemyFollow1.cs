using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow1 : MonoBehaviour
{
    public float speed;
    private Transform target;


    private void Update()
    {
    
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        Vector3 offset = GameObject.FindWithTag("enemy2").GetComponent<Transform>().position;
        offset.y = -0.3f;
        
        GameObject.FindWithTag("enemy2").GetComponent<Transform>().position = offset;

    }
}

