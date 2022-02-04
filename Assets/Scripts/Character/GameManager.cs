using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float Score;
    public float Vitesse;
    [SerializeField] private Text ScorePlayer;
    private ContactObstacle ContactFromCharacter;
    [SerializeField] private CharacterInput BoolSliding;
    [SerializeField] private GameObject Collider;
    [SerializeField] private GameObject ColliderSlide;
    [SerializeField] private generationProcedurale StopGeneration;
    private float BeforeReload = 1f;
    private FrontRaycast TouchingObject;
    private bool TouchTheObject;
    private GameObject BlazingSun;


    private void Start() {
        BlazingSun = GameObject.Find("Prefab_BlazingSun");
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerIsDead();
        MoreScore();
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
                Scene scene = SceneManager.GetActiveScene(); 
                SceneManager.LoadScene(scene.name);
            }
        }
        ScorePlayer.text = Score.ToString("000000");
    }


    void MoreScore()
    {
        if(TouchTheObject == true)
        {
            Score += 1;
        }
    }

    void VitesseSelonBPM()
    {
        switch(BlazingSun.GetComponent<BlazingSun>()._musicIndex)
        {
            case 0:
            
            break;


            case 1:

            break;


            case 2:

            break;
        }
    }
}
