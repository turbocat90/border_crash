using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapControl : MonoBehaviour
{
    [SerializeField] private Animator LevelAnimation;
    [SerializeField] private List<GameObject> Levels;
    void Start()
    {
        SetLvlvlIcons();
        CheckLvlvAnimation();
    }


    void Update()
    {
        
    }
    private void CheckLvlvAnimation()
    {
        if (SceneControll.currentLvl == 0)
            LevelAnimation.SetTrigger("5-1");
        else if (SceneControll.currentLvl == 1)
            LevelAnimation.SetTrigger("1-2");
        else if(SceneControll.currentLvl == 2)
            LevelAnimation.SetTrigger("2-3");
        else if (SceneControll.currentLvl == 3)
            LevelAnimation.SetTrigger("3-4");
        else if (SceneControll.currentLvl == 4)
            LevelAnimation.SetTrigger("4-5");
        else if (SceneControll.currentLvl == 5)
            LevelAnimation.SetTrigger("5-1");
    }
    private void SetLvlvlIcons()
    {
        for (int i = 0; i < SceneControll.currentLvl; i++)
        {
            Levels[i].transform.GetChild(1).gameObject.SetActive(true);
            Levels[i].transform.GetChild(2).gameObject.SetActive(false);
        }
    }
    public void StartGarageScene() => SceneControll.instance.StartGarageScene();
}
