using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wings : MonoBehaviour
{
    [SerializeField]private AudioSource Speaker=null;
    [SerializeField]private AudioClip Kill=null;
    [SerializeField]private ParticleSystem enemyKillVFX =null;

    private Vector3 _initialScale = Vector3.one;
    private float _scale = 1;
    
    private void Awake()
    {
        _initialScale = transform.localScale;
        Speaker = GameObject.Find("Audio Source").GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag== "Enemy"){
            ParticleSystem vfx = Instantiate<ParticleSystem>(enemyKillVFX);
            vfx.transform.rotation = Quaternion.Lerp(Quaternion.identity, transform.rotation, 0.4f);
            vfx.transform.position = other.transform.position;

            other.gameObject.SetActive(false);
            Manager.Instance.ScoreAddition(1);
            Speaker.PlayOneShot(Kill);
            _scale = 2f;
        }
        
    }

    private void Update()
    {
        if (_scale > 1)
        {
            _scale -= Time.deltaTime * 4;
        }

        transform.localScale = _scale * _initialScale;
    }
}
