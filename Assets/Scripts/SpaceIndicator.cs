using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpaceIndicator : MonoBehaviour
{
    public  Transform objectdifferentiator;
    public bool enemyisnearplayer = false;
    EnemyFollow enemyfollowscript;
    public GameObject alert;
    // Start is called before the first frame update
    void Start()
    {
        objectdifferentiator = GameObject.FindGameObjectWithTag("Player").transform;
        enemyfollowscript = gameObject.GetComponent<EnemyFollow>();
    }


    // Update is called once per frame
    void Update()
    {


      float path = Vector3.Distance(objectdifferentiator.position, gameObject.GetComponent<Transform>().position);
        //Debug.Log("Distance: " + path);

        if (path <= 20 && enemyfollowscript.execute == true)
        {
            enemyisnearplayer = true;
        }
        else
        {
            enemyisnearplayer = false;
        }
            if (path > 100)
        {
            Destroy(gameObject);
        }

       
    }
}
