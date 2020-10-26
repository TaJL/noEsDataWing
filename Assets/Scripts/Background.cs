using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField]private float speed = 0;
    private float _textureUnitSize = 0;
    private Transform _target = null;

    private void Awake()
    {
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        _textureUnitSize = transform.lossyScale.y * texture.height / sprite.pixelsPerUnit;
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
        print(_target);
    }

    private void LateUpdate()
    {
        if (_target == null)
        {
            return;
        }
        
        if (_target.position.y - transform.position.y >= _textureUnitSize)
        {
            transform.position += new Vector3(0, _textureUnitSize, 0);
        }

        transform.position  += new Vector3(0, speed * Time.deltaTime, 0);
    }
}
