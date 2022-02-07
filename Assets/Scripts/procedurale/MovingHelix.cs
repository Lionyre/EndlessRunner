using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingHelix : MonoBehaviour
{
    public float speed;
    public bool isMovingLeft = true;
    
    void Start()
    {
        
    }

    
    private void FixedUpdate() 
    {
        if (isMovingLeft == true)
        {
            gameObject.transform.position -= new Vector3(speed, 0, 0);
            if(gameObject.transform.position.x < -5)
            {
                isMovingLeft = false;
            }
            
            
        }
        if( isMovingLeft == false)
        {
                gameObject.transform.position += new Vector3(speed, 0, 0);
                if(gameObject.transform.position.x > 5)
                {
                    isMovingLeft = true;
                }
        }
    }


}
