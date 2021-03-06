using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private GameObject TheScore;
    private float vitessePiece;
    private GameObject ProceduraleStopPiece;
    private CharacterFX _characterFX;

    private void Awake() {
        InstantieLaPiece();
        ProceduraleStopPiece = GameObject.Find("PointSpawn");
        _characterFX = GameObject.Find("Character").GetComponentInChildren<CharacterFX>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        vitessePiece = TheScore.GetComponent<GameManager>().Vitesse;
        MouvementPiece();
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Player")
        {
            TheScore.GetComponent<GameManager>().Score += 15 * TheScore.GetComponent<GameManager>().multiplicateur;
            _characterFX.CoinFX();
            Destroy(this.gameObject);
        }
        else if(other.gameObject.tag == "Obstacle" || other.gameObject.tag == "Danger")
        {
            ProceduraleStopPiece.GetComponent<generationProcedurale>().coinCanBePlace = 1;
            Destroy(this.gameObject);
        }
        else if(other.gameObject.tag == "DestroyCoin")
        {
            Destroy(this.gameObject);
        }
    }

    void MouvementPiece()
    {
        transform.Rotate(new Vector3(0,0,100) * Time.fixedDeltaTime);
        transform.position -= new Vector3(0,0,vitessePiece * Time.fixedDeltaTime);
    }

    void InstantieLaPiece()
    {
        TheScore = GameObject.Find("GameManager");
        vitessePiece = TheScore.GetComponent<GameManager>().Vitesse;
    }
}
