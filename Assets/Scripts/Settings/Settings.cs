using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public static Settings Instance => _instance;
    public PlayerSettings Player => _player;


    private static Settings _instance = null;
    private PlayerSettings _player = null;

    private void Awake()
    {
        if (_instance != null)
        {
            return;
        }
        _instance = this;

        _player = Load<PlayerSettings>();
    }

    private T Load<T>() where T : ScriptableObject
    {
        return Resources.Load<T>(typeof(T).Name);
    }
}
