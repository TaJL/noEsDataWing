using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager Instance => _instance;

    private static Manager _instance = null;
    private ShipLocomotion _ship = null;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;

        _ship = Instantiate<ShipLocomotion>(Load<ShipLocomotion>());
        IsNull(_ship);
    }

    public static bool IsNull(object objectToCheck)
    {
        return (objectToCheck == null);
    }

    private T Load<T>() where T : MonoBehaviour
    {
        return Resources.Load<T>(typeof(T).Name);
    }
}
