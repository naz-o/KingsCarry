﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void Menu()
    {
        
        Pausegame.Paused = false;
        Time.timeScale = 1.0f;      
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        
    }

   
}
