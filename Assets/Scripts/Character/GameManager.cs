using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float Score;
    public float Vitesse;
    [SerializeField] private Text ScorePlayer;

    // Update is called once per frame
    void Update()
    {
        Vitesse += Time.fixedDeltaTime * 0.1f;;
        ScorePlayer.text = Score.ToString("000000");
    }
}
