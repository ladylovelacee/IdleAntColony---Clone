using UnityEngine;

[System.Serializable]
public class PlayerData
{

    private int coinAmount;
    public int CoinAmount { get { return coinAmount; } set { coinAmount = value; EventManager.OnPlayerDataUpdated.Invoke(this); } }

    [SerializeField]
    private int antCount;
    public int AntCount { get { return antCount; } set { antCount = value; EventManager.OnPlayerDataUpdated.Invoke(this); } }

}
