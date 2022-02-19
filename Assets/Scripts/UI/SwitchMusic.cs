using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMusic : MonoBehaviour
{
    public BlazingSun _blazingSun;

    public void NextMusic()
    {
        if(_blazingSun._musicIndex < _blazingSun._source.Length - 1)
        {
            _blazingSun._musicIndex++;
            _blazingSun._source[_blazingSun._musicIndex - 1].enabled = false;
            _blazingSun._source[_blazingSun._musicIndex].enabled = true;
        }  
    }

    public void PreviousMusic()
    {
        if(_blazingSun._musicIndex > 0)
        {
            _blazingSun._musicIndex--;
            _blazingSun._source[_blazingSun._musicIndex + 1].enabled = false;
            _blazingSun._source[_blazingSun._musicIndex].enabled = true;
        }  
    }
}
