using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Edit")]

    [SerializeField]private int EnemiesQuantity;
    [SerializeField]private float TimeBWEnemies=3;
    [SerializeField]private float MinXSpawn=0;
    [SerializeField]private float MaxXSpawn=0;
    [SerializeField]private float MinYSpawn=0;
    [SerializeField]private float MaxYSpawn=0;
    [Header("Debug")]
    
    [SerializeField]private List<GameObject> Enemies=null;
    [SerializeField]private Transform CameraPosition=null;
    private Vector2 SpawnPosition;
    private Vector2 RandomPositionSpawn;
    private Manager _manager;
    private void Awake()
    {
        SpawnPosition=transform.position;

        if(EnemiesQuantity==0){
            EnemiesQuantity=25;
        }

        if(MinXSpawn==0){
            MinXSpawn=-2.4f;
        }
        if(MaxXSpawn==0){
            MaxXSpawn=2.4f;
        }
        if(MinYSpawn==0){
            MinYSpawn=0.1f;
        }
        if(MaxYSpawn==0){
            MaxYSpawn=0.9f;
        }

        if(CameraPosition==null){
            Debug.Log("No encuentro la camara");
        }
        for(int i=0;i<EnemiesQuantity;i++){
            GameObject aux = Instantiate(Resources.Load("Enemy")as GameObject,SpawnPosition,Quaternion.identity,transform);
            Enemies.Add(aux);
            aux.SetActive(false);
        }

        _manager = GameObject.Find("Manager").GetComponent<Manager>();
        
    }

    private void Update()
    {
        if(_manager._dataFormat.TimeElapsed>70){
            TimeBWEnemies=0.1f;
        }else if(_manager._dataFormat.TimeElapsed>60){
            TimeBWEnemies=0.3f;
        }else if(_manager._dataFormat.TimeElapsed>50){
            TimeBWEnemies=0.5f;
        }else if(_manager._dataFormat.TimeElapsed>40){
            TimeBWEnemies=1;
        }else if(_manager._dataFormat.TimeElapsed>30){
            TimeBWEnemies=1.5f;
        }else if(_manager._dataFormat.TimeElapsed>20){
            TimeBWEnemies=2;
        }else if(_manager._dataFormat.TimeElapsed>10){
            TimeBWEnemies=2.5f;
        }
        
    }

    private void OnEnable()
    {
        Manager.OnGameStateChangedEvent+=Spawning;
    }
    
    private void OnDisable()
    {
        Manager.OnGameStateChangedEvent-=Spawning;
    }

    void Spawning(EGameState other){
        if(other==EGameState.GAME){
            StartCoroutine("Spawn");
        }else if(other==EGameState.GAME_OVER){
            StopCoroutine("Spawn");
        }
        
    }
    IEnumerator Spawn(){

        float xr;
        float yr;
        
        foreach(GameObject Enemy in Enemies){
            if(!Enemy.activeSelf){
                xr= Random.Range(MinXSpawn,MaxXSpawn);
                yr= Random.Range(MinYSpawn,MaxYSpawn);
                Enemy.transform.position = new Vector2((xr+CameraPosition.position.x),(yr+9.5f+CameraPosition.position.y));
                Enemy.SetActive(true);
            }
            yield return new WaitForSeconds(TimeBWEnemies);
        }
        StartCoroutine("Spawn");
    }
}
