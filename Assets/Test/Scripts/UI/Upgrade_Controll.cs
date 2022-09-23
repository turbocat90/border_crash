using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade_Controll : MonoBehaviour
{
    [SerializeField] private Upgrade_UI upgrade_UI;
    [SerializeField] private List<Car_UI> car_UI;
    [SerializeField] private List<Car> carsInPanel;
    private int currentCars;
    private int maxCars;
    private void Awake()
    {

    }
    private void Start()
    {
        currentCars = 0;
        maxCars = LvLPoints.instance.Lvl[SceneControll.currentLvl].Position.Count;
        upgrade_UI.ChoosedCars(currentCars, maxCars);
        InitialiseCars();
    }
    public void ActivateEvent()
    {
        ActionSystem.OnAddCar += AddCurrentCar;
        ActionSystem.OnRemoveCar += RemoveCurrentCar;
        ActionSystem.OnOpenUpgradePanel += OpenUpgradePanel;
        ActionSystem.OnUpgradeSpeedCar += UpgradeSpeedCar;
        ActionSystem.OnUpgradeArmorCar += UpgradeArmorCar;

    }
    public void DeActivateEvent()
    {
        ActionSystem.OnAddCar -= AddCurrentCar;
        ActionSystem.OnRemoveCar -= RemoveCurrentCar;
        ActionSystem.OnOpenUpgradePanel -= OpenUpgradePanel;
        ActionSystem.OnUpgradeSpeedCar -= UpgradeSpeedCar;
        ActionSystem.OnUpgradeArmorCar -= UpgradeArmorCar;
    }
    private void AddCurrentCar(Car car)
    {
        currentCars++;
        upgrade_UI.ChoosedCars(currentCars, maxCars);
        if(currentCars == maxCars)
        {
            foreach(Car_UI ui in car_UI)
            {
                ui.CanAdd = false;
            }
        }
    }
    private void RemoveCurrentCar(Car car)
    {
        currentCars--;
        upgrade_UI.ChoosedCars(currentCars, maxCars);
        foreach(Car_UI ui in car_UI)
        {
            ui.CanAdd = true;
        }
    }
    private void InitialiseCars()
    {
        for (int i = 0; i < car_UI.Count; i++)
        {
            car_UI[i].Initialise(SceneCars.instance.allCars[i]);
        }
    }
    private void OpenUpgradePanel(Car car) => upgrade_UI.OpenPanel(car, carsInPanel);
    private void UpgradeSpeedCar(Car car)
    {
        for (int i = 0; i < carsInPanel.Count; i++)
        {
            if(carsInPanel[i].ID == car.ID)
                carsInPanel[i].SpeedAndControllUpgrade();
            if (car_UI[i].currentCar.ID == car.ID)
                car_UI[i].UpgradeStats();
        }
        for (int j = 0; j < SceneCars.instance.allCars.Count; j++)
        {
            if (SceneCars.instance.allCars[j].ID == car.ID)
                SceneCars.instance.allCars[j].SpeedAndControllUpgrade();
        }
    }
    private void UpgradeArmorCar(Car car)
    {
        for (int i = 0; i < carsInPanel.Count; i++)
        {
            if (carsInPanel[i].ID == car.ID)
                carsInPanel[i].ArmorAndDamageUpgrade();
            if (car_UI[i].currentCar.ID == car.ID)
                car_UI[i].UpgradeStats();
        }
        for (int j = 0; j < SceneCars.instance.allCars.Count; j++)
        {
            if (SceneCars.instance.allCars[j].ID == car.ID)
                SceneCars.instance.allCars[j].ArmorAndDamageUpgrade();
        }
    }
    public void StartLvl() => ActionSystem.LvlStarting();
    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }
}
