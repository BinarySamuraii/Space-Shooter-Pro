using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 3.5f;
    [SerializeField] private GameObject _laserPrefab;
    [SerializeField] private float _fireRate = 0.5f;
    private float _canFire = -1f;
    
    void Start()
    { 
        //Player Start Position
        transform.position = new Vector3(0, 0, 0);
    }

    
    void Update()
    {
        PlayerMovement();
        PlayerBoundaries();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            PlayerFire();
        }
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

    void PlayerFire()
    {
        _canFire = Time.time + _fireRate;
        Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
    }
}
