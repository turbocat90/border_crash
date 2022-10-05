using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneListener : MonoBehaviour
{
    [SerializeField] private GameObject canvasCompleteLvl;
    [SerializeField] private GameObject canvasGameOver;
    [SerializeField] private Text completeLvlParts;
    [SerializeField] private Text completeLvlCanister;
    [SerializeField] private Text gameOverParts;
    private int maxCars;
    private int lvlParts;
    private int lvlCanister;
    private void Start()
    {
        ActivateEvent();
        maxCars = LvLPoints.instance.Lvl[SceneControll.currentLvl].Position.Count;
        lvlCanister = maxCars + 5;
        Initialise();
    }
    public void ActivateEvent()
    {
        ActionSystem.OnCarDestroyed += CarDestroyed;
        ActionSystem.OnCarFinished += LvlComplete;
        SceneControll.instance.ActivateEvent();
        ActionSystem.OnAddParts += AddParts;
    }
    public void DeActivateEvent()
    {
        ActionSystem.OnCarDestroyed -= CarDestroyed;
        ActionSystem.OnCarFinished -= LvlComplete;
        SceneControll.instance.DeActivateEvent();
        ActionSystem.OnAddParts -= AddParts;

    }
    private void CarDestroyed()
    {
        maxCars--;
        lvlCanister--;
        if (maxCars == 0)
        {
            canvasGameOver.SetActive(true);
            UpgradeLvlParts();
            Currency.AddParts(lvlParts);
            DeActivateEvent();
        }
        else
            CameraController.StartPreviewCamera();
    }
    private void LvlComplete()
    {
        canvasCompleteLvl.SetActive(true);
        UpgradeLvlParts();
        Currency.AddParts(lvlParts);
        Currency.AddCanister(lvlCanister);
        DeActivateEvent();
    }
    public void StartGarageScene()
    {
        SceneControll.instance.StartGarageScene();
    }
    public void StartMapScene()
    {
        SceneControll.instance.StartMapScene();
    }
    public void AddParts(int value)
    {
        lvlParts += value;
    }
    private void UpgradeLvlParts()
    {
        completeLvlParts.text = lvlParts.ToString();
        completeLvlCanister.text = lvlCanister.ToString();
        gameOverParts.text = lvlParts.ToString();

    }
    private void Initialise()
    {
        completeLvlParts.text = lvlParts.ToString();
        completeLvlCanister.text = lvlCanister.ToString();
        gameOverParts.text = lvlParts.ToString();
    }
}
