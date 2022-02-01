using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingRoad : MonoBehaviour
{
    private GameObject LeGameManager;
    private float VitesseDeplacement;

    private void Awake() {
        LeGameManager = GameObject.Find("GameManager");
        VitesseDeplacement = LeGameManager.GetComponent<GameManager>().Vitesse;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        VitesseDeplacement = LeGameManager.GetComponent<GameManager>().Vitesse;
        MouvementRoute();
    }

    void MouvementRoute()
    {
        transform.position -= new Vector3(0,0,VitesseDeplacement * Time.fixedDeltaTime);
    }
}
