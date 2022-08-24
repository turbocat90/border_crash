using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.EventSystems;

public class StartCar : MonoBehaviour, IPointerClickHandler
{
    public GameObject car;
    public Car carScript;
    public CinemachineVirtualCamera virtualCamera;
    public ParticleSystem[] particles;
    private bool isStarting;
    private float velocity = 0f;
    public void OnPointerClick (PointerEventData eventData)
    {
        StartingCar();
    }
    public void StartingCar()
    {
        carScript = GetComponent<Car>();
        car.gameObject.SetActive(true);
        virtualCamera.Follow = car.transform;
        gameObject.SetActive(false);
        foreach (var particle in particles)
        {
            particle.gameObject.SetActive(true);
        }
        isStarting = true;
    }
    /*private void Update()
    {
        if (isStarting)
        {
            float targetFOV = 40 + carScript.speed * 0.2f;
            virtualCamera.m_Lens.FieldOfView = Mathf.SmoothDamp(virtualCamera.m_Lens.FieldOfView, targetFOV, ref velocity, 1f);
        }
        /*if (carScript.isCarDestroyed)
        {
            //Debug.Log(carScript.isCarDestroyed);
            //carScript.isCarDestroyed = false;
            virtualCamera.Follow = startPoint;
        }
        
    }*/
}
