using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]private float EnemySpeed=1;
    private GameObject Wings;
    private GameObject Player;
    private Manager _manager;

    private void Awake()
    {
        Player= GameObject.Find("Player(Clone)");//ss
        _manager = GameObject.Find("Manager").GetComponent<Manager>();
        if(Player==null){
            Debug.Log("No encuentro el GameObject Player");
        }
    }
    
    private void Update()
    {
        transform.Translate(new Vector2(0,-1*EnemySpeed*Time.deltaTime));
        if(transform.position.y<-5.5f){
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
