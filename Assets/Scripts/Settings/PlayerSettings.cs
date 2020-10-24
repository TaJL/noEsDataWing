using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSettings : ScriptableObject
{
    public float BaseSpeed => _baseSpeed;

    [SerializeField] private float _baseSpeed = 1;
}
