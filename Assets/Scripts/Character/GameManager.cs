using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float Score;
    public float Vitesse;
    [SerializeField] private Text ScorePlayer;
    public Animator scoreAnimator;
    private ContactObstacle ContactFromCharacter;
    [SerializeField] private CharacterInput BoolSliding;
    [SerializeField] private GameObject Collider;
    [SerializeField] private GameObject ColliderSlide;
    [SerializeField] private generationProcedurale StopGeneration;
    private float BeforeReload = 1f;
    private FrontRaycast TouchingObject;
    private bool TouchTheObject;
    private GameObject BlazingSun;
    public float multiplicateur;
    [SerializeField] private TMP_Text MultiplicateurText;


    private void Start() {
        BlazingSun = GameObject.Find("Prefab_BlazingSun");
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerIsDead();
        MoreScore();
        ShowMultiplicateur();
        VitesseSelonBPM();
        if(multiplicateur >= 4)
        {
            multiplicateur = 4;
        }
    }
    

    void PlayerIsDead()
    {
        if(BoolSliding.IsSliding == true)
        {
            ContactFromCharacter = ColliderSlide.GetComponent<ContactObstacle>();
            TouchTheObject = false;
        }
        else if(BoolSliding.IsSliding == false)
        {
            ContactFromCharacter = Collider.GetComponent<ContactObstacle>();
            TouchingObject = Collider.GetComponent<FrontRaycast>();
            TouchTheObject = TouchingObject.ColideWithObject;
        }

        if(ContactFromCharacter.IsDead == false)
        {
            //Vitesse += Time.fixedDeltaTime * 0.5f;
        }
        else if(ContactFromCharacter.IsDead == true)
        {
            BeforeReload -= Time.fixedDeltaTime;
            Vitesse = 0;
            StopGeneration.enabled = false;
            BoolSliding.enabled = false;
            if(BeforeReload <= 0)
            {
                ReloadScene();
            }
        }
        ScorePlayer.text = Score.ToString("000000");
    }

    void ShowMultiplicateur()
    {
        MultiplicateurText.text = multiplicateur.ToString("x0.0");
    }

    public void ReloadScene()
    {
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
    }


    void MoreScore()
    {
        if(TouchTheObject == true)
        {
            scoreAnimator.SetTrigger("bump");
            Score += 1 * multiplicateur;
        }
    }

    void VitesseSelonBPM()
    {
        switch(BlazingSun.GetComponent<BlazingSun>()._musicIndex)
        {
            case 0:
                if(Vitesse < 9)
                {
                    Vitesse += Time.deltaTime / 2;
                }
                else if(Vitesse > 11)
                {
                    Vitesse -= Time.deltaTime / 2;
                }
                else
                {
                    Vitesse = 10;
                }

            break;


            case 1:

            if(Vitesse < 24)
                {
                    Vitesse += Time.deltaTime / 2;
                }
                else if(Vitesse > 26)
                {
                    Vitesse -= Time.deltaTime / 2;
                }
                else
                {
                    Vitesse = 25;
                }

            break;


            case 2:

            if(Vitesse < 34)
                {
                    Vitesse += Time.deltaTime / 2;
                }
                else if(Vitesse > 36)
                {
                    Vitesse -= Time.deltaTime / 2;
                }
                else
                {
                    Vitesse = 35;
                }

            break;

            case 3:

            if(Vitesse < 19)
                {
                    Vitesse += Time.deltaTime / 2;
                }
                else if(Vitesse > 21)
                {
                    Vitesse -= Time.deltaTime / 2;
                }
                else
                {
                    Vitesse = 20;
                }

            break;
        }
    }
}
