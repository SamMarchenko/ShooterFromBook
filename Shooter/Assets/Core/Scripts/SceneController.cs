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
    private EnemyController _Enemy;
    

    private void Start()
    {
        _enemy = _enemyPrefab as GameObject;
        _Enemy = _enemy.GetComponent<EnemyController>();
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
        //ПОДУМАТЬ, КАК УБРАТЬ GetComponent.
         _Enemy.EnemyData = _enemies[Random.Range(0, _enemies.Length)];
         float SpawnX = Random.Range(-23,23);
         float SpawnZ = Random.Range(-30, 15); 
         _enemy.transform.position = new Vector3(SpawnX, 4, SpawnZ); 
         float angle = Random.Range(0, 360); 
         _enemy.transform.Rotate(0, angle, 0);
    }
}
