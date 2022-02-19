using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputInRythm : MonoBehaviour
{
    public float BPM;
    public float TimerPressInput;
    public bool CanPress;
    public GameObject PrefabRythmRight;
    public GameObject PrefabRythmLeft;
    public GameObject SpawnRight;
    public GameObject SpawnLeft;
    [SerializeField] private BlazingSun SunRythm;
    [SerializeField] private Animator _animatorMidle;
    public bool OnRytm;
    [SerializeField] private GameObject BarRythm;
    [SerializeField] private GameManager managermultiplicateur;
    private float PlayOnce;
    public float WindowPress;

    

    private void Start() {
        CanPress = false;
        //StartCoroutine("RythmFunction");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        BPMmusic();
        TimerPressInput = 60/BPM;

        if(OnRytm == false)
        {
            BarRythm.SetActive(false);
            StopCoroutine("RythmFunction");
            CanPress = true;
            managermultiplicateur.multiplicateur = 1f;
            PlayOnce = 0;
        }
        else if(OnRytm == true)
        {
            PlayOnce += Time.deltaTime;
            if(PlayOnce < 0.03)
            {
                StartCoroutine("RythmFunction");
            }
            BarRythm.SetActive(true);
        }
    }

    void BPMmusic()
    {
        switch(SunRythm._musicIndex)
        {
            case 0:
            BPM = 96;
            break;

            case 1:
            BPM = 110;
            break;

            case 2:
            BPM = 121;
            break;

            case 3:
            BPM = 108;
            break;
        }
    }

    IEnumerator RythmFunction()
    {
        while(true)
        {
        Instantiate(PrefabRythmRight,SpawnRight.transform.position,SpawnRight.transform.rotation,SpawnRight.transform);
        Instantiate(PrefabRythmLeft,SpawnLeft.transform.position,SpawnLeft.transform.rotation,SpawnLeft.transform);
          CanPress = false;
        yield return new WaitForSeconds(TimerPressInput);
        CanPress = true;
        _animatorMidle.SetBool("Beat",true);
        yield return new WaitForSeconds(0.001f);
        _animatorMidle.SetBool("Beat",false);
        Debug.Log("CanBePress");
        yield return new WaitForSeconds(WindowPress);
        CanPress = false;
        }
    }
}
