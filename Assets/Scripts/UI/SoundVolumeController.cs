using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundVolumeController : MonoBehaviour
{
    public AudioMixer _audioMixer;
    private float volumeValue;

    private void Awake() 
    {
        volumeValue = -10;
        _audioMixer.SetFloat("volume", volumeValue);
    }

    public void UpVolume()
    {
        if(volumeValue < 0)
        {
            volumeValue = volumeValue + 10;
            _audioMixer.SetFloat("volume", volumeValue);
        }
    }

    public void DownVolume()
    {
        volumeValue = volumeValue - 10;
        _audioMixer.SetFloat("volume", volumeValue);
    }
}
