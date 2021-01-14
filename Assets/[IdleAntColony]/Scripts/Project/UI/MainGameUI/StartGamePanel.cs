
public class StartGamePanel : Panel
{
    #region Private Methods
    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnGameStart.AddListener(HidePanel);
        EventManager.OnGameOver.AddListener(ShowPanel);
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnGameStart.RemoveListener(HidePanel);
        EventManager.OnGameOver.RemoveListener(ShowPanel);
    }
    #endregion
}