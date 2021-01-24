using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using System;
using TMPro;



public class Scoreboard : MonoBehaviour
{
    public GameObject alert;
    TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        alert.GetComponent<UnityEngine.UI.Image>().enabled = false;
        alert.GetComponentInChildren < TMP_Text >().enabled = false;
    }

    // Update is called once per frame
    int i = 0;
    void Update()
    {
        i++;
        //Debug.Log(i.ToString());
        if(GameObject.FindWithTag("Player") == null || GameObject.FindWithTag("scoreboard") == null || GameObject.FindWithTag("restartcanvas") == null)
            {
            return;
        }
        GameObject.FindWithTag("scoreboard").GetComponent<Transform>().Find("Text").GetComponent<Text>().text = Math.Round(GameObject.FindWithTag("Player").GetComponent<Transform>().position.z+25).ToString();
        GameObject.FindWithTag("restart").GetComponent<Transform>().Find("Points").GetComponent<Text>().text = Math.Round(GameObject.FindWithTag("Player").GetComponent<Transform>().position.z+25).ToString();

        //Debug.Log(GameObject.FindWithTag("Scoreboard").GetComponent<Transform>().position.z.ToString());

    }
}
