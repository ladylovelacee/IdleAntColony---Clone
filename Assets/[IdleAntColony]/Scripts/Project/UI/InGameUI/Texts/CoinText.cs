using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CoinText : Panel
{
    public Text coinText;
    public int Coin
    {
        get
        {
            var playerData = SaveLoadManager.LoadPDP<PlayerData>(SavedFileNameHolder.PlayerData, new PlayerData());
            return playerData.CoinAmount;
        }
        set
        {
            var playerData = SaveLoadManager.LoadPDP<PlayerData>(SavedFileNameHolder.PlayerData, new PlayerData());
            playerData.CoinAmount = value;
            SaveLoadManager.SavePDP(playerData, SavedFileNameHolder.PlayerData);
        }
    }

    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnGameStart.AddListener(InitilizePanel);
        EventManager.OnPlayerDataUpdated.AddListener(UpdateCoinText);
        AntManager.OnNestReach.AddListener(IncreaseCoin);
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnGameStart.RemoveListener(InitilizePanel);
        EventManager.OnPlayerDataUpdated.RemoveListener(UpdateCoinText);
        AntManager.OnNestReach.AddListener(IncreaseCoin);

    }

    private void InitilizePanel()
    {
        var playerData = SaveLoadManager.LoadPDP<PlayerData>(SavedFileNameHolder.PlayerData, new PlayerData());
        UpdateCoinText(playerData);
    }

    void IncreaseCoin()
    {
        Coin++;
    }

    private void UpdateCoinText(PlayerData playerData)
    {
        coinText.text = playerData.CoinAmount.ToString();
    }
}
