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
    public GameObject _canvas, _rythmBar, _echo;
    public bool pause, gameIsRunning;
    public GameObject _pauseCanvas;

    private void Start() 
    {
        Time.timeScale = 0;   
        gameIsRunning = false;
    }

    private void Update() 
    {
        PauseGame();
    }

    public void StartRunning()
    {
        _playerAnimator.SetBool("_run", true);
        _playbleDirector.Play();
        _canvas.SetActive(true);
        _rythmBar.SetActive(true);
        _echo.SetActive(true);
        gameIsRunning = true;
        Time.timeScale = 1;
    }

    public void PauseGame()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && gameIsRunning == true)
        {
            if(pause == false)
            {
                pause = true;
                _pauseCanvas.SetActive(true);
                Time.timeScale = 0;
                _playerAnimator.SetBool("_run", false);
            }
            else
            {
                pause = false;
                _pauseCanvas.SetActive(false);
                _playerAnimator.SetBool("_run", true);
                Time.timeScale = 1;
            }
        }
    }

    public void StopPause()
    {
        pause = false;
        _pauseCanvas.SetActive(false);
        _playerAnimator.SetBool("_run", true);
        Time.timeScale = 1;
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
