using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Powerup : MonoBehaviour
{
    [SerializeField] private float _speed = 3.0f;
    [SerializeField] private int _powerupID; // 0-Triple Shot 1-Speed 2-Shields
    [SerializeField] private AudioClip _powerupSound;
   
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
            
            AudioSource.PlayClipAtPoint(_powerupSound, transform.position);

            switch (_powerupID)
            {
                case 0:
                    player.TripleShotActivate();
                    break;
                case 1:
                    player.SpeedActivate();
                    break;
                case 2:
                    player.ShieldActivate();
                    break;
                default:
                    Debug.Log("Default Value");
                    break;
            }
            
            Destroy(this.gameObject);
        }
    }
    
}
