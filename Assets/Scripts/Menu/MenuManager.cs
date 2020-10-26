using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject ScorePanel=null;
    [SerializeField] private PlayerDataShowcast[] scoreBoard = null;

    public string PlayerName=null;

    private void Awake()
    {
        DataHandler dataHandler = new DataHandler();
        dataHandler.Inicialize();
    }

    public void OnButton(Text other){
        other.fontSize += 2;
    }

    public void OffButton(Text other){
        other.fontSize -= 2;
    }

    public void Play(){
        if(PlayerName==null){
            PlayerName = "Player";
        }
        SceneManager.LoadScene(1);
    }
    public void ScoreEnter(){
        for (int i = 0; i < scoreBoard.Length; i++)
        {
            PlayerData playerData = DataHandler.Instance.HighScores[i];
            scoreBoard[i].SetTexts(playerData.Score, playerData.TimeElapsed, playerData.Name);
        }
        ScorePanel.SetActive(true);
    }
    public void ScoreBack(){
        ScorePanel.SetActive(false);
    }
    public void NameSetter(Text other){
        DataHandler.Instance.ActualPlayer.Name = other.text;
    }
}
