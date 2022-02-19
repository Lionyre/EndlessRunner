using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickSound : MonoBehaviour
{
    public UnityEngine.Events.UnityEvent clickTrigger;

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            clickTrigger.Invoke();
        }
    }
}
