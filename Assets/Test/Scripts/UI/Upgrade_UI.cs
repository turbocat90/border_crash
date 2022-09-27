using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade_UI : MonoBehaviour
{
    [Header("Upgrade Panel")]
    [SerializeField] private GameObject upgradePanel;
    [SerializeField] private Text currency; //валюта
    [SerializeField] private Text carName;
    [SerializeField] private Text speedValue;
    [SerializeField] private Text speedUpgradePrice;
    [SerializeField] private Text armorValue;
    [SerializeField] private Text armorUpgradePrice;
    [Space]
    [Header("Choose Panel")]
    [SerializeField] private Text choosedCars;
    [SerializeField] GameObject startLvl_btn;
    private Car currentCar;
    public void OpenPanel(Car car, List<Car> carsInPanel)
    {
        currentCar = car;
        upgradePanel.SetActive(true);
        // currency.text = ценник
        carName.text = car.CarName;
        speedValue.text = car.currentMaxSpeed.ToString();
        // speedUpgradePrice.text = цена апгрейда
        armorValue.text = car.currentArmor.ToString();
        // armorUpgradePrice.text = цена апгрейда
        foreach (var item in carsInPanel)
        {
            item.gameObject.SetActive(false);
        }

        foreach (Car item in carsInPanel)
        {
            if (item.ID == car.ID)
            {
                item.gameObject.SetActive(true);
                for (int i = 0; i < car.currentSpeedAndControllGrade; i++)
                {
                    item.SpeedAndControllUpgrade();
                }
                for (int i = 0; i < car.currentArmorAndHpGrade; i++)
                {
                    item.ArmorAndDamageUpgrade();
                }
                return;

            }    
        }
      
    }
    public void ChoosedCars(int currentCars, int maxCars)
    {
        choosedCars.text = currentCars.ToString() + "/" + maxCars.ToString();
        if (currentCars == maxCars)
            startLvl_btn.SetActive(true);
        else
            startLvl_btn.SetActive(false);
    }
    public void UpgradeSpeedCar()
    {
        if (currentCar != null)
        {
            ActionSystem.OnUpgradeSpeedCar(currentCar);
            UpgradeStats();
        }
    }
    public void UpgradeArmorCar()
    {
        if (currentCar != null)
        {
            ActionSystem.OnUpgradeArmorCar(currentCar);
            UpgradeStats();
        }
    }
    private void UpgradeStats()
    {
        // currency.text = ценник
        carName.text = currentCar.CarName;
        speedValue.text = currentCar.currentMaxSpeed.ToString();
        // speedUpgradePrice.text = цена апгрейда
        armorValue.text = currentCar.currentArmor.ToString();
        // armorUpgradePrice.text = цена апгрейда
    }

}
