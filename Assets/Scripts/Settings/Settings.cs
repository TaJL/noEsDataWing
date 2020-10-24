using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public static Settings Instance => _instance;
    public ShipSettings Ship => _ship;


    private static Settings _instance = null;
    private ShipSettings _ship = null;

    private void Awake()
    {
        if (_instance != null)
        {
            return;
        }
        _instance = this;

        _ship = Load<ShipSettings>();
        print(_ship.BaseSpeed);
    }

    private T Load<T>() where T : ScriptableObject
    {
        return Resources.Load<T>(typeof(T).Name);
    }
}
