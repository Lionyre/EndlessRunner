using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Playables;

public class CharacterRenderer : MonoBehaviour
{
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private CinemachineVirtualCamera[] _cinemachineCameras;
    public PlayableDirector _playbleDirector;
    public GameObject _canvas, _rythmBar;

    // private void Start() 
    // {
    //     StartRunning();
    // }

    public void StartRunning()
    {
        _playerAnimator.SetBool("_run", true);
        _playbleDirector.Play();
        _canvas.SetActive(true);
        _rythmBar.SetActive(true);
    }

    public void SetJumpBool(bool isJumping)
    {
        _playerAnimator.SetBool("_jump", isJumping);
    }

    public void SetSlideBool(bool isSliding)
    {
        _playerAnimator.SetBool("_slide", isSliding);
    }
}
