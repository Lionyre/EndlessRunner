using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontRaycast : MonoBehaviour
{
     private Vector3 DistanceLigne;
    private GameObject LastHit;
    public LayerMask layer;
    public bool ColideWithObject;
    

    // Update is called once per frame
    void Update()
    {
        var ray = new Ray((this.transform.position + new Vector3(0,1,0)), transform.forward);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit,10f) && gameObject.GetComponent<ContactObstacle>().IsDead == false)
        {
            
            LastHit = hit.transform.gameObject;
            DistanceLigne = hit.point;
            ColideWithObject = true;
        }
        else
        {
            ColideWithObject = false;
        }    
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, DistanceLigne);
    }

}
