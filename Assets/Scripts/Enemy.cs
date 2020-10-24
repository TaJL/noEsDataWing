using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]private float EnemySpeed=1;
    
    private void Update()
    {
        transform.Translate(new Vector2(0,-1*EnemySpeed*Time.deltaTime));
        if(transform.position.y<-5.5f){
            gameObject.SetActive(false);
        }
    }

}
