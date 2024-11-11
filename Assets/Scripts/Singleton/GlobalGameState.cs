using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGameState : MonoBehaviour
{
    public static float StartTime = 3f;
    public static float GameplayTime = 60f;

    private static float _currentTime = 0f;
    private static GameStateEnum _currentGameState;

    public static GameStateEnum CurrentGameState
    {
        get
        {
            return _currentGameState;
        }
        private set
        {
            _currentGameState = value;
        }
    }

    public static event EventHandler<GameStateEnum> GlobalGameState_OnStateChanged;

    public enum GameStateEnum
    {
        Start,
        Gameplay,
        GameOver
    }

    private void Start()
    {
        SetCurrentGameState(GameStateEnum.Start);
    }

    private static void SetCurrentGameState(GameStateEnum state)
    {
        GlobalGameState_OnStateChanged?.Invoke(null, state);
        _currentGameState = state;
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime > StartTime && _currentGameState != GameStateEnum.Gameplay && _currentGameState != GameStateEnum.GameOver)
        {
            SetCurrentGameState(GameStateEnum.Gameplay);
        }
        else if (_currentTime > StartTime + GameplayTime && _currentGameState != GameStateEnum.GameOver)
        {
            SetCurrentGameState(GameStateEnum.GameOver);
        }
    }
}
