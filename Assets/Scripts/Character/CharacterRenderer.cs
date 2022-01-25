using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRenderer : MonoBehaviour
{
    [SerializeField] private Animator _playerAnimator;

    // private void Start() 
    // {
    //     StartRunning();
    // }

    public void StartRunning()
    {
        _playerAnimator.SetBool("_run", true);
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
