using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

public class Pausegame : MonoBehaviour
{

    public GameObject Canvas;
    //public GameObject Camera;
    public static bool Paused = false;

   

    public void Pause()
    {
            if (Paused == true)
            {
                Time.timeScale = 1.0f;
                Canvas.gameObject.SetActive(false);

                
                //Camera.GetComponent<AudioSource>().Play();
                Paused = false;
                
            }
            else
            {
                Time.timeScale = 0.0f;
                Canvas.gameObject.SetActive(true);

                Paused = true;
            }
        
    }
    public void Resume()
    {
        Time.timeScale = 1.0f;
        Canvas.gameObject.SetActive(false);
        Paused = false;
        //Camera.GetComponent<AudioSource>().Play();
    }
}