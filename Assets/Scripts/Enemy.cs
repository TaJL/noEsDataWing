using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]private float EnemySpeed=1;
    private GameObject Wings;
    private GameObject Player;
    private Manager _manager;
    private Transform CameraPosition=null;
    private void Awake()
    {
        Player= GameObject.Find("Player(Clone)");//ss
        _manager = GameObject.Find("Manager").GetComponent<Manager>();
        CameraPosition=GameObject.Find("GameCamera").transform;
        if(Player==null){
            Debug.Log("No encuentro el GameObject Player");
        }
        if(CameraPosition==null){
            Debug.Log("No encuentro la Camara");
        }
        
    }
    
    private void Update()
    {
        transform.Translate(new Vector2(0,-1*EnemySpeed*Time.deltaTime));
        if(transform.position.y<(CameraPosition.position.y-1.5)){
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject == Player){
            Debug.Log("GameOver");
        }
    }
}
