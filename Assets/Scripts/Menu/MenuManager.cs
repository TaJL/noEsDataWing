using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class MenuManager : MonoBehaviour
{
    [SerializeField]private GameObject ScorePanel=null;
    [SerializeField]private Text ScoreData=null;
    public string PlayerName=null;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
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
        ScoreData.text = ("Score: " + DataSaver.Load().Score + " " + "Time: " + DataSaver.Load().TimeElapsed + " seconds" + " Name: " + DataSaver.Load().PlayerName);
        ScorePanel.SetActive(true);
    }
    public void ScoreBack(){
        ScorePanel.SetActive(false);
    }
    public void NameSetter(Text other){
        PlayerName = other.text;
    }

    
}
