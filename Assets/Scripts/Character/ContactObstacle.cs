using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactObstacle : MonoBehaviour
{
    public bool IsDead;
    public CharacterFX _characterFX;
    private float Vie = 3;

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Danger")
        {
            IsDead = true;
            _characterFX.DeathFX();
        }
        else if(other.gameObject.tag == "Obstacle")
        {
            Vie -= 1;
            _characterFX.DamageFX();
        }
    }

    private void FixedUpdate() {
        LaVie();
    }
    void LaVie()
    {
        if(Vie <= 0)
        {
            IsDead = true;
            _characterFX.DeathFX();
        }
    }


}
