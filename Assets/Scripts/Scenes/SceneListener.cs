using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneListener : MonoBehaviour
{
    [SerializeField] private GameObject canvasCompleteLvl;
    [SerializeField] private GameObject canvasGameOver;
    private int maxCars;
    private void Start()
    {
        ActivateEvent();
        maxCars = LvLPoints.instance.Lvl[SceneControll.currentLvl].Position.Count;
    }
    public void ActivateEvent()
    {
        ActionSystem.OnCarDestroyed += CarDestroyed;
        ActionSystem.OnCarFinished += LvlComplete;
        SceneControll.instance.ActivateEvent();
    }
    public void DeActivateEvent()
    {
        ActionSystem.OnCarDestroyed -= CarDestroyed;
        ActionSystem.OnCarFinished -= LvlComplete;
        SceneControll.instance.DeActivateEvent();
    }
    private void CarDestroyed()
    {
        maxCars--;
        if (maxCars == 0)
        {
            DeActivateEvent();
            canvasGameOver.SetActive(true);
        }
        else
            CameraController.StartPreviewCamera();
    }
    private void LvlComplete()
    {
        DeActivateEvent();
        canvasCompleteLvl.SetActive(true);
    }
    public void StartGarageScene()
    {
        SceneControll.instance.StartGarageScene();
    }
}
