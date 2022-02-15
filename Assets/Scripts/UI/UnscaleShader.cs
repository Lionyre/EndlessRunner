using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnscaleShader : MonoBehaviour
{
    public Material _shaderMaterial;

    void Update()
    {
        _shaderMaterial.SetFloat("unscaleTime", Time.unscaledTime);
    }
}
