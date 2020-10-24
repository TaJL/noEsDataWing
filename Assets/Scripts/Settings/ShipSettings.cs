using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSettings : ScriptableObject
{
    public float BaseSpeed => _baseSpeed;
    public float TurnSpeed => _turnSpeed;

    [SerializeField] private float _baseSpeed = 1;
    [SerializeField] private float _turnSpeed = 5;
}
