using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GenerateMap : MonoBehaviour
{

    public GameObject prefab;
    public Vector3 startPosition;
    private int count = 0;


    private List<GameObject> mapObjects;

    void Start()
    {
        mapObjects = new List<GameObject>();
    }


    public void CallCreateAnotherMap()
    {
        GameObject newGameObjet = Instantiate(prefab, startPosition + Vector3.forward * 50F * count, Quaternion.Euler(0f, 90f, 0f));

        newGameObjet.GetComponent<RandomObstacleGenerator>().spawntraps(true);
        mapObjects.Add(newGameObjet);
        count++;
    }

    public void CallDeleteFirstMapObject()
    {
        //only destroy the first one, if we have more than 3 objects in it
        if (mapObjects.Count > 4)
        {
            Destroy(mapObjects[0]);
            mapObjects.RemoveAt(0);
        }
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (isTriggered)
        {
            return;
        }
        isTriggered = true;
        newyeet = Instantiate(prefab, GetComponent<Transform>().position + Vector3.forward * 50F, Quaternion.Euler(0f,90f,0f));
        gameObject.GetComponent<RandomObstacleGenerator>().spawntraps(true);
        i++;
    }

 

    private void OnTriggerExit(Collider other)
    {
        Destroy(newyeet);
        Debug.Log("DESTROYING MAP");
        gameObject.GetComponent<RandomObstacleGenerator>().triggeragain = true;

 

    }
    */

}