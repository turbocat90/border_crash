using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    [SerializeField] private List<GameObject> SpedBoost;
    [SerializeField] private List<GameObject> ArmorBoost;
    [SerializeField] private List<ParticleSystem> SpeedParticle;
    [SerializeField] private ParticleSystem upgradetParticle;

    [SerializeField] private List<Animator> animation;
    private int speedindex = 0;
    private int armorindex = 0;
    void Start()
    {
        
    }

    public void SpeedUpgrade()
    {
        if(speedindex < 2)
        {
             SpedBoost[speedindex].SetActive(true);
            speedindex++;
            upgradetParticle.Play();
            animation[0].SetTrigger("Click");
            if (speedindex  == 2)
            {
                foreach (var item in SpeedParticle)
                {
                    item.Play();
                }
            }
        }
    }
    public void ArmorUpgrade()
    {
        if (armorindex < 2)
        {
            ArmorBoost[armorindex].SetActive(true);
            armorindex++;
            upgradetParticle.Play();
            animation[1].SetTrigger("Click");

        }
    }

}
