using UnityEngine;

public class GlobalUIManager : MonoBehaviour
{
    [SerializeField] private StartTimer _initialStartTimer;
    [SerializeField] private ClockTimer _initialGameplayTimeLeftTimer;
    [SerializeField] private GameOverScreen _initialGameOverScreen;
    private static StartTimer _startTimer;
    private static ClockTimer _gameplayTimeLeftTimer;
    private static GameOverScreen _gameOverScreen;

    private static ClockTimer _currentActiveGameplayerTimeLeftTimer;

    private void Awake()
    {
        _startTimer = _initialStartTimer;
        _gameplayTimeLeftTimer = _initialGameplayTimeLeftTimer;
        _gameOverScreen = _initialGameOverScreen;

        GlobalGameState.GlobalGameState_OnStateChanged += GlobalGameState_OnStateChanged;
    }

    private void GlobalGameState_OnStateChanged(object sender, GlobalGameState.GameStateEnum e)
    {
        switch (e)
        {
            case GlobalGameState.GameStateEnum.Start:
                DisplayStartTimer(GlobalGameState.StartTime);
                DisplayGamePlayTimeLeftTimer();
                break;
            case GlobalGameState.GameStateEnum.Gameplay:
                StartGamePlayerTimeLeftTimer();
                break;
            case GlobalGameState.GameStateEnum.GameOver:
                RaiseGameOverScreen();
                break;
        }
    }

    public static void DisplayStartTimer (float durationSeconds)
    {
        StartTimer newStartTimer = Instantiate(_startTimer);
        newStartTimer.StartTimerSeconds(durationSeconds);
    }

    public static void DisplayGamePlayTimeLeftTimer()
    {
        _currentActiveGameplayerTimeLeftTimer = Instantiate(_gameplayTimeLeftTimer);
        _currentActiveGameplayerTimeLeftTimer.SetTimer(GlobalGameState.GameplayTime);
    }

    public static void StartGamePlayerTimeLeftTimer()
    {
        _currentActiveGameplayerTimeLeftTimer.StartTimer();
    }

    public static void RaiseGameOverScreen()
    {
        Instantiate(_gameOverScreen);
    }
}
