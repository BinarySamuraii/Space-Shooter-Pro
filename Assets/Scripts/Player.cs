﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 3.5f;
    
    void Start()
    { 
        //Player Start Position
        transform.position = new Vector3(0, 0, 0);
    }

    
    void Update()
    {
        PlayerMovement();
        PlayerBoundaries();
    }

    void PlayerMovement()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        transform.Translate(direction * (_speed * Time.deltaTime));
    }

    void PlayerBoundaries()
    {
        var position = transform.position;
        position = new Vector3(position.x, Mathf.Clamp(position.y, -3.8f, 0), 0);
        transform.position = position;

        if (transform.position.x >= 11.2f)
        {
            transform.position = new Vector3(-11f, transform.position.y, 0);
        }else if (transform.position.x <= -11f)
        {
            transform.position = new Vector3(11f, transform.position.y, 0);
        }
    }
}