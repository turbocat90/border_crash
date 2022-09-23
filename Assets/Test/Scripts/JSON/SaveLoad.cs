using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SaveLoad : MonoBehaviour
{
    public static SaveLoad instance;
    [HideInInspector]
    public List<Saver> saver = new List<Saver>();
    private const string SAVE_PATH = "ListCar";
    public List<Car> cars;
    private void Awake()
    {
        instance = this;
        Load();
        if (saver.Count < 1)
            Save();
    }
    public void Save()
    {
        saver.Clear();
        for (int i = 0; i < cars.Count; i++)
        {
            saver.Add(new Saver(cars[i]));
        }
        FileHandler.SaveToJSON<Saver>(saver, SAVE_PATH);
    }
    private void Load()
    {
        saver = FileHandler.ReadListFromJSON<Saver>(SAVE_PATH);
        foreach (var car in cars)
        {
            //car.Initialize();
        }
    }
    public void Clear()
    {
        saver.Clear();
        Load();
    }
}
[Serializable]
public class Saver
{
    public int carID;
    public int damageGrade;
    public int speedGrade;
    public int hpGrade;
    public int controllGrade;
    public Saver(Car car)
    {
        /*this.carID = car.id;
        this.damageGrade = car.currentDamageGrade;
        this.speedGrade = car.currentSpeedGrade;
        this.hpGrade = car.currentArmorGrade;
        this.controllGrade = car.currentcontrollGrade;*/
    }
}
