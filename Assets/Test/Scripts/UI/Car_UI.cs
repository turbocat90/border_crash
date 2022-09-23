using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Car_UI : MonoBehaviour
{
    [SerializeField] private Text car_name;
    [SerializeField] private Text car_speed;
    [SerializeField] private Text car_control;
    [SerializeField] private Text car_armor;
    [SerializeField] private Text car_damage;
    [SerializeField] private GameObject choosed_btn;
    public bool CanAdd { get; set; } = true;
    public Car currentCar { get; set; }

    public void Initialise(Car car)
    {
        car_name.text = car.CarName;
        car_speed.text = car.currentMaxSpeed.ToString();
        car_control.text = car.currentControll.ToString();
        car_armor.text = car.currentArmor.ToString();
        car_damage.text = car.currentMass.ToString();
        currentCar = car;
    }
    public void AddCar()
    {
        if (CanAdd)
        {
            ActionSystem.AddCar(currentCar);
            choosed_btn.SetActive(true);
        }
    }
    public void RemoveCar()
    {
        ActionSystem.RemoveCar(currentCar);
        choosed_btn.SetActive(false);
    }
    public void Upgrade()
    {
        ActionSystem.OpenUpgradePanel(currentCar);
    }
    public void UpgradeStats()
    {
        car_speed.text = currentCar.currentMaxSpeed.ToString();
        car_control.text = currentCar.currentControll.ToString();
        car_armor.text = currentCar.currentArmor.ToString();
        car_damage.text = currentCar.currentMass.ToString();
    }
}
