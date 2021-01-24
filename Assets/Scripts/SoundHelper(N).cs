using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHelper : MonoBehaviour{
   
    public AM.AudioPlayClass soundToPlay;
    public bool playSoundOnStartup = false;

    private AM audioManager;

    void Start(){
        audioManager = Object.FindObjectOfType<AM>();
        if(playSoundOnStartup)
            audioManager.PlaySound(soundToPlay);
    }

    public void AnimationEventFunction(){
        audioManager.PlaySound(soundToPlay);
    }

}
