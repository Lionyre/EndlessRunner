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

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine("RythmFunction");
    }
    private void Awake() {
        CanPress = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        TimerPressInput = 60/BPM;
    }

    void BPMmusic()
    {
        switch(SunRythm._musicIndex)
        {
            case 0:
            break;

            case 1:
            break;

            case 2:
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
        yield return new WaitForSeconds(0.2f);
        CanPress = false;
        }
    }
}
