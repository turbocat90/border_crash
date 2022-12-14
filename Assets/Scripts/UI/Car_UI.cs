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
    [SerializeField] private GameObject choosePanel;
    public bool CanAdd { get; set; } = true;
    public Car currentCar { get; set; }

    public void Initialise(Car car)
    {
        car_name.text = car.CarName;
        car_speed.text = ((int)car.currentMaxSpeed).ToString() + " m/h";
        car_control.text = ((int)car.currentRotateAngle).ToString() + "?";
        car_armor.text = ((int)car.currentArmor).ToString();
        car_damage.text = ((int)car.currentMass).ToString() + " kg";
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
        choosePanel.SetActive(false);
    }
    public void UpgradeStats()
    {
        car_speed.text = ((int)currentCar.currentMaxSpeed).ToString() + " m/h";
        car_control.text = ((int)currentCar.currentRotateAngle).ToString() + "?";
        car_armor.text = ((int)currentCar.currentArmor).ToString();
        car_damage.text = ((int)currentCar.currentMass).ToString() + " kg";
    }
}
