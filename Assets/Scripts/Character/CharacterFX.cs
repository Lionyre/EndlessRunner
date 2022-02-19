using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFX : MonoBehaviour
{
    [SerializeField] private ScreenShake _screenShake;
    [SerializeField] private ParticleSystem[] _particles;
    [SerializeField] private CharacterRenderer _characterRenderer;
    [SerializeField] private BlazingSun _blazingSun;
    [SerializeField] private AudioSource[] _sounds;
    private float _velocity = 0;
    private bool _hit;

    private void Start() 
    {
        _screenShake = GameObject.Find("ScreenShake").GetComponent<ScreenShake>();
        _particles = GetComponentsInChildren<ParticleSystem>();
        _characterRenderer = GameObject.Find("Player-Renderer").GetComponent<CharacterRenderer>();
        _blazingSun = GameObject.Find("Prefab_BlazingSun").GetComponent<BlazingSun>();
    }

    private void Update() 
    {
        PitchVariation();
    }

    public void DashFX()
    {
        _particles[0].Play();
        _particles[1].Play();
        _sounds[0].Play();
        _screenShake.CameraShake(0, 1, 4, 0.2f);
    }

    public void JumpFX()
    {
        _particles[0].Play();
        _particles[1].Play();
        _particles[2].Play();
        _particles[6].Play();
        _sounds[1].Play();
        _screenShake.CameraShake(0, 1, 4, 0.2f);
    }
    
    public void JumpAnim(bool isJumping)
    {
        _characterRenderer.SetJumpBool(isJumping);
    }

    public void CoinFX()
    {
        _particles[5].Play();
        _sounds[2].Play();
    }

    public void SlideFX()
    {
        _particles[0].Play();
        _particles[1].Play();
        _particles[3].Play();
        _particles[4].Play();
        _sounds[3].Play();
        _screenShake.CameraShake(0, 1, 1, 0.6f);
    }

    public void SlidAnim(bool isSliding)
    {
        _characterRenderer.SetSlideBool(isSliding);
    }

    public void DeathFX()
    {
        _screenShake.CameraShake(0, 1, 8, 0.2f);
        
        _particles[11].Play();
        _characterRenderer.gameObject.SetActive(false);
    }

    public void DamageFX()
    {
        _screenShake.CameraShake(0, 1, 5, 0.2f);
        _blazingSun._source[_blazingSun._musicIndex].pitch = 0;
        _hit = true;
        _particles[8].Play();
        _sounds[4].Play();
    }

    public void PitchVariation()
    {
        if(_hit == true)
        {
            _blazingSun._source[_blazingSun._musicIndex].pitch = Mathf.SmoothDamp(_blazingSun._source[_blazingSun._musicIndex].pitch, 1.1f, ref _velocity, 0.3f);

            if(_blazingSun._source[_blazingSun._musicIndex].pitch >= 1)
            {
                _blazingSun._source[_blazingSun._musicIndex].pitch = 1;
                _hit = false;
            }
        }
    }
}
