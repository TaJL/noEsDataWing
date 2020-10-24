using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Edit")]

    [SerializeField]private int EnemiesQuantity;
    [SerializeField]private float TimeBWEnemies=2;
    [SerializeField]private float MinXSpawn=0;
    [SerializeField]private float MaxXSpawn=0;
    [SerializeField]private float MinYSpawn=0;
    [SerializeField]private float MaxYSpawn=0;
    [Header("Debug")]
    
    [SerializeField]private List<GameObject> Enemies=null;
    private Vector2 SpawnPosition;
    private Vector2 RandomPositionSpawn;

    private void Awake()
    {
        SpawnPosition=transform.position;

        if(EnemiesQuantity==0){
            EnemiesQuantity=5;
        }

        if(MinXSpawn==0){
            MinXSpawn=-2.4f;
        }
        if(MaxXSpawn==0){
            MaxXSpawn=2.4f;
        }
        if(MinYSpawn==0){
            MinYSpawn=5.4f;
        }
        if(MaxYSpawn==0){
            MaxYSpawn=6.4f;
        }

        for(int i=0;i<EnemiesQuantity;i++){
            GameObject aux = Instantiate(Resources.Load("Enemy")as GameObject,SpawnPosition,Quaternion.identity);
            Enemies.Add(aux);
            aux.SetActive(false);
        }
        
    }
    //s
    private void Start()
    {
        StartCoroutine("Spawn");
    }

    IEnumerator Spawn(){

        float xr;
        float yr;
        
        foreach(GameObject Enemy in Enemies){
            if(!Enemy.activeSelf){
                xr= Random.Range(MinXSpawn,MaxXSpawn);
                yr= Random.Range(MinYSpawn,MaxYSpawn);
                Enemy.transform.position = new Vector2(xr,yr);
                Enemy.SetActive(true);
            }
            yield return new WaitForSeconds(TimeBWEnemies);
        }
        StartCoroutine("Spawn");
    }
}
