using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour
{
    [SerializeField] private Vector2 _followVelocity = Vector2.zero;
    [SerializeField] private float _slowFollowDistance = 1;
    [SerializeField] private float _fastFollowDistance = 4;
    [SerializeField] private float _maxHorizontalFollow = 4;
    private Transform _target = null;

    private void OnValidate()
    {
        _fastFollowDistance = Mathf.Max(_fastFollowDistance, _slowFollowDistance);
    }

    private void OnEnable()
    {
        ShipLocomotion.OnInstantiatedEvent += UpdateTarget;
    }

    private void OnDisable()
    {
        ShipLocomotion.OnInstantiatedEvent -= UpdateTarget;
    }

    private void UpdateTarget(ShipLocomotion ship)
    {
        _target = ship.transform;
        Manager.IsNull(_target);
    }

    private void Update()
    {
        if (_target.position.y - transform.position.y > _fastFollowDistance)
        {
            transform.position += new Vector3(0, _target.position.y - _fastFollowDistance - transform.position.y, 0);
        }
        else if (_target.position.y - transform.position.y > _slowFollowDistance)
        {
            transform.position += new Vector3(0, Time.deltaTime * _followVelocity.y, 0);
        }

        float newXposition = Mathf.Clamp(_target.position.x, -_maxHorizontalFollow, _maxHorizontalFollow);
        transform.position = new Vector3(newXposition, transform.position.y, transform.position.z);
    }
}
