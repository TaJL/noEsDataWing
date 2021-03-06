﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlManager : MonoBehaviour
{
    public static ControlManager Instance => _instance;
    public static Action OnActionPressedEvent;

    private static ControlManager _instance = null;

    private PlayerInput _playerInput = null;

    private InputAction _directionAction = null;
    private InputAction _actionAction = null;

    private const string DIRECTION = "Direction";
    private const string ACTION = "Action";

    private void Awake()
    {
        if (_instance != null)
        {
            return;
        }
        _instance = this;

        _playerInput = GetComponent<PlayerInput>();
        Controls gameInputs = new Controls();
        _playerInput.currentActionMap = gameInputs.Game;
        _playerInput.actions.Enable();
        _directionAction = _playerInput.actions[DIRECTION];
        _actionAction = _playerInput.actions[ACTION];
    }

    private void OnEnable()
    {
        if (_playerInput == null)
        {
            return;
        }

        _actionAction.started += context => OnActionPressedEvent?.Invoke();
    }

    private void OnDisable()
    {
        if (_playerInput == null)
        {
            return;
        }

        _actionAction.started -= context => OnActionPressedEvent?.Invoke();
    }

    public Vector2 GetDirection()
    {
        return _directionAction.ReadValue<Vector2>();
    }
}
