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
        TimerPressInput = BPM /60;
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
        Debug.Log("CanBePress");
        yield return new WaitForSeconds(0.4f);
        CanPress = false;
        }
    }
}
