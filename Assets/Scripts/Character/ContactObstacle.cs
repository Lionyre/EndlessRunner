using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactObstacle : MonoBehaviour
{
    public bool IsDead;
    private float Vie = 3;

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Danger")
        {
            IsDead = true;
        }
        else if(other.gameObject.tag == "Obstacle")
        {
            Vie -= 1;
        }
    }

    private void Update() {
        LaVie();
    }
    void LaVie()
    {
        if(Vie <= 0)
        {
            IsDead = true;
        }
    }


}
