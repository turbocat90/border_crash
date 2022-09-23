using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualUpgrade : MonoBehaviour
{
    [Header("Upgrade")]
    [SerializeField] private List<GameObject> speedGrade;
    [SerializeField] private List<GameObject> armorGrade;
    [Space]
    [Header("Particles")]
    [SerializeField] private List<ParticleSystem> movingParticle;
    [SerializeField] private List<ParticleSystem> deathParticle;
    [SerializeField] private List<ParticleSystem> maxSpeedGradeParticle;

    public void StartMovingParcticle()
    {
        foreach (var item in movingParticle)
        {
            item.Play();
        }
    }
    public void StartDeathParticle()
    {
        foreach (var item in deathParticle)
        {
            item.Play();
        }
    }
    public void StopMovingParticles()
    {
        foreach (var item in movingParticle)
        {
            item.Stop();
        }
    }
    public void ActiveArmorGrade(int currentArmorGrade)
    {
        if (currentArmorGrade % 2 == 0)
        {
            int a = currentArmorGrade / 2 - 1;
            for (int i = 0; i <= a; i++)
            {
                armorGrade[i].SetActive(true);
            }
        }
    }
    public void ActiveSpeedGrade(int currentSpeedGrade)
    {
        if (currentSpeedGrade % 2 == 0)
        {
            int a = currentSpeedGrade / 2 - 1;
            for (int i = 0; i <= a; i++)
            {
                speedGrade[i].SetActive(true);
            }
        }
        if(currentSpeedGrade == 10 && maxSpeedGradeParticle.Count != 0)
        {
            foreach(var item in maxSpeedGradeParticle)
            {
                item.gameObject.SetActive(true);
            }
        }      
    }
}
