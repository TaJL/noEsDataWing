using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlManager : MonoBehaviour
{
    private void Awake()
    {
        _playerInput.currentActionMap = gameInputs.Dorf;
        _playerInput.actions.Enable();
        _directionAction = _playerInput.actions[DIRECTION];
        _jumpAction = _playerInput.actions[JUMP];
    }
}
