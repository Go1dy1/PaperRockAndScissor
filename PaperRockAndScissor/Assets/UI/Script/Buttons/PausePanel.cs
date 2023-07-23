using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Serialization;

public class PausePanel : MonoBehaviour
{
    [FormerlySerializedAs("Mixer")] public AudioMixerGroup _mixer;
    private bool _stopMusic = false;
public void ToggleMusic(){
    if(_stopMusic){
        _mixer.audioMixer.SetFloat("MusicVolume",0);
    }
    else _mixer.audioMixer.SetFloat("MusicVolume",-80);

    if(_stopMusic)_stopMusic= false;
    else _stopMusic =true;
}

public void ChangeVolume(float volume ){
    _mixer.audioMixer.SetFloat("MasterVolume",Mathf.Lerp(0,-80,volume));
}
}
