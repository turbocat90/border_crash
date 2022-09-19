using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvLPoints : MonoBehaviour
{
    public static LvLPoints instance;
    public List<Point> Lvl;
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    private void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
}
