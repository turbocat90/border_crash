using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneCars : MonoBehaviour
{
    public static SceneCars instance;
    public List<Car> allCars = new List<Car>();
    public List<Car> carsInGame = new List<Car>();

    private void Awake()
    {
        DontDestroyOnLoad(this);
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    public void ActivateEvent()
    {
        ActionSystem.OnAddCar += AddCar;
        ActionSystem.OnRemoveCar += RemoveCar;
    }
    public void DeActivateEvent()
    {
        ActionSystem.OnAddCar -= AddCar;
        ActionSystem.OnRemoveCar -= RemoveCar;
    }
    private void AddCar(Car car)
    {
        for (int i = 0; i < allCars.Count; i++)
        {
            if(allCars[i].ID == car.ID)
            {
                carsInGame.Add(allCars[i]);
                return;
            }
        }
    }
    private void RemoveCar(Car car)
    {
        for (int i = 0; i < carsInGame.Count; i++)
        {
            if(carsInGame[i].ID == car.ID)
            {
                carsInGame.RemoveAt(i);
                return;
            }
        }
    }
}
