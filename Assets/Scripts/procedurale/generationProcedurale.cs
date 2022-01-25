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

    private void Awake() {
        ManagerVitesse = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        TimerSpawnRoad -= Time.deltaTime;
        TimerSpawn -= Time.deltaTime;
        SpawnRoad();
        SpawnObstacles();
    }

    void SpawnRoad()
    {
        if(TimerSpawnRoad <= 0)
        {
            TimerSpawn = 0.001f;
            LeSpawn = Random.Range(0,3);
            ChoixDispositionSpawn = Random.Range(1,3);
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
                Instantiate(_ObjectForSpawn[Random.Range(0,2)], _Spawn[Random.Range(0,3)]);
            }
            break;
            case 1:
            if(TimerSpawn > 0)
            {
                switch(ChoixDispositionSpawn)
                {
                    case 1:
                    Instantiate(_ObjectForSpawn[Random.Range(0,2)], _Spawn[0]);
                    Instantiate(_ObjectForSpawn[Random.Range(0,2)], _Spawn[2]);
                    break;
                    case 2:
                    Instantiate(_ObjectForSpawn[Random.Range(0,2)], _Spawn[1]);
                    Instantiate(_ObjectForSpawn[Random.Range(0,2)], _Spawn[2]);
                    break;
                    case 3:
                    Instantiate(_ObjectForSpawn[Random.Range(0,2)], _Spawn[0]);
                    Instantiate(_ObjectForSpawn[Random.Range(0,2)], _Spawn[1]);
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
}
