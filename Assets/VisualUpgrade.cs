using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualUpgrade : MonoBehaviour
{
    [SerializeField] private List<GameObject> armorGrade;
    [SerializeField] private List<GameObject> speedGrade;
    public List<ParticleSystem> SpeedParticle;
    public void ArmorGrade(int currentGrade) => armorGrade[currentGrade].SetActive(true);
    public void SpeedGrade(int currentGrade)
    {
        speedGrade[currentGrade].SetActive(true);
        if (currentGrade == 1)
        {
            foreach (var item in SpeedParticle)
            {
                item.Play();
            }
        }
    }
}
