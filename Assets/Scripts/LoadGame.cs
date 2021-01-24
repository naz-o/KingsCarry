using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LoadGame : MonoBehaviour
{
    // Start is called before the first frame update
    public void Loadgame()
    {
        
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        
    }
    private void Start()
    {
        GameObject.FindWithTag("menuscore").GetComponent<Text>().text = PlayerPrefs.GetInt("Score", 0).ToString();
    }

}
