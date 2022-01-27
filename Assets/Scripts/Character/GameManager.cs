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
    private float BeforeReload = 5f;


    // Update is called once per frame
    void Update()
    {
        PlayerIsDead();
    }

    void PlayerIsDead()
    {
        if(BoolSliding.IsSliding == true)
        {
            ContactFromCharacter = ColliderSlide.GetComponent<ContactObstacle>();
        }
        else if(BoolSliding.IsSliding == false)
        {
            ContactFromCharacter = Collider.GetComponent<ContactObstacle>();
        }

        if(ContactFromCharacter.IsDead == false)
        {
            Vitesse += Time.fixedDeltaTime * 0.01f;
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
}
