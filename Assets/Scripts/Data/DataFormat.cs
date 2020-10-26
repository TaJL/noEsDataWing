using System;
using System.Collections;
using System.Collections.Generic;
[Serializable]
public class DataFormat
{
    public PlayerData[] HighScores = new PlayerData[10];
}

[Serializable]
public class PlayerData
{
    public int Score = 0;
    public int TimeElapsed = 0;
    public string Name = "Player";
}
