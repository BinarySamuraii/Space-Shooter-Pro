using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject _enemyContainer;
    [SerializeField] private GameObject[] _powerups;
    private bool _stopSpawning = false;
    private void Start()
    {

        
    }

    public void StartSpawning()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerUpRoutine());
    }
    
    private void Update()
    {
        
    }

    private IEnumerator SpawnEnemyRoutine()
    {
        yield return new WaitForSeconds(3.0f);
        while (_stopSpawning == false)
        {
            GameObject newEnemy = Instantiate(_enemyPrefab, _enemyContainer.transform, true);
            yield return new WaitForSeconds(4.5f);
        }
    }

    private IEnumerator SpawnPowerUpRoutine()
    {
        yield return new WaitForSeconds(3.0f);
        while (_stopSpawning == false)
        {
            int randomPowerUp = Random.Range(0, 3);
            Instantiate(_powerups[randomPowerUp]);
            yield return new WaitForSeconds(Random.Range(10.0f, 20.0f)); 
        }
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}
