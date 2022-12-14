using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControll : MonoBehaviour
{
    public static SceneControll instance;
    public static int currentLvl;
    
    private void Awake()
    {
        DontDestroyOnLoad(this);
        if (PlayerPrefs.HasKey("Lvl"))
            currentLvl = PlayerPrefs.GetInt("Lvl");
        else
            currentLvl = 0;
        Debug.Log("lvl =" + currentLvl);
    }
    private void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    public void ActivateEvent()
    {
        ActionSystem.OnLvlStarting += StartCurrentScene;
        ActionSystem.OnCarFinished += ChangeScene;
    }
    public void DeActivateEvent()
    {
        ActionSystem.OnLvlStarting -= StartCurrentScene;
        ActionSystem.OnCarFinished -= ChangeScene;
    }
    public void ChangeScene()
    {
        currentLvl++;
        SaveLoad.instance.Save();
    }
    public void StartCurrentScene()
    {
        SaveLoad.instance.Save();
        SceneManager.LoadScene(currentLvl + 2);
        EventControll.instance.DeactivateEvent();
        for (int i = 0; i < LvLPoints.instance.Lvl[currentLvl].Position.Count; i++)
        {
            SceneCars.instance.carsInGame[i].transform.position = LvLPoints.instance.Lvl[currentLvl].Position[i];
        }
    }
    public void StartMapScene()
    {
        SaveLoad.instance.Save();
        foreach (var item in SceneCars.instance.allCars)
        {
            item.StopCar();
            item.gameObject.SetActive(true);
            item.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            item.gameObject.transform.position = new Vector3(0, -100, 0);
        }
        SceneCars.instance.carsInGame.Clear();
        SceneManager.LoadScene(0);
    }
    public void StartGarageScene()
    {
        SaveLoad.instance.Save();
        foreach (var item in SceneCars.instance.allCars)
        {
            item.StopCar();
            item.gameObject.SetActive(true);
            item.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            item.gameObject.transform.position = new Vector3(0, -100, 0);
        }
        SceneCars.instance.carsInGame.Clear();
        SceneManager.LoadScene(1);
    }
}
