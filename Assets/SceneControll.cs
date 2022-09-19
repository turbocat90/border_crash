using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControll : MonoBehaviour
{
    public static SceneControll instance;
    public static int currentLvl = 1;
    public CarList carList;
    
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    private void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        GlobalEventSystem.OnCompleteLvl += ChangeScene;
        GlobalEventSystem.OnGameOver += StartGarageScene;
    }
    public void ChangeScene()
    {
        currentLvl++;
        StartGarageScene();
    }
    public void StartCurrentScene()
    {
        SceneManager.LoadScene(currentLvl + 1);
        for (int i = 0; i < carList.LvLPoints.Lvl[currentLvl].Position.Count; i++)
        {
            carList.carsIngame[i].transform.position = carList.LvLPoints.Lvl[currentLvl].Position[i];
        }
        GlobalEventSystem.StartLvl();
    }
    public void StartGarageScene()
    {
        carList.carsIngame.Clear();
        SceneManager.LoadScene(0);
    }
    private void OnDestroy()
    {
        GlobalEventSystem.OnCompleteLvl -= ChangeScene;
        GlobalEventSystem.OnGameOver -= StartGarageScene;
    }
}
