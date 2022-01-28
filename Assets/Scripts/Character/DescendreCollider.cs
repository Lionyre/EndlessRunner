using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescendreCollider : MonoBehaviour
{
    [SerializeField] private RaycastScript scriptDuRaycast;
    [SerializeField] private CharacterInput LeSaut;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(scriptDuRaycast.TouchingGround == false && LeSaut.TimerSaut <= 0)
        {
            this.gameObject.transform.position -= new Vector3(0,0.1f,0);
        }
    }
}
