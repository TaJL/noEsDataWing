using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Manager : MonoBehaviour
{
    public static Manager Instance => _instance;

    public EGameState GameState => _gameState;

    [SerializeField] private ShipLocomotion _shipPrefab = null;
    
    [Header("DEBUG")]
    [SerializeField] private EGameState _gameState = EGameState.STAND_BY;
    [SerializeField]private Text ScoreText=null;
    public int Scoreint=0;

    private static Manager _instance = null;
    private ShipLocomotion _ship = null;
    public DataFormat _dataFormat;
    private Timer _timer;
    public static Action<EGameState> OnGameStateChangedEvent;
    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;

        _ship = Instantiate<ShipLocomotion>(_shipPrefab);
        IsNull(_ship);

        _timer = GetComponent<Timer>();

        _dataFormat.PlayerName = GameObject.Find("MenuManager").GetComponent<MenuManager>().PlayerName;
    }

    private void Update()
    {
        _dataFormat.Score =Scoreint;
        _dataFormat.TimeElapsed = _timer.time;
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

    public void ProvisionalGameOver(){
        //provisional porque no tengo ni puta idea de como hacerlo con el temita de Action
        DataSaver.Save(_dataFormat);
        Debug.Log("GameOver (estoy al final de manager)");
        Time.timeScale = 0;
    }
}