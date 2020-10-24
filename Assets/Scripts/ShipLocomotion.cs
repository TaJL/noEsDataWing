using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ShipLocomotion : MonoBehaviour
{
    public Vector2 Velocity { get => _velocity; set => _velocity = value; }

    private ShipSettings _settings = null;
    private Rigidbody2D _rigidBody = null;

    private Vector2 _velocity
    {
        get
        {
            return _rigidBody.velocity + _deltaVelocity;
        }
        set
        {
            _deltaVelocity = value - _rigidBody.velocity - _deltaVelocity;
        }
    }
    private Vector2 _deltaVelocity = new Vector2();

    private void Awake()
    {
        _settings = Settings.Instance.Player;
        if (Manager.IsNull(_settings))
        {
            return;
        }

        _rigidBody = GetComponent<Rigidbody2D>();
        if (Manager.IsNull(_rigidBody))
        {
            return;
        }
    }

    void Update()
    {
        _velocity = Vector2.up * _settings.BaseSpeed;
    }

    private void FixedUpdate()
    {
        if (_deltaVelocity != Vector2.zero)
        {
            _rigidBody.velocity += _deltaVelocity;
            _deltaVelocity = Vector2.zero;
        }
    }
}
