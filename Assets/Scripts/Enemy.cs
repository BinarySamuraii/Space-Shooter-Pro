using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 4.0f;
    private void Start()
    {
        // Set Enemy Spawn
        transform.position = new Vector3(Random.Range(-8.0f, 9.0f), 7.5f, 0);
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
           
            Destroy(this.gameObject);
           
        }else if (other.CompareTag("Laser"))
        {
            Destroy(GameObject.FindWithTag("Laser"));
            Destroy(this.gameObject);
            
        }
    }
}
