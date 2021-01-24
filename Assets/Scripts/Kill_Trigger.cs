using DitzeGames.Effects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class Kill_Trigger : MonoBehaviour{

    
  

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject.FindWithTag("Player").GetComponent<CubeMovement>().enabled = false;
            GameObject.FindWithTag("scoreboard").GetComponent<Canvas>().enabled = false;
            GameObject.FindWithTag("restart").GetComponent<Canvas>().enabled = true;
            GameObject.FindWithTag("Player").GetComponent<CameraEffects>().ShakeOnce(0.3f, 20, new Vector3(2, 2, 2), GameObject.FindWithTag("MainCamera").GetComponent<Camera>());
            Debug.Log("Funktioniert");
            
            if(PlayerPrefs.GetInt("Score", 0) < (int)Math.Round(GameObject.FindWithTag("Player").GetComponent<Transform>().position.z))
            {
                PlayerPrefs.SetInt("Score", (int)Math.Round(GameObject.FindWithTag("Player").GetComponent<Transform>().position.z+25));
                PlayerPrefs.Save();
            }
            StartCoroutine(Die(other));
            
            


            
        }
    }

    private IEnumerator Die(Collider other)
    {
        yield return new WaitForSeconds(0.2f);
        GameObject.FindWithTag("hurensohnalert").GetComponent<EnemyIndicator>().enabled=false;
        other.gameObject.SetActive(false);
    }

    private IEnumerator SomeCoroutine()
    {
        yield return new WaitForSeconds(5);
    }
    public void Genfloor()
    {
        StartCoroutine(SomeCoroutine());
    }
}

