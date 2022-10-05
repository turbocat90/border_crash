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
    [SerializeField] private Button speedButton;
    [SerializeField] private Button armorButton;

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
        speedValue.text = ((int)car.currentMaxSpeed).ToString() + " m/h";
        controlValue.text = ((int)car.currentRotateAngle).ToString() + "А";        
        armorValue.text = ((int)car.currentArmor).ToString();
        damageValue.text = ((int)car.currentMass).ToString();
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
            }
        }
        if (currentCar.currentArmorAndHpGrade == currentCar.maxArmorAndHpGrade)
        {
            armorUpgradePrice.text = "MAX";
            armorButton.enabled = false;
        }
        else
        {
            armorButton.enabled = true;
            armorUpgradePrice.text = (car.CarMultiplier * upgradePrice[car.currentArmorAndHpGrade]).ToString();

        }
        if (currentCar.currentSpeedAndControllGrade == currentCar.maxSpeedAndControllGrade)
        {
            speedUpgradePrice.text = "MAX";
            speedButton.enabled = false;

        }
        else
        {
            speedButton.enabled = true;
            speedUpgradePrice.text = (car.CarMultiplier * upgradePrice[car.currentSpeedAndControllGrade]).ToString();

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
        if (currentCar != null && currentCar.currentSpeedAndControllGrade < currentCar.maxSpeedAndControllGrade && Currency.Parts >= currentCar.CarMultiplier * upgradePrice[currentCar.currentSpeedAndControllGrade] && Currency.Parts - currentCar.CarMultiplier * upgradePrice[currentCar.currentSpeedAndControllGrade] >= 0)
        {
            Currency.SpendParts(currentCar.CarMultiplier * upgradePrice[currentCar.currentSpeedAndControllGrade]);
            Currency.SaveParts();
            ActionSystem.OnUpgradeSpeedCar(currentCar);
            UpgradeStats();
            StartParticles();
            currentCar.GetVisualUpgrade().PlayParticlesInGame(currentCar.typeCar, currentCar.currentSpeedAndControllGrade);
        }
        if (currentCar != null && currentCar.currentSpeedAndControllGrade == currentCar.maxSpeedAndControllGrade)
        {
            speedUpgradePrice.text = "MAX";
            speedButton.enabled = false;
            Currency.SaveParts();
        }
    }
    public void UpgradeArmorCar()
    {
        if (currentCar != null && currentCar.currentArmorAndHpGrade < currentCar.maxArmorAndHpGrade && Currency.Parts >= currentCar.CarMultiplier * upgradePrice[currentCar.currentArmorAndHpGrade] && Currency.Parts - currentCar.CarMultiplier * upgradePrice[currentCar.currentArmorAndHpGrade] >= 0)
        {
            Currency.SpendParts(currentCar.CarMultiplier * upgradePrice[currentCar.currentArmorAndHpGrade]);
            Currency.SaveParts();
            ActionSystem.OnUpgradeArmorCar(currentCar);
            UpgradeStats();
            StartParticles();
        }
        if (currentCar != null && currentCar.currentArmorAndHpGrade == currentCar.maxArmorAndHpGrade)
        {
            armorUpgradePrice.text = "MAX";
            armorButton.enabled = false;
            Currency.SaveParts();
        }
    }
    private void UpgradeStats()
    {
        currency.text = Currency.Parts.ToString();
        speedValue.text = ((int)currentCar.currentMaxSpeed).ToString() + " m/h";
        controlValue.text = ((int)currentCar.currentRotateAngle).ToString() + "А";
        armorValue.text = ((int)currentCar.currentArmor).ToString();
        damageValue.text = ((int)currentCar.currentMass).ToString();
        if(currentCar != null && currentCar.currentSpeedAndControllGrade == currentCar.maxSpeedAndControllGrade)
            speedUpgradePrice.text = "MAX";
        else
            speedUpgradePrice.text = (currentCar.CarMultiplier * upgradePrice[currentCar.currentSpeedAndControllGrade]).ToString();
        if (currentCar != null && currentCar.currentArmorAndHpGrade == currentCar.maxArmorAndHpGrade)
            armorUpgradePrice.text = "MAX";
        else
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
