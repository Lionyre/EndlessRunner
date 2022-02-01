using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeObjects : MonoBehaviour
{
    public ParticleSystem _spawnParticle;


    private void Awake() 
    {
        _spawnParticle.Play();
    }
}
