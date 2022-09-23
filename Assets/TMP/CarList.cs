using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarList : MonoBehaviour
{   public static CarList instance;
    public List<Car> allCars;
    public List<Car> carsIngame;
    public LvLPoints LvLPoints;
    private int carsIngameCount;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        GlobalEventSystem.OnCarDestroyed += RemoveCarFromList;
        GlobalEventSystem.OnStartLvl += CarsInGameCount;
    }
    private void RemoveCarFromList()
    {
        carsIngameCount--;
        if (carsIngameCount == 0)
        {
            GlobalEventSystem.GameOver();
        }
    }
    private void CarsInGameCount()
    {
        carsIngameCount = carsIngame.Count;
    }
    public void AddCar(int index)
    {
        carsIngame.Add(allCars[index]);
    }
    public void RemoveCar(int index)
    {
        carsIngame.Remove(allCars[index]);
    }
}
