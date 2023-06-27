using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPlayingMusic : MonoBehaviour
{
    
    private AudioSource audioDeath;

    void Start()
    {
        audioDeath = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!audioDeath.isPlaying)Destroy(gameObject);
    }
}
