using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFX : MonoBehaviour
{
    [SerializeField] private ScreenShake _screenShake;
    [SerializeField] private ParticleSystem[] _particles;
    [SerializeField] private CharacterRenderer _characterRenderer;

    private void Start() 
    {
        _screenShake = GameObject.Find("ScreenShake").GetComponent<ScreenShake>();
        _particles = GetComponentsInChildren<ParticleSystem>();
        _characterRenderer = GameObject.Find("Player-Renderer").GetComponent<CharacterRenderer>();
    }

    public void DashFX()
    {
        _particles[0].Play();
        _particles[1].Play();
        _screenShake.CameraShake(0, 1, 4, 0.2f);
    }

    public void JumpFX()
    {
        _particles[0].Play();
        _particles[1].Play();
        _particles[2].Play();
        _screenShake.CameraShake(0, 1, 4, 0.2f);
    }

    public void JumpAnim(bool isJumping)
    {
        _characterRenderer.SetJumpBool(isJumping);
    }

    public void SlideFX()
    {
        _particles[0].Play();
        _particles[1].Play();
        _particles[3].Play();
        _particles[4].Play();
        _screenShake.CameraShake(0, 1, 1, 0.6f);
    }

    public void SlidAnim(bool isSliding)
    {
        _characterRenderer.SetSlideBool(isSliding);
    }
}
