using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPlayingParticle : MonoBehaviour
{
    private ParticleSystem _particle;
    void Start()
    {
        _particle = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!_particle.isPlaying)Destroy(gameObject);

      
    }
}
