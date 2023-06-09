using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class PausePanel : MonoBehaviour
{
    public AudioMixerGroup Mixer;
public void ToggleMusic(bool Enabled){
    if(enabled){
        Mixer.audioMixer.SetFloat("MusicVolume",0);
    }
    else Mixer.audioMixer.SetFloat("MusicVolume",1);
}

public void ChangeVolume(float volume ){
    Mixer.audioMixer.SetFloat("MasterVolume",Mathf.Lerp(0,-80,volume));
}
}
