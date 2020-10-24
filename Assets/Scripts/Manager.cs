using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager Instance => _instance;

    private static Manager _instance = null;

    private void Awake()
    {
        if (_instance != null)
        {
            return;
        }
        _instance = this;
    }

    public static bool IsNull(object objectToCheck)
    {
        return (objectToCheck == null);
    }
}
