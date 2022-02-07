using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBarRight : MonoBehaviour
{
    private float DeplacementBar;
    private InputInRythm Rythm;
    private GameObject Themanager;
    private float FacteurDeplacement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake() {
        Themanager = GameObject.Find("GameManager");
        Rythm = Themanager.GetComponent<InputInRythm>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DeplacementBar = 1.35f/(Rythm.TimerPressInput*(1.0f / Time.fixedDeltaTime));
        FacteurDeplacement = Rythm.TimerPressInput;
        transform.position -= new Vector3(DeplacementBar,0,0);
        if(Rythm.CanPress == true)
        {
            Destroy(this.gameObject);
        }
    }

    
}
