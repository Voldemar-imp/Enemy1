using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInstantiate : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private int _enemyCount;
    [SerializeField] private float _spawnTime;

    private Spawn[] _spawns = new Spawn[1];
    private Coroutine _spawningJob;
    private int _tempCount = 0;
    private float _deltaTime = 0;

    private void Start()
    {
        _spawns = GetComponentsInChildren<Spawn>();
        _spawningJob = StartCoroutine(Spawning());
    }

    private void Update()
    {
        if (_spawningJob != null)
        {
            _deltaTime += Time.deltaTime;
        }
    }

    private IEnumerator Spawning()
    {       
        while (_tempCount < _enemyCount)
        {
            if (_deltaTime >= _spawnTime)
            {
                _deltaTime = 0;
                GameObject newObject = Instantiate(_enemy, _spawns[_tempCount % _spawns.Length].transform.position, Quaternion.identity);
                _tempCount++;
            }

            if (_tempCount == _enemyCount)
            {
                StopCoroutine(_spawningJob);
            }

            yield return null;
        }
    }
}
