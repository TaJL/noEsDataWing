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
    public void OnButton(Text other){
        other.fontSize += 2;
    }

    public void OffButton(Text other){
        other.fontSize -= 2;
    }

    public void Play(){
        SceneManager.LoadScene(1);
    }
    public void ScoreEnter(){
        ScoreData.text = ("Score: " + DataSaver.Load().Score + " " + "Time: " + DataSaver.Load().TimeElapsed + " seconds");
        ScorePanel.SetActive(true);
    }
    public void ScoreBack(){
        ScorePanel.SetActive(false);
    }
}
