using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMapTrigger : MonoBehaviour
{

    private bool isTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (isTriggered)    //only call it once
            return;

        isTriggered = true;
        Object.FindObjectOfType<GenerateMap>().CallCreateAnotherMap();
    }



    private void OnTriggerExit(Collider other)
    {
        Object.FindObjectOfType<GenerateMap>().CallDeleteFirstMapObject();
    }
}
