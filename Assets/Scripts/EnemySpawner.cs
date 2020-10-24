using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    
    [SerializeField]private int CantidadEnemigos;
    [SerializeField]private float VelocidadEnemigos;
    [SerializeField]private float MinXSpawn;
    [SerializeField]private float MaxXSpawn;
    [SerializeField]private float MinYSpawn;
    [SerializeField]private float MaxYSpawn;
    
    [SerializeField]private List<GameObject> Enemies;
    private Vector2 SpawnPosition;
    private Vector2 RandomPositionSpawn;

    private void Awake()
    {
        SpawnPosition=transform.position;

        if(CantidadEnemigos==0){
            CantidadEnemigos=5;
        }

        if(VelocidadEnemigos==0){
            VelocidadEnemigos=2;
        }

        
    }
    private void Start()
    {
        for(int i=0;i<CantidadEnemigos;i++){
            GameObject aux = Instantiate(Resources.Load("Enemy")as GameObject,SpawnPosition,Quaternion.identity);
            Enemies.Add(aux);
            aux.SetActive(false);
        }
    }
}
