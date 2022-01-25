using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generationProcedurale : MonoBehaviour
{
    public float TimerSpawnRoad;
    [SerializeField] private float TimerSpawnRoute;
    public GameObject PrefabRoad;
    public GameObject PointSpawn;
    private GameObject ManagerVitesse;
    public List<Transform> _Spawn = new List<Transform>();
    public List<GameObject> _ObjectForSpawn = new List<GameObject>();
    public int LeSpawn;
    public int LesObjects;
    private float TimerSpawn;
    private int ChoixDispositionSpawn;
    private int ChoixRandomA;
    private int ChoixRandomB;
    private bool DangerA;
    private bool ObstacleA;
    private bool DangerB;
    private bool ObstacleB;
    public GameObject Coin;
    public int coinCanBePlace;
    private float SpawnPiece;
    private int EmplacementPiece;

    private void Awake() {
        ManagerVitesse = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        TimerSpawnRoad -= Time.deltaTime;
        TimerSpawn -= Time.deltaTime;
        SpawnPiece -= Time.deltaTime;
        SpawnRoad();
        SpawnObstacles();
        SpawnCoins();
    }

    void SpawnRoad()
    {
        if(TimerSpawnRoad <= 0)
        {
            coinCanBePlace = Random.Range(0,2);
            EmplacementPiece = Random.Range(0,3);
            TimerSpawn = 0.001f;
            SpawnPiece = 0.001f;
            LeSpawn = Random.Range(0,3);
            ChoixDispositionSpawn = Random.Range(1,3);
            ChoixRandomA = Random.Range(0,2);
            ChoixRandomB = Random.Range(0,2);
            LesObjects = Random.Range(0,2);
            Instantiate(PrefabRoad, PointSpawn.transform);
            TimerSpawnRoad = TimerSpawnRoute / ManagerVitesse.GetComponent<GameManager>().Vitesse;
        }
    }


    void SpawnObstacles()
    {

        switch(LeSpawn)
        {
            case 0:
            if(TimerSpawn > 0)
            {
                RegleSpawn();
            }
            break;
            case 1:
            if(TimerSpawn > 0)
            {
                switch(ChoixDispositionSpawn)
                {
                    case 1:
                    Instantiate(_ObjectForSpawn[ChoixRandomA], _Spawn[0]);
                    Instantiate(_ObjectForSpawn[ChoixRandomB], _Spawn[2]);
                    SwitchEtat();
                    break;
                    case 2:
                    Instantiate(_ObjectForSpawn[ChoixRandomA], _Spawn[1]);
                    Instantiate(_ObjectForSpawn[ChoixRandomB], _Spawn[2]);
                    SwitchEtat();
                    break;
                    case 3:
                    Instantiate(_ObjectForSpawn[ChoixRandomA], _Spawn[0]);
                    Instantiate(_ObjectForSpawn[ChoixRandomB], _Spawn[1]);
                    SwitchEtat();
                    break;
                }
            }
            break;
            case 2:
            if(TimerSpawn > 0)
            {
                
            }
            break;
        }

    }

    void SwitchEtat()
    {
        switch(ChoixRandomA)
                    {
                        case 0:
                        ObstacleA = false;
                        DangerA = false;
                        break;
                        case 1:
                        ObstacleA = true;
                        DangerA = false;
                        break;
                        case 2:
                        DangerA = true;
                        ObstacleA = false;
                        break;
                    }
                    switch(ChoixRandomB)
                    {
                        case 0:
                        ObstacleB = false;
                        DangerB = false;
                        break;
                        case 1:
                        ObstacleB = true;
                        DangerB = false;
                        break;
                        case 2:
                        ObstacleB = false;
                        DangerB = true;
                        break;
                    }
    }

    void RegleSpawn()
    {
        if(ObstacleA == true || DangerA == true)
        {
            if(_Spawn[2] && _Spawn[0])
            {
                Instantiate(_ObjectForSpawn[LesObjects], _Spawn[2]);
            }
            else if(_Spawn[1] && _Spawn[2])
            {
                Instantiate(_ObjectForSpawn[LesObjects], _Spawn[1]);
            }
            else if(_Spawn[1] && _Spawn[0])
            {
                Instantiate(_ObjectForSpawn[LesObjects], _Spawn[0]);
            }
        }
    }

    void SpawnCoins()
    {
        if(TimerSpawnRoad <= 0)
        {
            // Debug.Log("Est à 0");
            // coinCanBePlace = Random.Range(0,1);
            // EmplacementPiece = Random.Range(0,2);
        }
        switch(coinCanBePlace)
            {
                case 1:
                    if(SpawnPiece > 0)
                    {
                   StartCoroutine("CoroutineDePiece");
                    }
                break;
                case 0:

                break;
            }
    }

    IEnumerator CoroutineDePiece()
    {
        yield return new WaitForSeconds(0.2f);
        Instantiate(Coin,_Spawn[EmplacementPiece]);
        yield return new WaitForSeconds(0.2f);
        Instantiate(Coin,_Spawn[EmplacementPiece]);
        yield return new WaitForSeconds(0.2f);
        Instantiate(Coin,_Spawn[EmplacementPiece]);
        yield return new WaitForSeconds(0.2f);
        Instantiate(Coin,_Spawn[EmplacementPiece]);
    }
}
