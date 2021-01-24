using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTimer : MonoBehaviour
{
    public int timer = 30;
    // Start is called before the first frame update
    void Start()
    {
        SomeCoroutine();
    }

    private IEnumerator SomeCoroutine()
    {
        yield return new WaitForSeconds(timer);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
