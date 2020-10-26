using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Manager : MonoBehaviour
{
    public static Manager Instance => _instance;
    private static Manager _instance = null;

    public EGameState GameState => _gameState;

    [SerializeField] private ShipLocomotion _shipPrefab = null;
    
    [Header("DEBUG")]
    [SerializeField] private EGameState _gameState = EGameState.STAND_BY;
    [SerializeField] private Text ScoreText=null;
    [SerializeField] private AudioSource Speaker=null;
    [SerializeField] private AudioClip Death=null;
    public int Scoreint=0;

    private ShipLocomotion _ship = null;
    private Timer _timer;
    public static Action<EGameState> OnGameStateChangedEvent;
    private void Awake()
    {
        _instance = this;

        DataHandler dataHandler = new DataHandler();
        dataHandler.Inicialize();

        _ship = Instantiate<ShipLocomotion>(_shipPrefab);
        IsNull(_ship);

        _timer = GetComponent<Timer>();
    }

    private void Update()
    {
        DataHandler.Instance.ActualPlayer.Score = Scoreint;
        DataHandler.Instance.ActualPlayer.TimeElapsed = _timer.time;
    }
    private void OnEnable()
    {
        ControlManager.OnActionPressedEvent += ActionPressed;
    }

    private void OnDisable()
    {
        ControlManager.OnActionPressedEvent -= ActionPressed;
    }

    private void ActionPressed()
    {
        switch (_gameState)
        {
            case EGameState.STAND_BY:
            {
                _gameState = EGameState.GAME;
                OnGameStateChangedEvent?.Invoke(_gameState);
                break;
            }
        }
    }

    public static bool IsNull(object objectToCheck)
    {
        return (objectToCheck == null);
    }

    public void ScoreAddition(int points){
        Scoreint+=points;
        ScoreText.text = Scoreint.ToString();

    }

    public void ProvisionalGameOver()
    {
        if (_gameState == EGameState.GAME_OVER)
        {
            return;
        }

        _gameState = EGameState.GAME_OVER;
        Speaker.PlayOneShot(Death,volumeScale:100);
        DataHandler.Instance.Save();
        SceneManager.LoadScene(0);
    }
}