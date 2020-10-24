using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager Instance => _instance;

    public EGameState GameState => _gameState;

    [SerializeField] private ShipLocomotion _shipPrefab = null;
    
    [Header("DEBUG")]
    [SerializeField] private EGameState _gameState = EGameState.STAND_BY;
    
    private static Manager _instance = null;
    private ShipLocomotion _ship = null;

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
    }

    public static bool IsNull(object objectToCheck)
    {
        return (objectToCheck == null);
    }
}