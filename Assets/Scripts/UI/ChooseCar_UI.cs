using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseCar_UI : MonoBehaviour
{
    [SerializeField] private Text canisterText;
    [SerializeField] private Text canisterText_plus;
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
        if(canister <= 50 )
            canisterText.text = Currency.Canister.ToString();
        else if (canister > 50)
            canisterText.text = 50.ToString();
        if (canister < fullCanister)
        {
            fill = canister / fullCanister;
            bar.fillAmount = fill;
        }
        else
            bar.fillAmount = 1;
        if(canister > 50 )
        {
            canisterText_plus.gameObject.SetActive(true);
            canisterText_plus.text = "+" + (canister - 50).ToString();
        }
        else
            canisterText_plus.gameObject.SetActive(false);
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
