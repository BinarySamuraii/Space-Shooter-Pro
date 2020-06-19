using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField] private float _speed = 3.0f;
   
    private void Start()
    {
        transform.position = new Vector3(Random.Range(-9.0f, 9.0f), 8.5f, 0);
    }

   
    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        transform.Translate(Vector3.down * (_speed * Time.deltaTime));
        if (transform.position.y <= -5.5f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.transform.GetComponent<Player>();

            if (player != null)
            {
                player.TripleShotActivate();
            }
            
            Destroy(this.gameObject);
        }
    }
    
}
