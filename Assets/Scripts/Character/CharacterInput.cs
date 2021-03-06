using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInput : MonoBehaviour
{
    public float TimerSaut;
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
    [SerializeField] private CharacterFX _characterFX = null;
    [SerializeField] private InputInRythm RythmPress;
    [SerializeField] private GameManager managerscore;

    private void Start() 
    {
        _characterFX = GetComponentInChildren<CharacterFX>();
    }

    void Update()
    {
        TimerSaut -= Time.deltaTime;
        TempsSlider -= Time.deltaTime;
        if(TempsSlider <= 0)
        {
            TempsSlider = 0f;
        }

        if(TimerSaut<= 0)
        {
            TimerSaut = 0f;
        }
        MovementCharacter();
        JumpCharacter();
        SlideCharacter();
        MultiplicationScore();
    }

    void MovementCharacter()
    {  
        if(Input.GetKeyDown(KeyCode.Q) && transform.position.x >= -3 && RythmPress.CanPress == true)
        {
            _characterFX.DashFX();
            transform.position += new Vector3(-4,0,0);
        }
        if(Input.GetKeyDown(KeyCode.D) && transform.position.x <= 3 && RythmPress.CanPress == true)
        {
            _characterFX.DashFX();
            transform.position += new Vector3(4,0,0);
        }

    }

    void JumpCharacter()
    {
        if(Input.GetKeyDown(KeyCode.Space) && TimerSaut <= 0 && IsSliding == false && RythmPress.CanPress == true)
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
            ColliderCharacter.GetComponent<CapsuleCollider>().direction = 2;
        }
        else if(TimerSaut <= 0)
        {
            _characterFX.JumpAnim(false);
            ColliderCharacter.GetComponent<CapsuleCollider>().direction = 1;
            // TP perso
            // transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
        if(_Raycastscript.TouchingGround == false)
        {
            if(transform.position.y <= -0.06f)
            {
                transform.position = new Vector3(transform.position.x, -0.04f, transform.position.z);
                Debug.Log("EstEnDesous");
            }
            else
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
        }
        // else
        // {
            //perso reste ?? 0 si besoin
        //     transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        // }
    }

    void SlideCharacter()
    {
        if(Input.GetKeyDown(KeyCode.S) && TempsSlider <= 0 && RythmPress.CanPress == true)
        {
            Slide = true;
            _characterFX.SlidAnim(true);
        }
        else if(Input.GetKeyUp(KeyCode.Space) && _Raycastscript.TouchingGround == true && RythmPress.CanPress == true)
        {
            Slide = false;
            TempsSlider = 0f;
            TimerSaut = TempsDuSaut;
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

    void MultiplicationScore()
    {
        if(RythmPress.CanPress == true && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)))
        {
            managerscore.multiplicateur += 0.1f;
        }
        else if(RythmPress.CanPress == false && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)))
        {
            managerscore.multiplicateur = 1f;
        }
    }

}
