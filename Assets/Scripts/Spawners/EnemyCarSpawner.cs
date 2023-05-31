using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCarSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _enemyPrefab; 
    [SerializeField]
    private float _spawnInterval = 60f;

    private float _spawnTimer = 0f; 

    private void Update()
    {
        _spawnTimer += Time.deltaTime;
        if (_spawnTimer >= _spawnInterval)
        {
            SpawnEnemy(); 
            _spawnTimer = 0f; 
        }
    }

    private void SpawnEnemy()
    {
        var randomIndex = Random.Range(0, _enemyPrefab.Length);
        var spawnPosition = new Vector3(transform.position.x, Camera.main.transform.position.y - Camera.main.orthographicSize, transform.position.z);
        Instantiate(_enemyPrefab[randomIndex], spawnPosition, Quaternion.identity, transform);
    }
}
