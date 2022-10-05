using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : MonoBehaviour
{
    public static Currency instance;
    public static int Canister = 25;
    public static int Parts = 9000000;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        if(PlayerPrefs.HasKey("Canister"))
          LoadCanister();
        if (PlayerPrefs.HasKey("Parts"))
            LoadParts();

    }
    private void Start()
    {
        DontDestroyOnLoad(this);
    }
    public static void AddCanister(int value)
    {
        Canister += value;
        ActionSystem.AddCanister();
        SaveCanister();
    }
    public static void SpendCanister(int value) 
    { 
        Canister -= value;
        ActionSystem.AddCanister();
        SaveCanister();
    }
    public static void AddParts(int value)
    {
        Parts += value;
        SaveParts();
    }
    public static void SpendParts (int value)
    {
        Parts -= value;
        SaveParts();
    }
    public static void SaveParts() => PlayerPrefs.SetInt("Parts", Parts);
    public static void LoadParts() => Parts = PlayerPrefs.GetInt("Parts");
    public static void SaveCanister() => PlayerPrefs.SetInt("Canister", Canister);
    public static void LoadCanister() => Parts = PlayerPrefs.GetInt("Canister");

}
