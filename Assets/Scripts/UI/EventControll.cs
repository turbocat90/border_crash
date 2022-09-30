using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventControll : MonoBehaviour
{
    public static EventControll instance;
    public Upgrade_Controll upgrade_Controll;
    public ChooseCar_UI choose_Car;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    private void Start()
    {
        upgrade_Controll.ActivateEvent();
        SceneCars.instance.ActivateEvent();
        SceneControll.instance.ActivateEvent();
        choose_Car.ActivateEvent();
    }
    public void DeactivateEvent()
    {
        upgrade_Controll.DeActivateEvent();
        SceneCars.instance.DeActivateEvent();
        SceneControll.instance.DeActivateEvent();
        choose_Car.DeActivateEvent();
    }
}
