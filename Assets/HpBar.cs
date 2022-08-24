using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    public Image bar;
    private float fill;
    private float fullHpOnStart;
    public Gates gates;
    private void Start()
    {
        fill = 1;
        fullHpOnStart = gates.Hp;
    }
    private void Update()
    {
        fill = gates.Hp / fullHpOnStart;
        bar.fillAmount = fill;
    }
}
