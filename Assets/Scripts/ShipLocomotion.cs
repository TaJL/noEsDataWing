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
            if (_rigidBody == null)
            {
                return Vector2.up;
            }
            return _rigidBody.velocity + _deltaVelocity;
        }
        set
        {
            _deltaVelocity = value - _rigidBody.velocity - _deltaVelocity;
        }
    }
    private Vector2 _deltaVelocity = new Vector2();

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + (Vector3)_velocity);
    }

    private void Awake()
    {
        _settings = Settings.Instance.Ship;
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
        if (Manager.Instance.GameState == EGameState.GAME)
        {
            UpdateGame();
        }
    }

    void UpdateGame()
    {
        if (_velocity == Vector2.zero)
        {
            _velocity = Vector2.up * _settings.BaseSpeed;
        }

        Vector2 direction = ControlManager.Instance.GetDirection();
        if (direction.x == 0)
        {
            return;
        }
        float angle = Vector2.SignedAngle(Vector2.right, _velocity);
        angle -= Time.deltaTime * _settings.TurnSpeed * direction.x;
        transform.rotation = Quaternion.Euler(0,0,angle - 90);
        _velocity =  _settings.BaseSpeed * new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
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
