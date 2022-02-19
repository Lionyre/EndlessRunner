using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SwitchRythm : MonoBehaviour
{
    public InputInRythm _rythm;
    private bool _isActive = false;
    public TextMeshProUGUI _text;

    public void switchRythm()
    {
        if(_isActive == false)
        {
            _isActive = true;
            _rythm.OnRytm = true;
            _text.color = new Color(1, 1, 1, 1);
        }
        else
        {
            _isActive = false;
            _rythm.OnRytm = false;
            _text.color = new Color(0, 0, 0, 1);
        }
    }
}
