using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoEffect : MonoBehaviour
{
    [SerializeField] private float _timeBetweenSpawns;
    [SerializeField] private float _startTime;
    [SerializeField] private GameObject _objectToRepeat;
    [SerializeField] private FollowPlayer _followPlayer;
    [SerializeField] private GameObject _stockage;

    private void Update() 
    {
        if(_timeBetweenSpawns <= 0 && _followPlayer._isOnPlayer == false)
        {
            Instantiate(_objectToRepeat, transform.position, Quaternion.identity, _stockage.transform);
            _timeBetweenSpawns = _startTime;
        }

        else
        {
            _timeBetweenSpawns -= Time.deltaTime;
        }
    }
}
