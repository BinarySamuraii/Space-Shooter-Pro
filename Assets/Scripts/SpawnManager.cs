using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject _enemyContainer;
    private bool _stopSpawning = false;
    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    
    private void Update()
    {
        
    }

    private IEnumerator SpawnRoutine()
    {
        while (_stopSpawning == false)
        {
            GameObject newEnemy = Instantiate(_enemyPrefab, _enemyContainer.transform, true);
            yield return new WaitForSeconds(4.5f);
        }
        
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}
