using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade_UI : MonoBehaviour
{
    [Header("Upgrade Panel")]
    [SerializeField] private GameObject upgradePanel;
    [SerializeField] private Text currency; //трыўђр
    [SerializeField] private Text carName;
    [SerializeField] private Text speedValue;
    [SerializeField] private Text controlValue;
    [SerializeField] private Text speedUpgradePrice;
    [SerializeField] private Text armorValue;
    [SerializeField] private Text damageValue;
    [SerializeField] private Text armorUpgradePrice;
    [Space]
    [Header("Choose Panel")]
    [SerializeField] private Text choosedCars;
    [SerializeField] GameObject startLvl_btn;
    [Space]
    [SerializeField] private List<int> upgradePrice;
    [Space]
    [Header("Upgrade Particles")]
    [SerializeField] private List<ParticleSystem> upgradeParticle;
    public Car currentCar;
    public void OpenPanel(Car car, List<Car> carsInPanel)
    {
        upgradePanel.SetActive(true);
        currency.text = Currency.Parts.ToString();
        carName.text = car.CarName;
        speedValue.text = car.currentMaxSpeed.ToString() + " m/h";
        controlValue.text = car.currentRotateAngle.ToString() + "А";
        speedUpgradePrice.text = (car.CarMultiplier * upgradePrice[car.currentSpeedAndControllGrade]).ToString();
        armorUpgradePrice.text = (car.CarMultiplier * upgradePrice[car.currentArmorAndHpGrade]).ToString();
        armorValue.text = car.currentArmor.ToString();
        damageValue.text = car.currentMass.ToString();
        foreach (var item in carsInPanel)
        {
            item.gameObject.SetActive(false);
        }

        foreach (Car item in carsInPanel)
        {
            if (item.ID == car.ID)
            {
                currentCar = item;
                item.gameObject.SetActive(true);
                for (int i = item.currentSpeedAndControllGrade; i < car.currentSpeedAndControllGrade; i++)
                {
                    item.SpeedAndControllUpgrade();
                }
                for (int i = item.currentArmorAndHpGrade; i < car.currentArmorAndHpGrade; i++)
                {
                    item.ArmorAndDamageUpgrade();
                }
                item.GetVisualUpgrade().PlayParticlesInGame(item.typeCar, item.currentSpeedAndControllGrade);
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
        if (currentCar != null && currentCar.currentSpeedAndControllGrade < currentCar.maxSpeedAndControllGrade && Currency.Parts >= currentCar.CarMultiplier * upgradePrice[currentCar.currentSpeedAndControllGrade])
        {
            Currency.SpendParts(currentCar.CarMultiplier * upgradePrice[currentCar.currentSpeedAndControllGrade]);
            Currency.SaveParts();
            ActionSystem.OnUpgradeSpeedCar(currentCar);
            UpgradeStats();
            StartParticles();
            currentCar.GetVisualUpgrade().PlayParticlesInGame(currentCar.typeCar, currentCar.currentSpeedAndControllGrade);
        }
    }
    public void UpgradeArmorCar()
    {
        if (currentCar != null && currentCar.currentArmorAndHpGrade < currentCar.maxArmorAndHpGrade && Currency.Parts >= currentCar.CarMultiplier * upgradePrice[currentCar.currentArmorAndHpGrade])
        {
            Currency.SpendParts(currentCar.CarMultiplier * upgradePrice[currentCar.currentSpeedAndControllGrade]);
            Currency.SaveParts();
            ActionSystem.OnUpgradeArmorCar(currentCar);
            UpgradeStats();
            StartParticles();
        }
    }
    private void UpgradeStats()
    {
        currency.text = Currency.Parts.ToString();
        speedValue.text = currentCar.currentMaxSpeed.ToString() + " m/h";
        controlValue.text = currentCar.currentRotateAngle.ToString() + "А";
        speedUpgradePrice.text = (currentCar.CarMultiplier * upgradePrice[currentCar.currentSpeedAndControllGrade]).ToString();
        armorValue.text = currentCar.currentArmor.ToString();
        damageValue.text = currentCar.currentMass.ToString();
        armorUpgradePrice.text = (currentCar.CarMultiplier * upgradePrice[currentCar.currentArmorAndHpGrade]).ToString();
    }
    private void StartParticles()
    {
        foreach (var item in upgradeParticle)
        {
            item.Play();
        }
    }
}
