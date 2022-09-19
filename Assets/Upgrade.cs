using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Upgrade : MonoBehaviour
{
    public List<Car> allcars;
    private Car curentCar;
    private int currentIndexCar = 0;
    [SerializeField] private ParticleSystem upgradetParticle;
    [SerializeField] private List<Animator> animation;
    private void Start()
    {
        foreach (var item in allcars)
        {
            item.gameObject.SetActive(false);
        }
        allcars[0].gameObject.SetActive(true);
        curentCar = allcars[0];
        if (curentCar.currentSpeedGrade == 2)
        {
            animation[0].gameObject.SetActive(false);
        }
        if (curentCar.currentArmorGrade == 2)
        {
            animation[1].gameObject.SetActive(false);
        }
    }
    public void SpeedUpgrade()
    {
        if (curentCar != null)
        {
            curentCar.SpeedGrade();
            upgradetParticle.Play();
            animation[0].SetTrigger("Click");
            if (curentCar.currentSpeedGrade == 2)
            {
                animation[0].gameObject.SetActive(false);
            }
        }   
    }
    public void ArmorUpgrade()
    {
        if (curentCar != null)
        {
            curentCar.ArmorGrade();
            upgradetParticle.Play();
            animation[1].SetTrigger("Click");
            if (curentCar.currentArmorGrade == 2)
            {
                animation[1].gameObject.SetActive(false);
            }
        }

    }
    public void SwitchCar(int index)
    {
        if (index == 0)
        {
            if (currentIndexCar != 0)
            {
                allcars[currentIndexCar].gameObject.SetActive(false);
                currentIndexCar--;
                allcars[currentIndexCar].gameObject.SetActive(true);
                curentCar = allcars[currentIndexCar];
                if (curentCar.currentArmorGrade < 2)
                    animation[1].gameObject.SetActive(true);
                else
                    animation[1].gameObject.SetActive(false);
                if (curentCar.currentSpeedGrade < 2)
                    animation[0].gameObject.SetActive(true);
                else
                    animation[0].gameObject.SetActive(false);
            }
        }
        if (index == 1)
        {
            if (currentIndexCar != allcars.Count - 1)
            {
                allcars[currentIndexCar].gameObject.SetActive(false);
                currentIndexCar++;
                allcars[currentIndexCar].gameObject.SetActive(true);
                curentCar = allcars[currentIndexCar];
                if (curentCar.currentArmorGrade < 2)
                    animation[1].gameObject.SetActive(true);
                else
                    animation[1].gameObject.SetActive(false);
                if (curentCar.currentSpeedGrade < 2)
                    animation[0].gameObject.SetActive(true);
                else
                    animation[0].gameObject.SetActive(false);
            }
        }
    }
}
