using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIndicator : MonoBehaviour
{
    List<SpaceIndicator> spaceindicator = new List<SpaceIndicator>();
    bool enemiesthere = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("enemy") == null)
        {
            return;
        }
        spaceindicator.Add(GameObject.FindObjectOfType<SpaceIndicator>());
        for (int i = 0; i < spaceindicator.Count; i++)
        {
                if (spaceindicator[i].enemyisnearplayer == true)
                {
                    gameObject.GetComponent<UnityEngine.UI.Image>().enabled = true;
                    return;
                }
                else
                {
                    gameObject.GetComponent<UnityEngine.UI.Image>().enabled = false;
                }
        }
        

        
      
    }
}
