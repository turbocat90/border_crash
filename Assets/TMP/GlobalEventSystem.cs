using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class GlobalEventSystem
{
    public static event Action OnCompleteLvl;
    public static event Action OnCarDestroyed;
    public static event Action OnGameOver;
    public static event Action OnRefreshStats;
    public static event Action OnStartLvl;
    public static void CompleteLvl()
    {
        OnCompleteLvl?.Invoke();
    }
    public static void CarDestroyed()
    {
        OnCarDestroyed?.Invoke();
    }
    public static void GameOver()
    {
        OnGameOver?.Invoke();
    }
    public static void RefreshStats()
    {
        OnRefreshStats?.Invoke();
    }
    public static void StartLvl()
    {
        OnStartLvl?.Invoke();
    }
}
