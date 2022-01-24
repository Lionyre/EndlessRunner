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

    // Update is called once per frame
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
    }

    void MovementCharacter()
    {  
        if(Input.GetKeyDown(KeyCode.Q) && transform.position.x >= -3)
        {
            transform.position += new Vector3(-4,0,0);
        }
        if(Input.GetKeyDown(KeyCode.D) && transform.position.x <= 3)
        {
            transform.position += new Vector3(4,0,0);
        }

    }

    void JumpCharacter()
    {
        if(Input.GetKeyDown(KeyCode.Space) && TimerSaut <= 0)
        {
            Jump = true;
        }
        else
        {
            Jump = false;
        }

        if(Jump == true && _Raycastscript.TouchingGround == true)
        {
            TimerSaut = TempsDuSaut;
        }

        if(TimerSaut > 0f)
        {
            transform.position = new Vector3(gameObject.transform.position.x,4,gameObject.transform.position.z);
        }
        else if(TimerSaut <= 0)
        {
            // TP perso
            // transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
        if(_Raycastscript.TouchingGround == false)
        {
            transform.position -= new Vector3(0,PuissanceChute,0);
        }
        // else
        // {
            //perso reste à 0 si besoin
        //     transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        // }
    }

    void SlideCharacter()
    {
        if(Input.GetKeyDown(KeyCode.S) && TempsSlider <= 0)
        {
            Slide = true;
        }
        else
        {
            Slide = false;
        }

        if(Slide == true)
        {
            TempsSlider = TempsDuSlide;
        }

        if(TempsSlider > 0f)
        {
            ColliderCharacter.SetActive(false);
            ColliderSlide.SetActive(true);
            CharacterMesh.transform.localScale = new Vector3(1,0.5f,1); 
        }
        else if(TempsSlider <= 0)
        {
            ColliderSlide.SetActive(false);
            ColliderCharacter.SetActive(true);
            CharacterMesh.transform.localScale = new Vector3(1,1,1); 
        }
    }

}
