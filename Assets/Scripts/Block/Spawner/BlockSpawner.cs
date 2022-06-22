using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BlockSpawner : MonoBehaviour
{ 
    [SerializeField] private Block _blockPrefab;
    [SerializeField] private Line _linePrefab;

    private BlockSpawnPoint[] _spawnpoints;
    private int _spawnPointsCount => _spawnpoints.Length;

    private void Awake()
    {
        _spawnpoints = GetComponentsInChildren<BlockSpawnPoint>();
    }

    public void CreateLine(Transform allLines, int generateChance)
    {

        for (int i = 0; i < _spawnPointsCount; i++)
        {
            if (Random.Range(0, 100) < generateChance)
            {
                var newSpawnPoint = _spawnpoints[i].transform;
                Instantiate(_blockPrefab, newSpawnPoint.position, Quaternion.identity, allLines);
            }
        }

    }
}
