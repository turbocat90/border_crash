using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseCar_UI : MonoBehaviour
{
    [SerializeField] private Text canisterText;
    [SerializeField] Image bar;
    private int canister;
    private float fill = 1;
    private float fullCanister = 50;
    private void Start()
    {
        UpgradeStats();
    }
    public void UpgradeStats()
    {
        canister = Currency.Canister;
        canisterText.text = Currency.Canister.ToString();
        if (canister < fullCanister)
        {
            fill = canister / fullCanister;
            bar.fillAmount = fill;
            Debug.Log(fill);
        }
        else
            bar.fillAmount = 1;
    }
    public void ActivateEvent()
    {
        ActionSystem.OnAddCanister += UpgradeStats;
    }
    public void DeActivateEvent()
    {
        ActionSystem.OnAddCanister -= UpgradeStats;
    }
}
