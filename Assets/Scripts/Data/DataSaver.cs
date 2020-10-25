using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSaver : MonoBehaviour
{
    private Manager _manager=null;
    private Timer _timer=null;

    private void Awake()
    {
        _timer= GameObject.Find("Manager").GetComponent<Timer>();
        _manager = GameObject.Find("Manager").GetComponent<Manager>();
        if(_manager==null){
            Debug.Log("No encuentro el manager");
        }
        if(_timer==null){
            Debug.Log("No encuentro el manager");
        }
    }
    /*private void OnEnable()
    {
        Manager.OnGameStateChangedEvent+=EndState;
    }*/
    
   /* private void OnDisable()
    {
        Manager.OnGameStateChangedEvent-=EndState;
    }*/

    /*public void EndState(EGameState other){
        if(other==EGameState.GAME_OVER){
            VariablesSave();
        }
    }*/

    public void VariablesSave(){
        
        DataFormat CurrentData = new DataFormat();
        CurrentData.Score = _manager.Scoreint;
        CurrentData.TimeElapsed = _timer.time;
        CurrentData.PlayerName = "";//ss

        string DataSaved = JsonUtility.ToJson(CurrentData);
        
        System.IO.File.Create("/DataSaved.json");
        System.IO.File.WriteAllText(Application.dataPath+ "/Resources/JsonFile/DataSaved.json",DataSaved);
        Debug.Log("Se guardaron los datos");
        
    }
}
