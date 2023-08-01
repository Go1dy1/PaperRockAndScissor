using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Serialization;

public class PausePanel : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixer;
    private bool _stopMusic;
    private void ToggleMusic()
    {
        if(_stopMusic) _mixer.audioMixer.SetFloat("MusicVolume",0);
        
        else _mixer.audioMixer.SetFloat("MusicVolume",-80);

        _stopMusic = !_stopMusic;
    }

    private void ChangeVolume(float volume )
    {
        _mixer.audioMixer.SetFloat("MasterVolume",Mathf.Lerp(0,-80,volume));
    }
}
