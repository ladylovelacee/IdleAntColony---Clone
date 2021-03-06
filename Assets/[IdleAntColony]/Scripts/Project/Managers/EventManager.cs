﻿using UnityEngine.Events;

public static class EventManager
{
    #region Game State Events
    public static UnityEvent OnGameStart = new UnityEvent();
    public static UnityEvent OnGameOver = new UnityEvent();
    #endregion

    #region Level Events
    public static UnityEvent OnLevelStart = new UnityEvent();
    public static UnityEvent OnLevelFinish = new UnityEvent();
    public static UnityEvent OnLevelContinue = new UnityEvent();
    #endregion

    #region Data Events
    public static PlayerDataEvent OnPlayerDataUpdated = new PlayerDataEvent();
    #endregion
}
public class PlayerDataEvent : UnityEvent<PlayerData> { }