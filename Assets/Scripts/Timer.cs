using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public int time=0;

    private void OnEnable()
    {
        Manager.OnGameStateChangedEvent+=StartCounting;
    }
    
    private void OnDisable()
    {
        Manager.OnGameStateChangedEvent-=StartCounting;
    }

    private void StartCounting(EGameState other){
        if(other==EGameState.GAME){
            StartCoroutine("TimerCR");
        }
        if(other==EGameState.GAME_OVER){
            StopCoroutine("TimerCR");
        }
    }
    IEnumerator TimerCR(){

        yield return new WaitForSeconds(1);
        time+=1;
        StartCoroutine("TimerCR");
    }
}
