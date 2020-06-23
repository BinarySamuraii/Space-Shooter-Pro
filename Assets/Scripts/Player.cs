using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 3.5f;
    [SerializeField] private GameObject _laserPrefab;
    [SerializeField] private GameObject _tripleShotPrefab;
    [SerializeField] private GameObject _shield;
    [SerializeField] private float _fireRate = 0.5f;
    [SerializeField] private int _lives = 3;
    [SerializeField] private float _powerupSpeed = 2;
    private float _canFire = -1f;
    private SpawnManager _spawnManager;
    private bool _isTripleShotActive = false;
    private bool _isSpeedActivated = false;
    private bool _isShieldActive = false;
    [SerializeField] private int _score;
    private UI_Manager _uiManager;
   private void Start()
    { 
        //Player Start Position
       transform.position = new Vector3(0, 0, 0);
       _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
       _uiManager = GameObject.Find("Canvas").GetComponent<UI_Manager>();
       
        if (_spawnManager == null)
        {
            Debug.Log("The Spawn Manager is NULL!");
        }

        if (_uiManager == null)
        {
            Debug.Log("The UI Manager is null!");
        }
    }

    
    private void Update()
    {
        PlayerMovement();
        PlayerBoundaries();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            PlayerFire();
        }
    }

    private void PlayerMovement()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
       transform.Translate(direction * (_speed * Time.deltaTime));  
 
    }

    private void PlayerBoundaries()
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

    private void PlayerFire()
    {
        _canFire = Time.time + _fireRate;

        if (_isTripleShotActive == true)
        {
            Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(_laserPrefab, transform.position + new Vector3(0, 01.05f, 0), Quaternion.identity);    
        }
        
    }

    public void Damage()
    {
        if (_isShieldActive == true)
        {
            _isShieldActive = false;
            _shield.SetActive(false);
            return;
        }
        
        _lives --;
        
        _uiManager.UpdateLives(_lives);
       

        if (_lives < 1)
        {
            _spawnManager.OnPlayerDeath();
            Destroy(this.gameObject);
        }
    }

    public void TripleShotActivate()
    {
        _isTripleShotActive = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }

    IEnumerator TripleShotPowerDownRoutine()
    {
        while (_isTripleShotActive == true)
        {
            yield return new WaitForSeconds(5.0f);
            _isTripleShotActive = false;
        } 
    }

    public void SpeedActivate()
    {
        _isSpeedActivated = true;
        _speed *= _powerupSpeed;
        StartCoroutine(SpeedPowerDownRoutine());

    }

    IEnumerator SpeedPowerDownRoutine()
    {
        while (_isSpeedActivated == true)
        {
            yield return new WaitForSeconds(5.0f);
            _isSpeedActivated = false;
            _speed /= _powerupSpeed;

        }
    }

    public void ShieldActivate()
    {
        
        _isShieldActive = true;
        _shield.SetActive(true);
        StartCoroutine(ShieldPowerDownRoutine());
    }

    IEnumerator ShieldPowerDownRoutine()
    {
        while (_isShieldActive == true)
        {
            yield return new WaitForSeconds(5.0f);
            _isShieldActive = false;
            _shield.SetActive(false);
            
        }
    }
   public void ScoreUpdate(int points)
    {
        _score += points;
        _uiManager.UpdateScore(_score);
    }
}
