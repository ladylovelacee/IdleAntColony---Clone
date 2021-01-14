using UnityEngine;
using UnityEngine.UI;
public class AntCountText : MonoBehaviour
{
    public Text CountText;

    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnPlayerDataUpdated.AddListener(UpdateCountText);
        EventManager.OnGameStart.AddListener(InitilizePanel);
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnPlayerDataUpdated.RemoveListener(UpdateCountText);
        EventManager.OnGameStart.RemoveListener(InitilizePanel);

    }

    private void InitilizePanel()
    {
        var playerData = SaveLoadManager.LoadPDP<PlayerData>(SavedFileNameHolder.PlayerData, new PlayerData());
        UpdateCountText(playerData);
    }


    private void UpdateCountText(PlayerData playerData)
    {
        CountText.text = playerData.AntCount.ToString();
    }
}
