﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroid : MonoBehaviour
{
   [SerializeField] private float _spinSpeed = 19.0f;
   [SerializeField] private GameObject _explosionPrefab;
   private SpawnManager _spawnManager;
  
    void Start()
    {
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
    }

  
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        transform.Rotate(Vector3.forward * (_spinSpeed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Laser")
        {
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            _spawnManager.StartSpawning();
            Destroy(this.gameObject, 0.25f);
        }
    }
}
