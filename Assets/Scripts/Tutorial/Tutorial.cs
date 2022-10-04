using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject panel_1;
    [SerializeField] private GameObject panel_2;
    public void StartFirstStep()
    {
        panel_2.SetActive(false);
        panel_1.SetActive(true);
    }
    public void StartSecondStep()
    {
        panel_1.SetActive(false);
        Time.timeScale = 0.0001f;
        panel_2.SetActive(true);

    }
    public void StartThirdStep()
    {
        panel_1.SetActive(false);
        panel_2.SetActive(false);
        Time.timeScale = 1f;
    }
}
