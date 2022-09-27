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
    [SerializeField] private List<ParticleSystem> speedGradeParticle;
    [SerializeField] private int speedGradeToStartParticle = 0;

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
        if (currentArmorGrade <= 5)
        {
            for (int i = 0; i < currentArmorGrade; i++)
            {
                armorGrade[i].SetActive(true);
            }
        }
    }
    public void ActiveSpeedGrade(int currentSpeedGrade)
    {
        if (currentSpeedGrade <= 5)
        {
            for (int i = 0; i < currentSpeedGrade; i++)
            {
                speedGrade[i].SetActive(true);
            }
        }     
    }
    public void StartSpeedGradeParticle(int currentSpeedGrade)
    {
        if (currentSpeedGrade >= speedGradeToStartParticle && speedGradeParticle.Count != 0)
        {
            foreach (var item in speedGradeParticle)
            {
                item.gameObject.SetActive(true);
            }
        }
    }
}
