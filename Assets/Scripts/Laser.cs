using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro.EditorUtilities;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float _speed = 8f;
    private bool _isEnemyLaser = false;

    void Start()
    {

    }


    private void Update()
    {
        if (_isEnemyLaser == false)
        {
            PlayerLaser();
        }
        else
        {
            EnemyLaser();
        }

    }

    private void PlayerLaser()
    {
        transform.Translate(Vector3.up * (_speed * Time.deltaTime));

        if (transform.position.y >= 8f)
        {
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }

            Destroy(this.gameObject);

        }
    }

    private void EnemyLaser()
    {
        transform.Translate(Vector3.down * (_speed * Time.deltaTime));

        if (transform.position.y <= -8f)
        {
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }

            Destroy(this.gameObject);
        }

    }

    public void IsEnemyLaser()
    {
        _isEnemyLaser = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && _isEnemyLaser == true)
        {
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                player.Damage();
            }
        }
    }
}