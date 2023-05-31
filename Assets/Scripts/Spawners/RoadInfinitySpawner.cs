using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoadInfinitySpawner : MonoBehaviour
{
    public float RoadSpeed => _roadSpeed;

    [SerializeField]
    private float _roadSpeed = 2f;
    [SerializeField]
    private List<Transform> _roadPrefabs;

    private float _chunkHight;
    private float _globalSpawnPositionY = 0f;

    private void Start()
    {
        _chunkHight = GetComponentInChildren<BoxCollider2D>().size.y;
        _globalSpawnPositionY = -_chunkHight;
    }

    private void Update()
    {
        transform.Translate(Vector3.down * _roadSpeed * Time.deltaTime);
        if (transform.position.y <= _globalSpawnPositionY)
        {
            SpawnNewRoadPart();
            DestroyButtomRoad();
        }
    }

    private void SpawnNewRoadPart()
    {
        var localSpawnPosition = new Vector3(0, _chunkHight, 0);
        Instantiate(_roadPrefabs[UnityEngine.Random.Range(0,_roadPrefabs.Count - 1)],
            localSpawnPosition,
                Quaternion.identity,
                    transform);
        _globalSpawnPositionY -= _chunkHight;
    }

    private void DestroyButtomRoad()
    {
        var firstObject = GetComponentsInChildren<Road>().First().gameObject;
        Destroy(firstObject);
    }
}
