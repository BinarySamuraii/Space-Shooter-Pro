using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 4.0f;
    private Player _player;
    private Animator _anim;
    private void Start()
    {
        // Set Enemy Spawn
        transform.position = new Vector3(Random.Range(-8.0f, 9.0f), 7.5f, 0);
        _player = GameObject.Find("Player").GetComponent<Player>();

        if (_player == null)
        {
            Debug.Log("The player is NULL!");
        }

        _anim = GetComponent<Animator>();

        if (_anim == null)
        {
            Debug.Log("_anim is NULL");
        }
    }

   
    private void Update()
    {
        EnemyMovement();
    }

    private void EnemyMovement()
    {
        var randomPos = new Vector3(Random.Range(-8.0f, 9.0f), 7.5f, 0);
        transform.Translate(Vector3.down * (_speed * Time.deltaTime));

        if (transform.position.y <= -5.5f)
        {
            transform.position = randomPos;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.transform.GetComponent<Player>();

            if (player != null)
            {
                player.Damage();
                 
            }
           
           _anim.SetTrigger("OnEnemyDeath");
           _speed = 0f;
            Destroy(this.gameObject, 2.8f);
           
        }else if (other.CompareTag("Laser"))
        {
            Destroy(GameObject.FindWithTag("Laser"));
            
            if (_player != null)
            {
                _player.ScoreUpdate(10);
            }
            _anim.SetTrigger("OnEnemyDeath");
            _speed = 0f;
            Destroy(this.gameObject, 2.8f);
            
        }
    }
}
