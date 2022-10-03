using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SaveLoad : MonoBehaviour
{
    public static SaveLoad instance;
    private List<CarSaver> car_save = new List<CarSaver>();
    private const string SAVE_PATH_CAR = "carSave";
    private LevelSaver lvl_save;
    private const string SAVE_PATH_LVL = "lvlSave";


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(this);
        Load();
    }
    public void Save()
    {
        // save car
        car_save.Clear();
        for (int i = 0; i < SceneCars.instance.allCars.Count; i++)
        {
            car_save.Add(new CarSaver(SceneCars.instance.allCars[i]));
        }
        FileHandler.SaveToJSON<CarSaver>(car_save, SAVE_PATH_CAR);

        // save lvl
        lvl_save = new LevelSaver(SceneControll.currentLvl);
        FileHandler.SaveToJSON<LevelSaver>(lvl_save, SAVE_PATH_LVL);

        // save currency
        Currency.SaveCanister();
        Currency.SaveParts();
    }
    private void Load()
    {
        car_save = FileHandler.ReadListFromJSON<CarSaver>(SAVE_PATH_CAR);
        lvl_save = FileHandler.ReadFromJSON<LevelSaver>(SAVE_PATH_LVL);

        // загрузка грейдов
        if (car_save != null)
        {
            for (int i = 0; i < car_save.Count; i++)
            {
                if (car_save[i].carID == SceneCars.instance.allCars[i].ID)
                {
                    SceneCars.instance.allCars[i].currentSpeedAndControllGrade = car_save[i].speedGrade;
                    SceneCars.instance.allCars[i].currentArmorAndHpGrade = car_save[i].armorGrade;
                }
            }
        }

        // загрузка лвл
        if (lvl_save != null)
            SceneControll.currentLvl = lvl_save.currentLvl;


    }

    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
            Save();
    }

#if UNITY_EDITOR
    private void OnApplicationQuit()
    {
        Save();
    }
#endif
}
[Serializable]
public class CarSaver
{
    public int carID;
    public int speedGrade;
    public int armorGrade;

    public CarSaver(Car car)
    {
        this.carID = car.ID;
        this.speedGrade = car.currentSpeedAndControllGrade;
        this.armorGrade = car.currentArmorAndHpGrade;

    }
}
[Serializable]
public class LevelSaver
{
    public int currentLvl;
    public LevelSaver(int currentLvl) => this.currentLvl = currentLvl;
}



