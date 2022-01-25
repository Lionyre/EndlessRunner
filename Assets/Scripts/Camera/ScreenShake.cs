using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ScreenShake : MonoBehaviour
{
    [Header ("ScreenShake")]
    public List<CinemachineVirtualCamera> _cam;
    public float _shakeTimer;
    private int cameraIndex;

    void Update()
    {
        if(_shakeTimer > 0f)
        {
            _shakeTimer -= Time.deltaTime;

            if(_shakeTimer <= 0f)
            {
                CinemachineBasicMultiChannelPerlin CinemachineBasicMultiChannelPerlin = _cam[GetCameraIndex()].GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                CinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;
            }
        }
    }

    public void SetCameraIndex(int index)
    {
        cameraIndex = index;
    }

    public int GetCameraIndex()
    {
        return cameraIndex;
    }

    public void CameraShake(int cameraIndex, float frequency, float amplitude, float time)
    {
        SetCameraIndex(cameraIndex);
        CinemachineBasicMultiChannelPerlin CinemachineBasicMultiChannelPerlin = _cam[cameraIndex].GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        CinemachineBasicMultiChannelPerlin.m_AmplitudeGain = amplitude;
        CinemachineBasicMultiChannelPerlin.m_FrequencyGain = frequency;
        _shakeTimer = time;
    }
}
