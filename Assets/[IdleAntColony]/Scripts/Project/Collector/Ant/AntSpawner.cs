using UnityEngine;

public class AntSpawner : MonoBehaviour
{
    [Header("Ant Prefab")]
    public GameObject ant;

    private void OnEnable()
    {
        EventManager.OnGameStart.AddListener(Initiliaze);
        AntManager.OnAntSpawn.AddListener(SpawnAnt);
    }

    private void OnDisable()
    {
        EventManager.OnGameStart.AddListener(Initiliaze);
        AntManager.OnAntSpawn.RemoveListener(SpawnAnt);
    }
    void Initiliaze()
    {
        var playerData = SaveLoadManager.LoadPDP<PlayerData>(SavedFileNameHolder.PlayerData, new PlayerData());
        for (int i = 0; i < playerData.AntCount; i++)
        {
            if (ant != null)
                Instantiate(ant, transform);
        }
    }

    void SpawnAnt()
    {
        if (ant != null)
            Instantiate(ant, transform);

        //Data process
        var playerData = SaveLoadManager.LoadPDP<PlayerData>(SavedFileNameHolder.PlayerData, new PlayerData());
        playerData.AntCount++;
        SaveLoadManager.SavePDP(playerData, SavedFileNameHolder.PlayerData);
        AntManager.OnAntMove.Invoke();
    }
}
