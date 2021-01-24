using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class RandomObstacleGenerator : MonoBehaviour
{
    public GameObject prefab;
    public GameObject[] midtraps;
    public GameObject[] leftrighttraps;

    public bool triggeragain = false;
    private bool isTriggered = false;

    public void spawntraps(bool booltrigger)
    {
        if (isTriggered)
        {
            return;
        }
        isTriggered = true;
        Debug.Log("Position: "+gameObject.transform.position.ToString());
        Debug.Log("Bound size: "+gameObject.GetComponent<MeshRenderer>().bounds.size); 
        GameObject trap1 = Instantiate(leftrighttraps[Random.Range(0, leftrighttraps.Length)], gameObject.GetComponent<Transform>().position + Vector3.forward * 10F + Vector3.left * 4f, Quaternion.Euler(0f, 0f, 0f));
        GameObject trap2 = Instantiate(leftrighttraps[Random.Range(0, leftrighttraps.Length)], gameObject.GetComponent<Transform>().position + Vector3.forward * 20F + Vector3.right * 4f, Quaternion.Euler(0f, 0f, 0f));
        GameObject trap3 = Instantiate(midtraps[Random.Range(0, midtraps.Length)], gameObject.GetComponent<Transform>().position + Vector3.forward * 30F, Quaternion.Euler(0f, 0f, 0f));
        GameObject trap4 = Instantiate(midtraps[Random.Range(0, midtraps.Length)], gameObject.GetComponent<Transform>().position + Vector3.forward * 40F, Quaternion.Euler(0f, 0f, 0f));
        GameObject trap5 = Instantiate(leftrighttraps[Random.Range(0, leftrighttraps.Length)], gameObject.GetComponent<Transform>().position + Vector3.forward * 50F + Vector3.right * 4f, Quaternion.Euler(0f, 0f, 0f));
        if (booltrigger == triggeragain)
        {
            Destroy(trap1);
            Destroy(trap2);
            Destroy(trap3);
            Destroy(trap4);
            Destroy(trap5);
        }
    }
}
