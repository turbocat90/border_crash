using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    private int currentCars;
    private int needCars;
    [SerializeField] private Button startButton;
    [SerializeField] private Text carsReady;
    [SerializeField] private Text currentLvl;
    private void Start()
    {
        DisplayCarsReady();
        DisplayCurrentLvl();
    }

    /*public void AddCar(Car car)
    {
        if (carList.carsIngame.Count < needCars)
        {
            for (int i = 0; i < carList.allCars.Count; i++)
            {
                if (carList.allCars[i] == car)
                {
                    carList.carsIngame.Add(carList.allCars[i]);
                    carList.allCars.RemoveAt(i);
                }
            }
            DisplayCarsReady();
        }

    }
    public void RemoveCar(Car car)
    {
            for (int i = 0; i < carList.carsIngame.Count; i++)
            {
                if (carList.carsIngame[i] == car)
                {
                    carList.allCars.Add(carList.carsIngame[i]);
                    carList.carsIngame.RemoveAt(i);
                }
            }
            DisplayCarsReady();
    }*/
    public void DisplayCarsReady()
    {
        currentCars = CarList.instance.carsIngame.Count;
        needCars = CarList.instance.LvLPoints.Lvl[SceneControll.currentLvl].Position.Count;
        carsReady.text = currentCars.ToString() + "/" + needCars.ToString();
        if (needCars == currentCars)
        {
            startButton.gameObject.SetActive(true);
        }
    }
    public void DisplayCurrentLvl()
    {
        currentLvl.text = "LVL " + (SceneControll.currentLvl + 1).ToString();
    }
    public void ClosePanel(GameObject panel)
    {
        panel.gameObject.SetActive(false);
        SaveLoad.instance.Save();
        GlobalEventSystem.RefreshStats();
    }
    public void OpenPanel(GameObject panel)
    {
        panel.gameObject.SetActive(true);
    }
    public void StartGameScene() => SceneControll.instance.StartCurrentScene();
    public void AddCar(int index)
    {
        CarList.instance.AddCar(index);
        DisplayCarsReady();
    }
    public void RemoveCar(int index)
    {
        CarList.instance.RemoveCar(index);
        DisplayCarsReady();
    }
}      
