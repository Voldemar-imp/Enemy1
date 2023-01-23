using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInstantiate : MonoBehaviour
{
    [SerializeField] private Thief _template;
    [SerializeField] private int _enemyCount;
    [SerializeField] private float _spawnTime;

    private SpawningPoint[] _spawningPoints = new SpawningPoint[1];
    private Coroutine _spawnJob;
    private int _tempCount = 0;

    private void Start()
    {
        _spawningPoints = GetComponentsInChildren<SpawningPoint>();
        _spawnJob = StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnTime);

            Thief newThief = Instantiate(_template, _spawningPoints[_tempCount % _spawningPoints.Length].transform.position, Quaternion.identity);
            _tempCount++;

            if (_tempCount == _enemyCount)
            {
                StopCoroutine(_spawnJob);
            }
        }
    }
}
