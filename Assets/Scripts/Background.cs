using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private float _textureUnitSize = 0;
    private Transform _target = null;

    private void Awake()
    {
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        _textureUnitSize = texture.height / sprite.pixelsPerUnit;
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

    private void LateUpdate()
    {
        if (_target.position.y - transform.position.y >= _textureUnitSize)
        {
            transform.position += new Vector3(0, _textureUnitSize, 0);
        }
    }
}
