using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ActionSystem
{
    public static Action<Car> OnOpenUpgradePanel;
    public static Action<Car> OnAddCar;
    public static Action<Car> OnRemoveCar;
    public static Action OnCarDestroyed;
    public static Action<Car> OnUpgradeSpeedCar;
    public static Action<Car> OnUpgradeArmorCar;
    public static Action OnLvlStarting;
    public static Action OnCarFinished;
    public static Action OnAddCanister;
    public static Action <int> OnAddParts;



    public static void OpenUpgradePanel(Car car) => OnOpenUpgradePanel?.Invoke(car);
    public static void AddCar(Car car) => OnAddCar?.Invoke(car);
    public static void RemoveCar(Car car) => OnRemoveCar?.Invoke(car);
    public static void CarDestroyed() => OnCarDestroyed?.Invoke();
    public static void UpgradeSpeedCar(Car car) => OnUpgradeSpeedCar?.Invoke(car);
    public static void UpgradeArmorCar(Car car) => OnUpgradeArmorCar?.Invoke(car);
    public static void LvlStarting() => OnLvlStarting?.Invoke();
    public static void CarFinished() => OnCarFinished?.Invoke();
    public static void AddCanister() => OnAddCanister?.Invoke();  
    public static void AddParts(int value) => OnAddParts?.Invoke(value);  
}
