using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlStats : MonoBehaviour
{
    private int currentStartingChoise = 0;
    public GameObject[] startingChoise;
    public GameObject[] cars;
    public void AddCarToStart(int indexCar)
    {
        if (currentStartingChoise < startingChoise.Length)
        {
            startingChoise[currentStartingChoise].transform.GetChild(indexCar).gameObject.SetActive(true);
            currentStartingChoise++;
            cars[indexCar].SetActive(false);
        }
    }
    public void GO()
    {
        gameObject.SetActive(false);
    }
}
