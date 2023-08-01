using UnityEngine;

public class StopPlayingMusic : MonoBehaviour
{
    
    private AudioSource _audioDeath;

    void Start()
    {
        _audioDeath = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!_audioDeath.isPlaying)Destroy(gameObject);
    }
}
