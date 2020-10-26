using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class MenuManager : MonoBehaviour
{
    [Header("Debug")]
    [SerializeField]private GameObject ScorePanel=null;
    [SerializeField]private Text Score1=null;
    [SerializeField]private Text Time1=null;
    [SerializeField]private Text Name1=null;
    /*
    [SerializeField]private Text Name2=null;
    [SerializeField]private Text Name3=null;
    [SerializeField]private Text Name4=null;
    [SerializeField]private Text Name5=null;
    [SerializeField]private Text Score2=null;
    [SerializeField]private Text Score3=null;
    [SerializeField]private Text Score4=null;
    [SerializeField]private Text Score5=null;
    [SerializeField]private Text Time2=null;
    [SerializeField]private Text Time3=null;
    [SerializeField]private Text Time4=null;
    [SerializeField]private Text Time5=null;
    */
  
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
        Score1.text = DataSaver.Load().Score.ToString();
        Time1.text = DataSaver.Load().TimeElapsed.ToString();
        Name1.text = DataSaver.Load().PlayerName;
        ScorePanel.SetActive(true);
    }
    public void ScoreBack(){
        ScorePanel.SetActive(false);
    }
    public void NameSetter(Text other){
        PlayerName = other.text;
    }

    
}
