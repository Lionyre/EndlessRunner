using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlazingSun : MonoBehaviour
{
    private const int _samplSize = 1024;
    private float _rmsValue;
    private float _dbValue;
    private float _pitchValue;
    [SerializeField] private float _maxScaleValue = 25f;
    [SerializeField] private float _radius;
    [SerializeField, Range(0.1f, 1f)] private float _percentage = 0.5f;
    [SerializeField, Range(100, 2000)] private float _visualModifier = 1000f;
    [SerializeField, Range(1, 100)] private float _smoothSpeed = 10f;
    [SerializeField] private int _amnVisual = 64;
    [SerializeField] private GameObject _blazingSunPrefab;
    private AudioSource[] _source;
    private float[] _samples;
    private float[] _spectrum;
    private float _sampleRate;
    private Transform[] _visualList;
    private float[] _visualScale;
    public int _musicIndex;
    

    private void Start() 
    {
        _source = GetComponentsInChildren<AudioSource>();
        _samples = new float[_samplSize];
        _spectrum = new float[_samplSize];
        _sampleRate = AudioSettings.outputSampleRate;
        // SpawnLine();
        SpawnCircle();
        _source[_musicIndex].enabled = true;
    }

    private void Update() 
    {
        AnalyzeSound(_musicIndex);
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        int visualIndex = 0;
        int spectrumIndex = 0;
        int averageSize = (int) ((_samplSize * _percentage) / _amnVisual);

        while(visualIndex < _amnVisual)
        {
            int j = 0;
            float sum = 0;

            while(j < averageSize)
            {
                sum += _spectrum[spectrumIndex];
                spectrumIndex++;
                j++;
            }

            float scaleY = sum / averageSize * _visualModifier;
            _visualScale[visualIndex] -= Time.deltaTime * _smoothSpeed;

            if(_visualScale[visualIndex] < scaleY)
            {
                _visualScale[visualIndex] = scaleY;
            }

            if(_visualScale[visualIndex] > _maxScaleValue)
            {
                _visualScale[visualIndex] = _maxScaleValue;
            }

            _visualList[visualIndex].localScale = Vector3.one + Vector3.up * _visualScale[visualIndex];
            visualIndex++;
        }
    }
    private void SpawnCircle()
    {
        _visualScale = new float[_amnVisual];
        _visualList = new Transform[_amnVisual];

        Vector3 center = Vector3.zero;
        float radius = _radius;

        for(int i = 0; i < _amnVisual; i++)
        {
            float ang = i * 1.0f / _amnVisual;
            ang = ang * Mathf.PI * 2;

            float x = center.x + Mathf.Cos(ang) * radius;
            float y = center.y + Mathf.Sin(ang) * radius;

            Vector3 pos = center + new Vector3(x, y, gameObject.transform.position.z);
            GameObject sunObject = Instantiate(_blazingSunPrefab, gameObject.transform) as GameObject;
            sunObject.transform.position = pos;
            sunObject.transform.rotation = Quaternion.LookRotation(Vector3.forward, pos);
            _visualList[i] = sunObject.transform;
        }
    }
    private void SpawnLine()
    {
        _visualScale = new float[_amnVisual];
        _visualList = new Transform[_amnVisual];

        for(int i = 0; i < _amnVisual; i++)
        {
            GameObject sunObject = GameObject.CreatePrimitive(PrimitiveType.Cube) as GameObject;
            _visualList[i] = sunObject.transform;
            _visualList[i].position = Vector3.right * i;
        }
    }
    private void AnalyzeSound(int musicIndex)
    {
        _source[musicIndex].GetOutputData(_samples, 0);

        
        float sum = 0;

        for(int i = 0; i < _samplSize; i++)
        {
            sum = _samples[i] * _samples[i];
        }

        _rmsValue = Mathf.Sqrt(sum / _samplSize);

        _dbValue = 20 * Mathf.Log10(_rmsValue / 0.1f);

        _source[musicIndex].GetSpectrumData(_spectrum, 0, FFTWindow.BlackmanHarris);
    }
}
