using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSelecter : MonoBehaviour
{
    public static CarSelecter instance;
    private bool isSelecting = false;
    [SerializeField] private Camera followCamera;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    private void Update()
    {
        if (isSelecting)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = followCamera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    if(hit.collider.TryGetComponent(out Car car))
                    {
                        CameraController.FollowCar(car);
                        car.StartCar();
                    }
                }
            }
        }
    }
    public void SetActive(bool isActive) => isSelecting = isActive;
        
}
