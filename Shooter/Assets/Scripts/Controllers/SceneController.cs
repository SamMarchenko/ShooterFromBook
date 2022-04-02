using System;
using System.Collections;
using System.Collections.Generic;
using Enemies.Scripts;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Random = UnityEngine.Random;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    private GameObject _enemy;
    [SerializeField] private Enemy[] _enemies;
    //private EnemyController _enemyController;
    private float _minWallXPos = -23f;
    private float _maxWallXPos = 23f;
    private float _minWallZPos = -30f;
    private float _maxWallZPos = 15f;

    private void Start()
    {
        //_enemy = _enemyPrefab as GameObject;
        CreateEnemy();
    } 

    void Update()
    {
        if (_enemy == null)
        {
            CreateEnemy();
        }
    }

    private void CreateEnemy()
    {
        // Метод, копирующий объект - шаблон.
        _enemy = Instantiate(_enemyPrefab) as GameObject;
        float SpawnX = Random.Range(_minWallXPos,_maxWallXPos);
        float SpawnZ = Random.Range(_minWallZPos, _maxWallZPos); 
        _enemy.transform.position = new Vector3(SpawnX, 4, SpawnZ); 
        float angle = Random.Range(0, 360); 
        _enemy.transform.Rotate(0, angle, 0);
    }
}
