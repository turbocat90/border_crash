using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraControl : MonoBehaviour
{
    public Car car;
    public CinemachineVirtualCamera virtualCamera;
    private float velocity = 0;
    private void Awake()
    {
        Debug.Log(car.name);
        Debug.Log(virtualCamera.name);
    }
    private void Update()
    {
        float targetFOV = 40 + car.speed * 0.2f;
        virtualCamera.m_Lens.FieldOfView = Mathf.SmoothDamp(virtualCamera.m_Lens.FieldOfView, targetFOV, ref velocity, 1f);
    }
}
