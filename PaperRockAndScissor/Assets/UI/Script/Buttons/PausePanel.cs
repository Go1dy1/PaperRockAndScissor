using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class PausePanel : MonoBehaviour
{
    public AudioMixerGroup Mixer;
    private bool StopMusic = false;
public void ToggleMusic(){
    if(StopMusic){
        Mixer.audioMixer.SetFloat("MusicVolume",0);
    }
    else Mixer.audioMixer.SetFloat("MusicVolume",-80);

    if(StopMusic)StopMusic= false;
    else StopMusic =true;
}

public void ChangeVolume(float volume ){
    Mixer.audioMixer.SetFloat("MasterVolume",Mathf.Lerp(0,-80,volume));
}
}
