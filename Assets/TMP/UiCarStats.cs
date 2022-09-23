using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UiCarStats : MonoBehaviour
{
   /* [SerializeField] private Car currentCar;
    [SerializeField] private Text name;
    [SerializeField] private Text speed;
    [SerializeField] private Text damage;
    [SerializeField] private Text controll;
    [SerializeField] private Text armor;
    private void Start()
    {
        DisplayCarStats();
        GlobalEventSystem.OnRefreshStats += DisplayCarStats;
    }
    public void DisplayCarStats()
    {
        speed.text = currentCar.maxSpeed.ToString() + " m/h";
        damage.text = currentCar.damage.ToString() + " kg";
        controll.text = currentCar.controll.ToString();
        armor.text = currentCar.armor.ToString();
        name.text = currentCar.name;
    }
    public void DamageGrade()
    {
        if (currentCar.currentDamageGrade < 20)
        {
            currentCar.damage += 100;
            currentCar.currentDamageGrade++;
            DisplayCarStats();
        }
    }
    public void SpeedGrade()
    {
        if (currentCar.currentSpeedGrade < 20)
        {
            currentCar.speed += currentCar.speed * 0.05f;
            currentCar.speedBoost += currentCar.speedBoost * 0.05f;
            currentCar.maxSpeed += 5;
            currentCar.currentSpeedGrade++;
            DisplayCarStats();
        }
    }
    public void ArmorGrade()
    {
        if (currentCar.currentArmorGrade < 20)
        {
            currentCar.armor += 100;
            currentCar.currentArmorGrade++;
            DisplayCarStats();
        }
    }
    public void ControllGrade()
    {
        if (currentCar.currentcontrollGrade < 20)
        {
            currentCar.rotateAngle += 1;
            currentCar.rotateSpeed += 0.5f;
            currentCar.controll += 5;
            currentCar.currentcontrollGrade++;
            DisplayCarStats();
        }
    }
    private void OnDestroy()
    {
        GlobalEventSystem.OnRefreshStats -= DisplayCarStats;
    }*/
}
