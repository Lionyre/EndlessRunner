using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInput : MonoBehaviour
{
    private float TimerSaut;
    [SerializeField] private float TempsDuSaut;
    private bool Jump;
    [SerializeField] private float PuissanceChute;

    private float TempsSlider;
    [SerializeField] private float TempsDuSlide;
    private bool Slide;
    
    public GameObject ColliderCharacter;
    public GameObject ColliderSlide;
    public GameObject CharacterMesh;

    [SerializeField] private RaycastScript _Raycastscript;
    public bool IsSliding;
    private float TimerDéplacement;
    [SerializeField] private float CooldownDeplacement;
    [SerializeField] private CharacterFX _characterFX = null;

    private void Start() 
    {
        _characterFX = GetComponentInChildren<CharacterFX>();
    }

    void Update()
    {
        TimerSaut -= Time.deltaTime;
        TempsSlider -= Time.deltaTime;
        TimerDéplacement -= Time.deltaTime;
        if(TempsSlider <= 0)
        {
            TempsSlider = 0f;
        }

        if(TimerSaut<= 0)
        {
            TimerSaut = 0f;
        }
        if(TimerDéplacement <= 0)
        {
            TimerDéplacement = 0f;
        }
        MovementCharacter();
        JumpCharacter();
        SlideCharacter();
    }

    void MovementCharacter()
    {  
        if(Input.GetKeyDown(KeyCode.Q) && transform.position.x >= -3 && TimerDéplacement <= 0)
        {
            _characterFX.DashFX();
            transform.position += new Vector3(-4,0,0);
            TimerDéplacement = CooldownDeplacement;
        }
        if(Input.GetKeyDown(KeyCode.D) && transform.position.x <= 3 && TimerDéplacement <= 0)
        {
            _characterFX.DashFX();
            transform.position += new Vector3(4,0,0);
            TimerDéplacement = CooldownDeplacement;
        }

    }

    void JumpCharacter()
    {
        if(Input.GetKeyDown(KeyCode.Space) && TimerSaut <= 0 && IsSliding == false)
        {
            Jump = true;
            _characterFX.JumpFX();
        }
        else
        {
            Jump = false;
            _characterFX.JumpAnim(false);
        }

        if(Jump == true && _Raycastscript.TouchingGround == true)
        {
            TimerSaut = TempsDuSaut;
        }

        if(TimerSaut > 0f)
        {
            _characterFX.JumpAnim(true);
            transform.position = new Vector3(gameObject.transform.position.x,4,gameObject.transform.position.z);
        }
        else if(TimerSaut <= 0)
        {
            _characterFX.JumpAnim(false);
            // TP perso
            // transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
        if(_Raycastscript.TouchingGround == false)
        {
            if(IsSliding == true)
            {
                _characterFX.JumpAnim(false);
                transform.position -= new Vector3(0,PuissanceChute * 1.7f,0);
            }
            else if(IsSliding == false)
            {
                transform.position -= new Vector3(0,PuissanceChute,0);
            }
        }
        // else
        // {
            //perso reste à 0 si besoin
        //     transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        // }
    }

    void SlideCharacter()
    {
        if(Input.GetKeyDown(KeyCode.S) && TempsSlider <= 0 && TimerDéplacement <= 0)
        {
            Slide = true;
            TimerDéplacement = CooldownDeplacement;
            _characterFX.SlidAnim(true);
        }
        else if(Input.GetKeyUp(KeyCode.Space) && _Raycastscript.TouchingGround == true && TimerDéplacement <= 0)
        {
            Slide = false;
            TempsSlider = 0f;
            TimerSaut = TempsDuSaut;
            TimerDéplacement = CooldownDeplacement;
            _characterFX.JumpFX();
            _characterFX.JumpAnim(true);
        }
        else
        {
            Slide = false;
        }

        if(Slide == true)
        {
            _characterFX.SlideFX();
            TempsSlider = TempsDuSlide;
        }

        if(TempsSlider > 0f)
        {
            IsSliding = true;
            TimerSaut = 0f;
            ColliderCharacter.SetActive(false);
            ColliderSlide.SetActive(true);
            // CharacterMesh.transform.localScale = new Vector3(1,0.5f,1); 
        }
        else if(TempsSlider <= 0)
        {
            IsSliding = false;
            ColliderSlide.SetActive(false);
            ColliderCharacter.SetActive(true);
            _characterFX.SlidAnim(false);
            // CharacterMesh.transform.localScale = new Vector3(1,1,1); 
        }
    }

}
