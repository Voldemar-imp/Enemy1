using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInstantiate : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private int _enemyCount;
    [SerializeField] private float _spawnTime;

    private SpawningPoint[] _spawningPoints = new SpawningPoint[1];
    private Coroutine _spawnJob;
    private int _tempCount = 0;
    private float _deltaTime = 0;

    private void Start()
    {
        _spawningPoints = GetComponentsInChildren<SpawningPoint>();
        _spawnJob = StartCoroutine(Spawn());
    }

    private void Update()
    {
        if (_spawnJob != null)
        {
            _deltaTime += Time.deltaTime;
        }
    }

    private IEnumerator Spawn()
    {       
        while (_tempCount < _enemyCount)
        {
            if (_deltaTime >= _spawnTime)
            {
                _deltaTime = 0;
                GameObject newObject = Instantiate(_enemy, _spawningPoints[_tempCount % _spawningPoints.Length].transform.position, Quaternion.identity);
                _tempCount++;
            }

            if (_tempCount == _enemyCount)
            {
                StopCoroutine(_spawnJob);
            }

            yield return null;
        }
    }
}
