using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastScript : MonoBehaviour
{
    
    private Vector3 DistanceLigne;
    private GameObject LastHit;
    public LayerMask layer;
    public bool TouchingGround;
    public float LongueurRaycast;
    

    // Update is called once per frame
    void Update()
    {
        var ray = new Ray((this.transform.position + new Vector3(0,-0.80f,0)), -transform.up);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit,LongueurRaycast))
        {
            LastHit = hit.transform.gameObject;
            DistanceLigne = hit.point;
            TouchingGround = true;
        }
        else
        {
            TouchingGround = false;
        }    
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, DistanceLigne);
    }
}
