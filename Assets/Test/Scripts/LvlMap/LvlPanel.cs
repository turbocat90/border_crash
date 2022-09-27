using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlPanel : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.HasKey("LvlPanel"))
            gameObject.SetActive(false);
    }

}
