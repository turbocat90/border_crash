using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.EventSystems;

public class NewStartCar : MonoBehaviour, IPointerClickHandler
{
    private Car carScript;
    public CinemachineVirtualCamera virtualCamera;
    public ParticleSystem[] particles;
    public ParticleSystem[] particlesDust;
    public void OnPointerClick(PointerEventData eventData)
    {
        StartingCar();
    }
    public void StartingCar()
    {
        //virtualCamera.GetComponent<CameraControl>().enabled = false;
        carScript = GetComponent<Car>();
        virtualCamera.Follow = transform;
        foreach (var particle in particles)
        {
            particle.gameObject.SetActive(true);
        }
        foreach (var particle in particlesDust)
        {
            particle.Play();
        }
        StartCoroutine(carScript.enText());

    }
    private void Start()
    {
        carScript = GetComponent<Car>();
    }
    /*private void Update()
    {
        Vector3 startPoint = new Vector3(transform.position.x, transform.position.y, -159);
        if (goToStart)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPoint, 50f);
        }
    }*/
}
