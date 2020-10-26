using UnityEngine;
using System.IO;

public class DataHandler
{
    public static DataHandler Instance => _instance;
    private static DataHandler _instance = null;

    public PlayerData ActualPlayer = new PlayerData();
    public PlayerData[] HighScores = new PlayerData[10];

    public string directory= "/SavedData/";
    public string FileName= "Data.txt";

    public void Inicialize()
    {
        if (_instance != null)
        {
            return;
        }
        _instance = this;

        DataFormat save = Load();
        HighScores = save.HighScores;
        
        for(int positionInScore = 0; positionInScore < HighScores.Length; positionInScore++)
        {   
            if (HighScores[positionInScore] != null)
            {
                continue;
            }
            HighScores[positionInScore] = new PlayerData();
            HighScores[positionInScore].Score = 0;
            HighScores[positionInScore].TimeElapsed = 0;
            HighScores[positionInScore].Name = "----";
        }
    }

    public void Save(){
        
        PlayerData playerToRelocate = null;
        for(int positionInScore = 0; positionInScore < HighScores.Length; positionInScore++)
        {   
            PlayerData otherPlayer = HighScores[positionInScore];
            
            if (playerToRelocate != null)
            {
                HighScores[positionInScore] = playerToRelocate;
                playerToRelocate = otherPlayer;
                continue;
            }

            if (otherPlayer.Score > ActualPlayer.Score)
            {
                continue;
            }

            playerToRelocate = HighScores[positionInScore];
            HighScores[positionInScore] = ActualPlayer;
        }

        string dir = Application.persistentDataPath + directory;

        if(!Directory.Exists(dir)){
            Directory.CreateDirectory(dir);
        }

        DataFormat data = new DataFormat();
        data.HighScores = HighScores;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(dir+FileName,json);
    }

    private DataFormat Load(){
        string fullpath = Application.persistentDataPath + directory + FileName;
        DataFormat data = new DataFormat();
        if(File.Exists(fullpath)){
            string json = File.ReadAllText(fullpath);
            data = JsonUtility.FromJson<DataFormat>(json);
        }else{
            data = new DataFormat();
            for(int positionInScore = 0; positionInScore < HighScores.Length; positionInScore++)
            {   
                data.HighScores[positionInScore].Score = 0;
                data.HighScores[positionInScore].TimeElapsed = 0;
                data.HighScores[positionInScore].Name = "----";
            }
        }
        return data;
    }
}
