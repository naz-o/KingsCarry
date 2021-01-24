using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGate : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        GameObject.FindWithTag("enemy2").GetComponent<EnemyFollow1>().enabled = true;
    }
  
}

