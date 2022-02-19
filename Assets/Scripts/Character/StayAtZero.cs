using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayAtZero : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y < 0.1580001f)
        {
            gameObject.transform.position = new Vector3(transform.position.x, 0.1580001f, transform.position.z);
        }
    }
}
