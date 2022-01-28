using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject _player;
    private float _velocity = 0;
    public bool _isOnPlayer;

    void Update()
    {
        transform.position = Vector3.MoveTowards(gameObject.transform.position, _player.transform.position, 0.14f);

        if(gameObject.transform.position == _player.transform.position)
        {
            _isOnPlayer = true;
        }
        else
        {
            _isOnPlayer = false;
        }
    }
}
