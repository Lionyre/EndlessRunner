using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRenderer : MonoBehaviour
{
    [SerializeField] private Animator _playerAnimator;
    private float xValue;

    private void Update() 
    {
        StartRunning();
    }

    public void StartRunning()
    {
        if(xValue < 1)
        {
            xValue += Time.deltaTime;

            if(xValue >= 1)
            {
                xValue = 1;
            }

            _playerAnimator.SetFloat("x", xValue);
        }    
    }

    public void SetJumpBool(bool isJumping)
    {
        _playerAnimator.SetBool("_jump", isJumping);
    }

    public void SetSlideTrigger()
    {
        _playerAnimator.SetTrigger("_slide");
    }
}
