using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPanel : MonoBehaviour
{
    public GameObject LogoPanel;
    private void Awake()
    {
        if (PlayerPrefs.HasKey("LvlPanel"))
            LogoPanel.SetActive(false);
        else
            LogoPanel.SetActive(true);
    }
    public void CloseStartPanel(GameObject startPanel)
    {
        PlayerPrefs.SetInt("LvlPanel", 1);
        Destroy(startPanel);
    }
}
