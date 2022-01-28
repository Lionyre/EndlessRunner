using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshPosition : MonoBehaviour
{
    [SerializeField] private CharacterInput BoolSliding;
    private GameObject Collider;
    private GameObject ColliderSlide;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(BoolSliding.IsSliding == true)
        {
            ColliderSlide = GameObject.Find("ColliderSlide");
            transform.position = ColliderSlide.transform.position - new Vector3(0,1.04f,0);
        }
        else if(BoolSliding.IsSliding == false)
        {
            Collider = GameObject.Find("Collider");
            transform.position = Collider.transform.position - new Vector3(0,1.04f,0);
        }
    }
}
