using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScrollingText : MonoBehaviour
{
    public TextMeshProUGUI _tmpComponent;
    private RectTransform _textRectTransform;
    private string sourceText;
    private BlazingSun _blazingSun;

    private void Awake() 
    {
        _blazingSun = GameObject.Find("Prefab_BlazingSun").GetComponent<BlazingSun>();
        _textRectTransform = _tmpComponent.GetComponent<RectTransform>();
    }

    private void Update() 
    {
        sourceText = "Music : " + _blazingSun._source[_blazingSun._musicIndex].gameObject.name;
        _tmpComponent.SetText(sourceText);
    }
}
