using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wings : MonoBehaviour
{
    private Manager _manager=null;

    private void Awake()
    {
        _manager = GameObject.Find("Manager").GetComponent<Manager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag== "Enemy"){
            other.gameObject.SetActive(false);
            _manager.ScoreAddition(1);
        }
        
    }
}
