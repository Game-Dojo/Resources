using UnityEngine.Events;

public static class EventManager
{
    #region General

    public static event UnityAction<bool> GamePaused;
    public static void OnGamePaused(bool value) => GamePaused?.Invoke(value);

    public static event UnityAction GameOver;
    public static void OnGameOver() => GameOver?.Invoke();

    public static event UnityAction GameWon;
    public static void OnGameWon() => GameWon?.Invoke();
    
    public static event UnityAction<int> ItemPicked;
    public static void OnItemPicked(int value) => ItemPicked?.Invoke(value);
    
    public static event UnityAction<int> ScoreUpdate;
    public static void OnScoreUpdate(int value) => ScoreUpdate?.Invoke(value); 
    #endregion
}